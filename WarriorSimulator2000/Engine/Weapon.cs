using System;
using System.Collections.Generic;
using WarriorSimulator2000.Calculators;

namespace WarriorSimulator2000.Engine
{
    public class Weapon
    {
        public int Low;
        public int High;
        public int Speed;
        public int Cooldown;
        public int Skill;
        public WeaponType Type;
        public IEnumerable<Procc> Proccs;

        public Outcome[] Table;

        public int HitFactor { get; internal set; }

        internal Outcome Swing()
        {
            this.Cooldown = this.Speed;
            return HitTable.Roll(this.Table);
        }

        public bool MaySwing => --Cooldown > 0;

        internal int CalculateDamage(Outcome outcome, CharacterStats stats)
        {
            return Damage.Calculate(outcome, stats, this);
        }
    }
}