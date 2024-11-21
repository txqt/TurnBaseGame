using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame
{
    public class Game
    {
        private Player player;
        private NPC npc;

        public void Start()
        {
            InitCharacters();
            Battle();
            DisplayResults();
        }

        private void InitCharacters()
        {
            player = Config.LoadCharacterConfig("player.ini") as Player;
            npc = Config.LoadCharacterConfig("npc.ini") as NPC;
        }

        private void Battle()
        {
            Character firstAttacker = ChooseFirstAttacker(player, npc);
            Character secondAttacker = (firstAttacker == player) ? npc : player;

            DateTime battleEndTime = DateTime.Now.AddMinutes(1); // Thời gian của một trận đánh là 1 phút
            int round = 1;

            while (DateTime.Now < battleEndTime && !player.IsDead() && !npc.IsDead())
            {
                int firstAttackerAttacks = (int)(firstAttacker.AttackSpeed);
                int secondAttackerAttacks = (int)(secondAttacker.AttackSpeed);
                Console.WriteLine($"Start round {round}");

                Console.WriteLine($"Turn of {firstAttacker.Name}");
                PerformTurn(firstAttacker, secondAttacker);
                if (secondAttacker.IsDead()) break;

                Thread.Sleep(1000);
                Console.WriteLine();

                Console.WriteLine($"Turn of {secondAttacker.Name}");
                PerformTurn(secondAttacker, firstAttacker);
                if (firstAttacker.IsDead()) break;

                Thread.Sleep(1000);
                Console.WriteLine();

                round++;
            }
        }

        private void PerformTurn(Character attacker, Character target)
        {
            int numberOfAttacks = (int)(attacker.AttackSpeed);
            for (int i = 0; i < numberOfAttacks; i++)
            {
                attacker.Attack(target);
                if (target.IsDead()) break;
            }
        }

        private Character ChooseFirstAttacker(Character player, Character npc)
        {
            Random random = new Random();
            return (random.Next(2) == 0) ? player : npc;
        }

        private void DisplayResults()
        {
            if (player.IsDead())
            {
                Console.WriteLine("Player is defeated.");
            }
            else if (npc.IsDead())
            {
                Console.WriteLine("NPC is defeated.");
            }
            else
            {
                Console.WriteLine("Time is up. Player loses.");
            }
        }
    }
}
