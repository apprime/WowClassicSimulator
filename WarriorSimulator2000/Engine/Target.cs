namespace WarriorSimulator2000.Engine
{
    public struct Target
    {
        public bool IsMob;
        public int Defence;
        public int Level;
        public int Dodge;

        public int Health { get; internal set; }
        public int TotalHealth { get; internal set; }
        public int Armor { get; internal set; }
    }
}