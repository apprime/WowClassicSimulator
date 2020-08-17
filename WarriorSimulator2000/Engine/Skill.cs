namespace WarriorSimulator2000.Engine
{
    public interface Skill
    {
        string Name { get; }

        int Cooldown { get; set; }

        bool ShouldActivate(Stats stats, Target target);
        bool CanActivate();
        bool IsBlocking { get; }
        Swing Activate(Stats stats, Target target);
    }
}