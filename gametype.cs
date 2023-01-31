using System;
using System.Reflection.Metadata;
using Card;
using GameLogic;
using Deck;
using Player;

namespace GameType
{
    public class game
    {
        player user1 = new player();
        player user2 = new player();    
        player user3 = new player();
        player user4= new player();
        player switcher = new player();
        gamelogic validator = new gamelogic();  
        deck cardPile = new deck();
        public void devMode()
        {
            user1.startHand();
            card rando = new card();
            cardPile.startDeck(new card() { cardcolor = rando.cardColor(), cardattribute = rando.cardAttribute() });
            while (validator.checkWin(user1) != true)
            {
                Console.Clear();
                Console.WriteLine("The Deck: ");
                cardPile.displayDeck();
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
                    if (validator.canPlay(cardPile, user1) == false)
                    {
                        Console.WriteLine("You have no cards able to be played!\nDrawing card for you");
                        Thread.Sleep(1000);
                        user1.drawCard();
                    }
                    else
                    {
                        Console.WriteLine("What card do you want to play?");
                        cardPile.startDeck(user1.playCard(cardPile));
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
            card rando = new card();
            cardPile.startDeck(new card() { cardcolor = rando.cardColor(), cardattribute = rando.cardAttribute() });
            int a = 0;
            int b = 2;
            while (validator.checkWin(user1) != true && validator.checkWin(user2) != true)
            {
                if (a % b == 0) {switcher = user1;}
                else {switcher = user2;}
                Console.Clear();
                Console.WriteLine("The Deck: ");
                cardPile.displayDeck();
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
                    if (validator.canPlay(cardPile, switcher) == false)
                    {
                        Console.WriteLine("You have no cards able to be played!\nDrawing card for you");
                        Thread.Sleep(1000);
                        switcher.drawCard();
                    }
                    else
                    {
                        Console.WriteLine("What card do you want to play?");
                        cardPile.startDeck(switcher.playCard(cardPile));
                    }
                }
                else if (playChoice == 2)
                {
                    switcher.drawCard();
                }
                else
                {
                    Console.WriteLine("Please Only Type One Of The Options");
                    Thread.Sleep(1000);
                }
                a++;
            }
            Console.Clear();
            Console.WriteLine("YOU WIN!!");
        }
    }
}
