using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public class NPC : Character
    {
        public NPC(string name, int hp, int minDamage, int maxDamage, float attackSpeed, float critRate, float lifeSteal)
            : base(name, hp, minDamage, maxDamage, attackSpeed, critRate, lifeSteal)
        {
        }
    }
}
