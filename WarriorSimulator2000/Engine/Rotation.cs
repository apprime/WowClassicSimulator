namespace WarriorSimulator2000.Engine
{
    public interface Rotation
    {
        Skill? GCDNext(Stats stats, Target target);
        Skill? NoGCDNext(Stats stats, Target target);

        bool GCDAvailable { get; }
        void StartGCD();
        bool MayMainHand(Stats stats);
        bool MayOffHand(Stats stats);
        void CooldownTick();
    }
}