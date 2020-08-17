using System;
using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Warrior
{
    public class FuryRotation : RotationBase, Rotation
    {
        private Skill[] GCDPriorities = new Skill[]
        {
            new BattleShout(),
            new DeathWish(),
            new Recklessness(),
            new Execute(),
            new Overpower(),
            new Bloodthirst(),
            new Whirlwind(),
            new Hamstring()
        };

        private Skill[] NoGCDPriorities = new Skill[]
        {
            new BloodRage(),
            new HeroicStrike()
        };

        public void CooldownTick()
        {
            base.CooldownTick(GCDPriorities);
        }

        public Skill? GCDNext(Stats stats, Target target) => GetSkill(GCDPriorities, stats, target);

        public bool MayMainHand(Stats stats)
        {
            throw new NotImplementedException();
        }

        public bool MayOffHand(Stats stats)
        {
            throw new NotImplementedException();
        }

        public Skill? NoGCDNext(Stats stats, Target target) => GetSkill(NoGCDPriorities, stats, target);
    }
}
