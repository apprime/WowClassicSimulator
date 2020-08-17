namespace WarriorSimulator2000.Engine
{
    public class RotationBase
    {
        public virtual int GlobalCooldownLength { get; set; } = 1500;
        public int GlobalCooldownRemaining{ get; set; } = 0;
        public bool GCDAvailable => GlobalCooldownRemaining == 0;

        public void StartGCD()
        {
            GlobalCooldownRemaining = GlobalCooldownLength;
        }

        public Skill? GetSkill(Skill[] orderedList, Stats stats, Target target)
        {
            foreach (var skill in orderedList)
            {
                if (skill.ShouldActivate(stats, target))
                {
                    if (skill.CanActivate())
                    {
                        return skill;
                    }

                    if (skill.IsBlocking)
                    {
                        break;
                    }
                }
            }

            return null;
        }

        public void CooldownTick(Skill[] skills)
        {
            GlobalCooldownRemaining -= 1;

            foreach (var skill in skills)
            {
                if(skill.Cooldown > 0)
                {
                    skill.Cooldown -= 1;
                }
            }
        }
    }
}
