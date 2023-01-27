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
        GameActions switcher = new GameActions();
        public void devMode()
        {
            user1.startHand();
            Card rando = new Card();
            user1.startDeck(new Card() { cardcolor = rando.cardColor(), cardattribute = rando.cardAttribute() });
            while (user1.checkWin() != true)
            {
                Console.Clear();
                Console.WriteLine("The Deck: ");
                user1.displayDeck();
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
                        user1.startDeck(user1.playCard());
                    }
                }
                else if (playChoice == 2)
                {
                    user1.drawCard();
                }
            }
            Console.Clear();
            Console.WriteLine("YOU WIN!!");

        }
        public void twoPlayers()
        {
            user1.startHand();
            user2.startHand();
            Card rando = new Card();
            user1.startDeck(new Card() { cardcolor = rando.cardColor(), cardattribute = rando.cardAttribute() });
            user2.startDeck(new Card() { cardcolor = rando.cardColor(), cardattribute = rando.cardAttribute() });
            int a = 0;
            int b = 2;
            while (user1.checkWin() != true || user2.checkWin() != true)
            {
                if (a % b == 0) {switcher = user1;}
                else {switcher = user2;}
                Console.Clear();
                Console.WriteLine("The Deck: ");
                switcher.displayDeck();
                Console.WriteLine("\nYour hand: ");
                switcher.displayHand();
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1: Play Card");
                Console.WriteLine("2: Draw Card");
                Console.ForegroundColor = ConsoleColor.Black;
                int playChoice = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (playChoice == 1)
                {
                    if (switcher.canPlay() == false)
                    {
                        Console.WriteLine("You have no cards able to be played!\nDrawing card for you");
                        Thread.Sleep(1000);
                        switcher.drawCard();
                    }
                    else
                    {
                        Console.WriteLine("What card do you want to play?");
                        switcher.startDeck(switcher.playCard());
                    }
                }
                else if (playChoice == 2)
                {
                    switcher.drawCard();
                }
                a++;
            }
            Console.Clear();
            Console.WriteLine("YOU WIN!!");
        }
    }
}
