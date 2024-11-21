using TurnBaseGame;

Console.WriteLine("Welcome to the game!");
Console.WriteLine("Do you want to configure player and NPC? (y/n)");
string choice = Console.ReadLine().ToLower();

if (choice == "y")
{
    Config.ConfigureCharacter("player");
    Config.ConfigureCharacter("npc");
}

while (true)
{
    Game game = new Game();
    game.Start();

    Console.WriteLine("Do you want to start again? (y/n)");
    string again = Console.ReadLine().ToLower();

    if (again != "y")
    {
        break;
    }
}
