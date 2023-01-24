using System;
using System.Reflection.Metadata;
using Cards;
using GameLogic;

namespace GameType
{
    public class game
    {
        GameActions user1 = new GameActions();
        GameActions user2 = new GameActions();
        GameActions user3 = new GameActions();
        GameActions user4 = new GameActions();
        public void singlePlayer()
        {
            user1.startHand();
            while (user1.checkWin() != true)
            {
                Console.Clear();
                Console.WriteLine("The Deck: ");
                user1.startDeck();
                Console.WriteLine("\nYour hand: ");
                user1.displayHand();
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1: Play Card");
                Console.WriteLine("2: Draw Card");
                Console.ForegroundColor = ConsoleColor.Black;
                int playChoice = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (playChoice == 1)
                {
                    if (user1.canPlay() == false)
                    {
                        Console.WriteLine("You have no cards able to be played!\nDrawing card for you");
                        Thread.Sleep(1000);
                        user1.drawCard();
                    }
                    else
                    {
                        Console.WriteLine("What card do you want to play?");
                        user1.playCard();
                    }
                }
                else if (playChoice == 2)
                {
                    user1.drawCard();
                }
            }

        }
    }
}
