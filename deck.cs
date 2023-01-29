using System;
using System.Security.Cryptography;
using Card;

namespace Deck
{
    public class deck
    {
        card topDeckCard = new card();
        public card startDeck(card card)
        {
            topDeckCard = card;
            return topDeckCard;
        }
        public void displayDeck()
        {
            if (topDeckCard.cardcolor == "Red") { Console.ForegroundColor = ConsoleColor.Red; }
            if (topDeckCard.cardcolor == "Blue") { Console.ForegroundColor = ConsoleColor.Blue; }
            if (topDeckCard.cardcolor == "Green") { Console.ForegroundColor = ConsoleColor.Green; }
            if (topDeckCard.cardcolor == "Yellow") { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.WriteLine(topDeckCard.cardcolor + "\t\t" + topDeckCard.cardattribute);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public card getTopDeck()
        {
            return topDeckCard;
        }
    }
}
