using System.Collections.Generic;

namespace WarriorSimulator2000.Engine
{
    public class Weapon
    {
        public int Low;
        public int High;
        public double Speed;
        public int Skill;
        public WeaponType Type;
        public IEnumerable<Procc> Proccs;

        public Outcome[] Table;

        public int HitFactor { get; internal set; }
    }
}