namespace WarriorSimulator2000.Engine
{
    public interface Skill
    {
        bool ShouldActivate(CharacterStats stats);
        Swing Activate(CharacterStats stats);
    }
}