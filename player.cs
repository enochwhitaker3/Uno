using System;
using System.Security.Cryptography;
using Card;
using Deck;

namespace Player
{
    public class player
    {
        private List<card> playershand = new List<card>();
        public List<card> PlayersHand{ get { return playershand; } set { playershand = value; } }
        deck cardPile = new deck(); 
        public void startHand()
        {
            for (int i = 0; i < 7; i++)
            {
                card placeholderCard = new card();
                card newCard = new card() { cardattribute = placeholderCard.cardAttribute(), cardcolor = placeholderCard.cardColor() };
                if (newCard.cardcolor == "WILD") { newCard.cardattribute = null; }
                PlayersHand.Add(newCard);
            }
        }
        public void displayHand()
        {
            for (int i = 0; i < PlayersHand.Count; i++)
            {
                string color = i + 1 + ": " + PlayersHand[i].cardcolor;
                string number = $"{PlayersHand[i].cardattribute}";
                if (PlayersHand[i].cardcolor == "Red") { Console.ForegroundColor = ConsoleColor.Red; }
                if (PlayersHand[i].cardcolor == "Blue") { Console.ForegroundColor = ConsoleColor.Blue; }
                if (PlayersHand[i].cardcolor == "Green") { Console.ForegroundColor = ConsoleColor.Green; }
                if (PlayersHand[i].cardcolor == "Yellow") { Console.ForegroundColor = ConsoleColor.Yellow; }
                Console.WriteLine(color.PadRight(16) + number);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public card playCard(deck deck)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                int userInput = Convert.ToInt32(Console.ReadLine());
                userInput--;
                Console.ForegroundColor = ConsoleColor.White;
                if (PlayersHand[userInput].cardcolor != deck.getTopDeck().cardcolor && PlayersHand[userInput].cardattribute != deck.getTopDeck().cardattribute && PlayersHand[userInput].cardcolor != "WILD")
                {
                    Console.WriteLine("You cannot play that card!\nPlease try again: ");
                    Thread.Sleep(1000);
                }
                else if (PlayersHand[userInput].cardcolor == "WILD")
                {
                    Console.WriteLine("What color do you want the deck to be?");
                    string? chooseColor = Console.ReadLine();
                    string bananaProof = chooseColor.ToUpper();
                    PlayersHand.RemoveAt(userInput);
                    if (bananaProof == "BLUE") { card newCard = new card() { cardattribute = null, cardcolor = "Blue" }; cardPile.startDeck(newCard); return newCard; }
                    if (bananaProof == "RED") { card newCard = new card() { cardattribute = null, cardcolor = "Red" }; cardPile.startDeck(newCard); return newCard; }
                    if (bananaProof == "YELLOW") { card newCard = new card() { cardattribute = null, cardcolor = "Yellow" }; cardPile.startDeck(newCard); return newCard; }
                    if (bananaProof == "GREEN") { card newCard = new card() { cardattribute = null, cardcolor = "Green" }; cardPile.startDeck(newCard); return newCard; }
                }
                else
                {
                    card brandnewplaceholder = PlayersHand[userInput];
                    PlayersHand.RemoveAt(userInput);
                    return brandnewplaceholder;
                }
            }
        }

        public void drawCard()
        {
            card placeholderCard = new card();
            card newCard = new card() { cardattribute = placeholderCard.cardAttribute(), cardcolor = placeholderCard.cardColor() };
            if (newCard.cardcolor == "WILD") { newCard.cardattribute = null; }
            PlayersHand.Add(newCard);
        }
    }
}
