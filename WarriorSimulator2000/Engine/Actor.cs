namespace WarriorSimulator2000.Engine
{
    public interface Actor
    {
        CharacterStats Stats { get; set; }
        Rotation Rotation { get; set; }

    }
}