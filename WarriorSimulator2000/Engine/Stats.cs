using System.Collections.Generic;

namespace WarriorSimulator2000.Engine
{
    public class Stats
    {
        public Stats(Weapon mainHand, Weapon offHand, Character character, Gear gear, IList<Buff> buffs)
        {
            MainHand = mainHand;
            OffHand = offHand;
            Character = character;
            Gear = gear;
            Buffs = buffs;
        }
        public Character Character { get; set; }
        public Gear Gear { get; set; }
        public IList<Buff> Buffs {get; set;}

        public int AttackPower { get; internal set; }
        public int Hit { get; set; }
        public int Crit { get; set; }
        public int Haste { get; set; }
        public float CritModifier { get; set; }
        public (int Low, int High) GlanceModifier { get; set; }
        public int Resource { get; set; }

        public Weapon MainHand { get; set; }
        public Weapon? OffHand { get; set; }

        public bool DualWield { get { return OffHand != null; }  }

        public int MainHandSkill
        {
            get
            {
                return Character.WeaponSkill(MainHand);
            }
        }

        public int OffHandSkill
        {
            get
            {
                return OffHand != null ? Character.WeaponSkill(OffHand) : 0;
            }
        }
    }
}