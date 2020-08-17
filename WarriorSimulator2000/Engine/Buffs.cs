namespace WarriorSimulator2000.Engine
{
    public interface Buff 
    {
        public int Duration { get; set; }
        void OnActivate(Stats stats);
        void OnDeactivate(Stats stats);
    }
}