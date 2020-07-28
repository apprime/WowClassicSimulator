namespace WarriorSimulator2000.Engine
{
    public interface Rotation
    {
        Skill GCDNext(CharacterStats stats);
        Skill? NoGCDNext(CharacterStats stats);

        bool GCDAvailable { get; }
        void StartGCD();
        bool MayMainHand(CharacterStats stats);
        bool MayOffHand(CharacterStats stats);
    }
}