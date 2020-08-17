using System.Linq;
using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Warrior
{
    internal class BattleShout : SkillBase, Skill, Buff
    {
        public string Name => "Battle Shout";
        public bool IsBlocking => true;

        public int Duration { get; set; } = 120000;
        public override int Cooldown { get; set; } = 0;

        public Swing Activate(Stats stats, Target target)
        {
            this.OnActivate(stats);
            stats.Buffs.Add(this);
            stats.Resource = stats.Resource - 10;

            return new Swing { Damage = 0, Outcome = Outcome.Noop };
        }

        public void OnActivate(Stats stats)
        {
            stats.AttackPower += 193;
        }

        public void OnDeactivate(Stats stats)
        {
            stats.AttackPower -= 193;
        }

        public bool ShouldActivate(Stats stats, Target target)
        {
            var bs = stats.Buffs.OfType<BattleShout>().FirstOrDefault();

            return bs == null || bs.Duration < 1500;
        }
    }
}