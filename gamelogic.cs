using System;
using Card;
using Deck;


namespace GameLogic
{

    class GameActions 
    {
        List<card> playersHand = new List<card>();
        deck cardPile = new deck();
        public void startHand()
        {
            for (int i = 0; i < 7; i++)
            {
                card placeholderCard = new card();
                card newCard = new card() { cardattribute = placeholderCard.cardAttribute(), cardcolor = placeholderCard.cardColor() };
                if (newCard.cardcolor == "WILD") { newCard.cardattribute = null; }
                playersHand.Add(newCard);
            }
        }
        public void displayHand()
        {
            for (int i = 0; i < playersHand.Count; i++)
            {
                string color = i + 1 + ": " + playersHand[i].cardcolor;
                string number = $"{playersHand[i].cardattribute}";
                if (playersHand[i].cardcolor == "Red") { Console.ForegroundColor = ConsoleColor.Red; }
                if (playersHand[i].cardcolor == "Blue") { Console.ForegroundColor = ConsoleColor.Blue; }
                if (playersHand[i].cardcolor == "Green") { Console.ForegroundColor = ConsoleColor.Green; }
                if (playersHand[i].cardcolor == "Yellow") { Console.ForegroundColor = ConsoleColor.Yellow; }
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
                if (playersHand[userInput].cardcolor != deck.getTopDeck().cardcolor && playersHand[userInput].cardattribute != deck.getTopDeck().cardattribute && playersHand[userInput].cardcolor != "WILD")
                {
                    Console.WriteLine("You cannot play that card!\nPlease try again: ");
                    Thread.Sleep(1000);
                }
                else if (playersHand[userInput].cardcolor == "WILD")
                {
                    Console.WriteLine("What color do you want the deck to be?");
                    string? chooseColor = Console.ReadLine();
                    playersHand.RemoveAt(userInput);
                    if (chooseColor == "BLUE") { card newCard = new card() { cardattribute = null , cardcolor = "Blue" }; cardPile.startDeck(newCard); return newCard;}
                    if (chooseColor == "RED") { card newCard = new card() { cardattribute = null, cardcolor = "Red" }; cardPile.startDeck(newCard); return newCard; }
                    if (chooseColor == "YELLOW") { card newCard = new card() { cardattribute = null, cardcolor = "Yellow" }; cardPile.startDeck(newCard); return newCard; }
                    if (chooseColor == "GREEN") { card newCard = new card() { cardattribute = null, cardcolor = "Green" }; cardPile.startDeck(newCard); return newCard; }
                }
                else
                {
                    card brandnewplaceholder = playersHand[userInput];
                    playersHand.RemoveAt(userInput);
                    return brandnewplaceholder;
                }
            }
        }
        public void drawCard()
        {
            card placeholderCard = new card();
            card newCard = new card() { cardattribute = placeholderCard.cardAttribute(), cardcolor = placeholderCard.cardColor() };
            if (newCard.cardcolor == "WILD") { newCard.cardattribute = null; }
            playersHand.Add(newCard);
        }
        public bool canPlay(deck deck)
        {
            for (int i = 0; i <= playersHand.Count - 1; i++)
            {
                if (playersHand[i].cardcolor != deck.getTopDeck().cardcolor && playersHand[i].cardattribute != deck.getTopDeck().cardattribute && playersHand[i].cardcolor != "WILD")
                {
                    if (i == playersHand.Count - 1)
                    {
                        return false;
                    }     
                }
                else
                {
                    return true;
                }
            }
            throw new Exception("error");
        }
        public bool checkWin()
        {
            if (playersHand.Count == 0)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
    } 
}