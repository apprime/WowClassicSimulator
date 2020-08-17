using WarriorSimulator2000.Calculators;
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
    public class Execute : SkillBase, Skill
    {
        public string Name => "Execute";

        public override int Cooldown { get; set; } = 0;

        public bool IsBlocking => true;

        public Swing Activate(Stats stats, Target target)
        {
            var swing = new Swing
            {
                Outcome = HitTable.Roll(stats.MainHand.Table),
                Damage = 600 + (15 * stats.Resource)
            };

            stats.Resource = 0;

            swing.Damage = Damage.ReduceArmor(swing.Damage, stats, target);
            return swing;
        }

        public bool ShouldActivate(Stats stats, Target target) => target.Health / target.TotalHealth <= 0.2d;
    }
}
