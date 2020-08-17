using WarriorSimulator2000.Engine;

namespace WarriorSimulator2000.Warrior
{
    internal class DeathWish : SkillBase, Skill, Buff //Yea, I know it is a debuff but who cares?
    {
        public string Name => throw new System.NotImplementedException();

        public int Cooldown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool IsBlocking => throw new System.NotImplementedException();

        public int Duration { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Swing Activate(Stats stats, Target target)
        {
            throw new System.NotImplementedException();
        }

        public bool CanActivate()
        {
            throw new System.NotImplementedException();
        }

        public void OnActivate(Stats stats)
        {
            throw new System.NotImplementedException();
        }

        public void OnDeactivate(Stats stats)
        {
            throw new System.NotImplementedException();
        }

        public bool ShouldActivate(Stats stats, Target target)
        {
            throw new System.NotImplementedException();
        }
    }
}