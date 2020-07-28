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

        public Skill? GetSkill(Skill[] orderedList, CharacterStats stats, Target target)
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
    }
}
