using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public float AttackSpeed { get; set; }
        public float CritRate { get; set; }
        public float LifeSteal { get; set; }

        public Character(string name, int hp, int minDamage, int maxDamage, float attackSpeed, float critRate, float lifeSteal)
        {
            Name = name;
            HP = hp;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            AttackSpeed = attackSpeed;
            CritRate = critRate;
            LifeSteal = lifeSteal;
        }

        public void Attack(Character target)
        {
            bool isCritical = Utils.IsCriticalHit(CritRate);
            int damage = Utils.CalculateDamage(MinDamage, MaxDamage, isCritical);
            target.TakeDamage(damage);
            Console.Write($"{Name} attacks {target.Name} for {damage} damage. ");
            if (isCritical)
            {
                Console.Write("Critical hit! ");
            }
            Heal(damage);
            
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }

        private void Heal(int damage)
        {
            int healAmount = (int)(damage * (LifeSteal / 100));
            HP += healAmount;
            Console.WriteLine($"{Name} heals for {healAmount} HP.");
        }

        public bool IsDead()
        {
            return HP <= 0;
        }
    }
}
