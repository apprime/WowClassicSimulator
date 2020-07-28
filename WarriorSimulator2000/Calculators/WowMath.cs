using System;

namespace WarriorSimulator2000.Calculators
{
    public static class WowMath
    {
        public static int ToInt(double input) => (int)Math.Round(input, 0);
        public static int ToIntTimesTen(double input) => (int)(Math.Round(input, 1) * 10);
        public static int ToIntPercentage(double input) => (int)(Math.Round(input, 2) * 100);

    }
}
