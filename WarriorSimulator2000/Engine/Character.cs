using System;

namespace WarriorSimulator2000.Engine
{
    public class Character
    {
        public int Level { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Intelect { get; set; }
        public int Spirit { get; set; }
        public int DaggerSkill { get; set; }
        public int SwordSkill { get; set; }
        public int MaceSkill { get; set; }
        public int AxeSkill { get; set; }
        public int PoleArmSkill { get; set; }

        public int WeaponSkill(Weapon weapon)
        {
            // There are some weapons that give two-handed bonuses.
            // We need to include them as well.
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
