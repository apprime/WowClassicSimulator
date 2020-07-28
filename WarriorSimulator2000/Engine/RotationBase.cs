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
    }
}
