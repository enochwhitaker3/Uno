using System;
using Card;
using GameLogic;
using GameType;
using Deck;

namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameActions user = new GameActions();

            Console.WriteLine("Welcome to UNO: The World's Number One Card Game!\n");
            Console.WriteLine("How would you like to play?: ");
            Console.WriteLine("1: Developer Mode");
            Console.WriteLine("2: Two Players");
            Console.WriteLine("3: Exit Program\n");
            Console.WriteLine("More options coming soon!....\n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            user.startHand();

            switch (userInput)
            {
                case 1:
                    game devMode = new game();
                    devMode.devMode();
                    break;
                case 2:
                    game twoPlayers = new game();
                    twoPlayers.twoPlayers();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}