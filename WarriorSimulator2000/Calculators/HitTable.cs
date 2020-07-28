using System;
using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Calculators
{
    //https://github.com/magey/classic-warrior/wiki/Attack-table
    public static class HitTable
    {
        /*
         Creatures at your level have a 5% chance to Dodge your attacks. 
        Each additional level the target has over the player grants them 0.5% additional chance to dodge. 
        (So 6.5% chance to Dodge for creatures 3 levels above the player.)

        Creatures that are 3 levels above the player have a 14% Parry chance.
        Players have an 8% chance to miss a creature that is 3 levels above them.
        Critical Strike chance is reduced by 1% per each additional level the target has over the player. 
        (So if you have a 4% chance to crit an at-level target, you have a 1% chance to crit a +3-level target.)
         */

        private static readonly Random rng = new Random();

        private static Outcome[] GenerateTable(CharacterStats stats, Weapon weapon, Target target)
        {
            Outcome[] table = new Outcome[1000];
            int missChance = GetMissChance(stats, weapon, target);
            int glanceChance = GlancingChance(stats, target);
            int dodgeChance = DodgeChance(weapon, target);
            int critChance = CritChance(stats, weapon, target);

            for (int i = 0; i < table.Length; i++)
            {
                if(missChance > 0)
                {
                    table[i] = Outcome.Miss;
                    missChance--;
                    continue;
                }

                if(glanceChance > 0)
                {
                    table[i] = Outcome.Glancing;
                    glanceChance--;
                    continue;
                }

                if(dodgeChance > 0)
                {
                    table[i] = Outcome.Dodge;
                    dodgeChance--;
                    continue;
                }

                if(critChance > 0)
                {
                    table[i] = Outcome.Crit;
                    critChance--;
                    continue;
                }

                table[i] = Outcome.Hit;
            }

            return table;
        }

        public static Outcome[] GenerateMainHandTable(CharacterStats stats, Target target)
        {
            return GenerateTable(stats, stats.MainHand, target);
        }

        public static Outcome[] GenerateOffHandTable(CharacterStats stats, Target target)
        {
            if(stats.OffHand.HasValue)
            {
                return GenerateTable(stats, stats.OffHand.Value, target);
            }
            else
            {
                return GenerateTable(stats, stats.MainHand, target);
            }
        }

        public static Outcome Roll(Outcome[] table) => table[rng.Next(1, 1000)];

        private static int CritChance(CharacterStats stats, Weapon weapon, Target target)
        {
            var baseAttack = Math.Min(stats.Level * 5, weapon.Skill);

            if(target.IsMob)
            {
                if (IsHighLevelEnemy(target, baseAttack))
                {
                    return HighLevelEnemyCrit(stats, target, baseAttack);
                }
                else
                {
                    return RegularEnemyCrit(stats, target, baseAttack);
                }
            }
            else
            {
                return PlayerCrit(stats, weapon, target);
            }
        }

        private static bool IsHighLevelEnemy(Target target, int baseAttack) => baseAttack - target.Defence < 0;

        private static bool IsLowLevelEnemy(Target target) => target.Level < 10;

        private static bool IsHighLevelEnemy(int levelDiff) => levelDiff > 10;

        private static int PlayerCrit(CharacterStats stats, Weapon weapon, Target target) => stats.Crit + (weapon.Skill - target.Defence) * 4;

        private static int RegularEnemyCrit(CharacterStats stats, Target target, int baseAttack) => stats.Crit + (baseAttack - target.Defence) * 4;

        private static int HighLevelEnemyCrit(CharacterStats stats, Target target, int baseAttack) => stats.Crit + (baseAttack - target.Defence) * 20;

        private static int DodgeChance(Weapon weapon, Target target)
        {
            if(target.IsMob)
            {
                return MobDodge(weapon, target);
            }
            else
            {
                return PlayerDodge(weapon, target);
            }
        }

        private static int PlayerDodge(Weapon weapon, Target target) => WowMath.ToIntTimesTen(target.Dodge + (target.Defence - weapon.Skill) * 0.04f);

        private static int MobDodge(Weapon weapon, Target target) => WowMath.ToIntTimesTen(5 + (target.Defence - weapon.Skill) * 0.1f);

        private static int GlancingChance(CharacterStats stats, Target target)
        {
            return WowMath.ToIntTimesTen(10 + (target.Defence - Math.Min(stats.Level*5, stats.MainHandSkill) * 2));
        }

        private static float MissChance(int weaponskill, Target target)
        {
            var levelDiff = target.Defence - weaponskill;
 
            if (target.IsMob)
            {
                return MobMissChance(weaponskill, target, levelDiff);
            }
            else
            {
                return PlayerEnemyMiss(levelDiff);
            }
        }

        private static float MobMissChance(int weaponskill, Target target, int levelDiff)
        {
            if (IsLowLevelEnemy(target))
            {
                return LowLevelEnemyMiss(target);
            }

            if (IsHighLevelEnemy(levelDiff))
            {
                return HighLevelEnemyMiss(weaponskill, target);
            }
            else
            {
                return RegularEnemyMiss(weaponskill, target);
            }
        }

        private static float PlayerEnemyMiss(int levelDiff) => 5 + (levelDiff * 0.04f);

        private static float LowLevelEnemyMiss(Target target) => 5 * (target.Level / 10);

        private static float RegularEnemyMiss(int weaponskill, Target target) => 5 + (target.Defence - weaponskill) * 0.1f;

        private static float HighLevelEnemyMiss(int weaponskill, Target target) => 5 + (target.Defence - weaponskill) * 0.2f;

        private static int GetMissChance(CharacterStats stats, Weapon weapon, Target target)
        {
            float missChance = MissChance(weapon.Skill, target);
            if (HasDualWieldPenalty(stats, target))
            {
                missChance = AddDualWieldPenalty(missChance);
            }

            return WowMath.ToIntTimesTen(missChance);
        }

        private static bool HasDualWieldPenalty(CharacterStats stats, Target target) => stats.DualWield && target.Level > 9;

        private static float AddDualWieldPenalty(float missChance) => (missChance * 0.8f) + 20;

        
    }
}
