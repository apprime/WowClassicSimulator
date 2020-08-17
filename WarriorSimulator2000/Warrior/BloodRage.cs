using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Warrior
{
    internal class BloodRage : SkillBase, Skill, Buff
    {
        public string Name => "Blood Rage";

        public bool IsBlocking => false;

        public int Duration { get; set; } = 10000;

        public Swing Activate(Stats stats, Target target)
        {
            throw new System.NotImplementedException();
        }

        public void OnActivate(Stats stats)
        {
            stats.Resource += 10;
        }

        public void OnDeactivate(Stats stats)
        {
        }

        public bool ShouldActivate(Stats stats, Target target)
        {
            return stats.Resource < 90;
        }
    }
}