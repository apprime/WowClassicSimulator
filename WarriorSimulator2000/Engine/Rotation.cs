namespace WarriorSimulator2000.Engine
{
    public interface Rotation
    {
        Skill? GCDNext(CharacterStats stats, Target target);
        Skill? NoGCDNext(CharacterStats stats, Target target);

        bool GCDAvailable { get; }
        void StartGCD();
        bool MayMainHand(CharacterStats stats);
        bool MayOffHand(CharacterStats stats);
    }
}