using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public static class Utils
    {
        private static Random random = new Random();

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public static bool IsCriticalHit(float critRate)
        {
            return random.NextDouble() < critRate / 100;
        }

        public static int CalculateDamage(int minDamage, int maxDamage, bool isCritical)
        {
            int damage = RandomNumber(minDamage, maxDamage);
            if (isCritical)
            {
                damage = (int)(damage * 2.6);
            }
            return damage;
        }
    }
}
