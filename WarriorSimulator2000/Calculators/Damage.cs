using System;
using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Calculators
{
    public static class Damage
    {
        private static readonly Random rng = new Random();
        public static int Calculate(Outcome outcome, Stats stats, Weapon weapon)
        {
            switch(outcome)
            {
                case Outcome.Glancing:
                    int glanceModifier = RollGlance(stats.GlanceModifier);
                    return WowMath.ToInt(glanceModifier * GetWeaponDamage(weapon) / 100f);
                case Outcome.Hit:
                    return GetWeaponDamage(weapon);
                case Outcome.Crit:
                    return WowMath.ToInt(GetWeaponDamage(weapon) * stats.CritModifier);
                case Outcome.Miss:
                case Outcome.Dodge:
                case Outcome.Parry:
                default:
                    return 0;
            }
        }

        public static (int low, int high) GetGlancingRange(Weapon weapon, Target target)
        {
            int skillDiff = target.Defence - weapon.Skill;
            return
            (
                WowMath.ToIntPercentage(Math.Max(0, Math.Min(0.91, 1.3 - 0.05 * skillDiff))),
                WowMath.ToIntPercentage(Math.Max(0.2, Math.Min(0.99, 1.2 - 0.03 * skillDiff)))
            );
        }

        public static double CalculateRage(Outcome outcome, Stats stats, int damage, Weapon weapon)
        {
            return RageFormula(damage, RageConversion(stats.Character.Level), weapon.Speed, HitFactor(weapon, outcome));
        }

        public static int ReduceArmor(int damage, Stats stats, Target target)
        {
            var mitigationValue = (0.1 * target.Armor) / (8.5 * stats.Character.Level + 40);
            var mitigation = 1 - (mitigationValue / (1 + mitigationValue));

            return damage * WowMath.ToInt(mitigation);
        }

        private static double RageFormula(int damage, double rageConversion, double weaponSpeed, double hitFactor)
        {
            double combinedRage = RageFromDamage(damage, rageConversion) + ExtraRage(weaponSpeed, hitFactor);
            double alternative = FallbackRage(damage, rageConversion);

            return Math.Round(Math.Max(combinedRage, alternative), 2);
        }

        private static double FallbackRage(int damage, double rageConversion) => (15 * damage) / rageConversion;

        private static double ExtraRage(double weaponSpeed, double hitFactor) => (weaponSpeed * hitFactor) / 2;

        private static double RageFromDamage(int damage, double rageConversion) => (15 * damage) / (4 * rageConversion);

        private static double HitFactor(Weapon weapon, Outcome outcome) => outcome == Outcome.Crit ? weapon.HitFactor * 2 : weapon.HitFactor;

        private static double RageConversion(int level) => 0.0091107836 * Math.Pow(level, 2) + 3.225598133 * level + 4.2652911;

        private static int RollGlance((int low, int high) range) => rng.Next(range.low, range.high);

        private static int GetWeaponDamage(Weapon weapon) => rng.Next(weapon.Low, weapon.High);
    }
}
