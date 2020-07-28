using System;

namespace WarriorSimulator2000.Engine
{
    public class CharacterStats
    {
        public CharacterStats(Weapon mainHand, Weapon offHand)
        {
            MainHand = mainHand;
            OffHand = offHand;
        }
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Intelect { get; set; }
        public int Spirit { get; set; }
        public int Hit { get; set; }
        public int Crit { get; set; }
        public float CritModifier { get; set; }
        public (int Low, int High) GlanceModifier { get; set; }
        public int DaggerSkill { get; set; }
        public int SwordSkill { get; set; }
        public int MaceSkill { get; set; }
        public int AxeSkill { get; set; }
        public int PoleArmSkill { get; set; }
        public int Resource { get; set; }

        public Weapon MainHand { get; set; }
        public Weapon? OffHand { get; set; }

        public bool DualWield { get { return OffHand != null; }  }


        public int MainHandSkill
        {
            get
            {
                return WeaponSkill(MainHand);
            }
        }

        public int OffHandSkill
        {
            get
            {
                return OffHand.HasValue ? WeaponSkill(OffHand.Value) : 0;
            }
        }

        private int WeaponSkill(Weapon weapon)
        {
            switch (weapon.Type)
            {
                case WeaponType.Axe:
                    return AxeSkill;
                case WeaponType.Dagger:
                    return DaggerSkill;
                case WeaponType.Mace:
                    return MaceSkill;
                case WeaponType.PoleArm:
                    return PoleArmSkill;
                case WeaponType.Sword:
                    return SwordSkill;
                default:
                    throw new Exception("No Skill on this weapon");
            }
        }
    }
}