using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Warrior
{
    /// <summary>
    /// 15 Rage	Melee Range
    /// Instant cast
    /// Requires Warrior
    /// Requires level 56
    /// Requires Melee Weapon
    /// Requires Battle Stance, Berserker Stance
    /// Attempt to finish off a wounded foe, causing 600 damage 
    /// and converting each extra point of rage into 15 additional damage.
    /// Only usable on enemies that have 20% or less health.
    /// </summary>
    public class Execute : Skill
    {


        /// <param name="stats"></param>
        /// <returns></returns>
        public Swing Activate(CharacterStats stats)
        {
            
            
            var swing = new Swing();

            swing.Outcome = stats.AttackTable.Roll();

            swing.Damage = 600 + 15 * stats.Resource;

            stats.Resource = 0;

        }

        public bool ShouldActivate(CharacterStats stats, Target target) => target.Health / target.TotalHealth <= 0.2d;

    }
}
