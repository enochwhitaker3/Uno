using System;
using Cards;
using GameLogic;
using GameType;

namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameActions user = new GameActions();

            Console.WriteLine("Welcome to UNO: The World's Number One Card Game!");
            Console.WriteLine("How would you like to play?: ");
            Console.WriteLine("1: With 4 Local Players");
            Console.WriteLine("2: Exit Program");
            Console.WriteLine("More options coming soon!....\n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            user.startHand();

            switch (userInput)
            {
                case 1:
                    game singlePlayer = new game();
                    singlePlayer.singlePlayer();
                    break;

            }

        }
    }
}