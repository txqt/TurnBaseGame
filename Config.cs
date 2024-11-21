using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public static class Config
    {
        public static void ConfigureCharacter(string characterType)
        {
            Console.WriteLine($"Enter configuration for {characterType}:");

            Console.Write("Name: ");
            string? name = Console.ReadLine() ?? $"{characterType} {Guid.NewGuid()}";

            Console.Write("HP: ");
            int hp = int.TryParse(Console.ReadLine(), out int _hp) ? _hp : 0;

            Console.Write("Min Damage: ");
            int minDamage = int.TryParse(Console.ReadLine(), out int _minDamage) ? _minDamage : 0;

            Console.Write("Max Damage: ");
            int maxDamage = int.TryParse(Console.ReadLine(), out int _maxDamage) ? _maxDamage : 0;

            Console.Write("Attack Speed (times per second): ");
            float attackSpeed = int.TryParse(Console.ReadLine(), out int _attackSpeed) ? _attackSpeed : 0;

            Console.Write("Crit Rate (0 to 100): ");
            float critRate = int.TryParse(Console.ReadLine(), out int _critRate) ? _critRate : 0;

            Console.Write("Life Steal (0 to 100): ");
            float lifeSteal = int.TryParse(Console.ReadLine(), out int _lifeSteal) ? _lifeSteal : 0;

            string configFilePath = characterType == "player" ? "player.ini" : "npc.ini";
            string[] lines = {
                $"Name={name}",
                $"HP={hp}",
                $"MinDamage={minDamage}",
                $"MaxDamage={maxDamage}",
                $"AttackSpeed={attackSpeed}",
                $"CritRate={critRate}",
                $"LifeSteal={lifeSteal}"
            };

            File.WriteAllLines(configFilePath, lines);
            Console.WriteLine($"{characterType} configuration saved to {configFilePath}.");
        }
        public static Character LoadCharacterConfig(string configFilePath)
        {
            string[] lines = File.ReadAllLines(configFilePath);
            string name = lines[0].Split('=')[1];
            int hp = int.Parse(lines[1].Split('=')[1]);
            int minDamage = int.Parse(lines[2].Split('=')[1]);
            int maxDamage = int.Parse(lines[3].Split('=')[1]);
            float attackSpeed = float.Parse(lines[4].Split('=')[1]);
            float critRate = float.Parse(lines[5].Split('=')[1]);
            float lifeSteal = float.Parse(lines[6].Split('=')[1]);

            if (configFilePath.Contains("player"))
            {
                return new Player(name, hp, minDamage, maxDamage, attackSpeed, critRate, lifeSteal);
            }
            else
            {
                return new NPC(name, hp, minDamage, maxDamage, attackSpeed, critRate, lifeSteal);
            }
        }
    }
}
