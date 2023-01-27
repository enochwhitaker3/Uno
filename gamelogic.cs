using System;
using Cards;


namespace GameLogic
{

    class GameActions 
    {
        List<Card> playersHand = new List<Card>();
        Card topDeckCard = new Card();
        public void startHand()
        {
            for (int i = 0; i < 7; i++)
            {
                Card placeholderCard = new Card();
                Card newCard = new Card() { cardattribute = placeholderCard.cardAttribute(), cardcolor = placeholderCard.cardColor() };
                if (newCard.cardcolor == "WILD") { newCard.cardattribute = null; }
                playersHand.Add(newCard);
            }
        }
        public void startDeck(Card card)
        {
            topDeckCard = card;
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
        public void displayDeck()
        {
            if (topDeckCard.cardcolor == "Red") { Console.ForegroundColor = ConsoleColor.Red; }
            if (topDeckCard.cardcolor == "Blue") { Console.ForegroundColor = ConsoleColor.Blue; }
            if (topDeckCard.cardcolor == "Green") { Console.ForegroundColor = ConsoleColor.Green; }
            if (topDeckCard.cardcolor == "Yellow") { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.WriteLine(topDeckCard.cardcolor + "\t\t" + topDeckCard.cardattribute);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public Card playCard()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                int userInput = Convert.ToInt32(Console.ReadLine());
                userInput--;
                Console.ForegroundColor = ConsoleColor.White;
                if (playersHand[userInput].cardcolor != topDeckCard.cardcolor && playersHand[userInput].cardattribute != topDeckCard.cardattribute && playersHand[userInput].cardcolor != "WILD")
                {
                    Console.WriteLine("You cannot play that card!\nPlease try again: ");
                    Thread.Sleep(1000);
                }
                else if (playersHand[userInput].cardcolor == "WILD")
                {
                    Console.WriteLine("What color do you want the deck to be?");
                    string? chooseColor = Console.ReadLine();
                    if (chooseColor == "BLUE") { Card newCard = new Card() { cardattribute = null , cardcolor = "Blue" }; startDeck(newCard); return newCard;}
                    if (chooseColor == "RED") { Card newCard = new Card() { cardattribute = null, cardcolor = "Red" }; startDeck(newCard); return newCard; }
                    if (chooseColor == "YELLOW") { Card newCard = new Card() { cardattribute = null, cardcolor = "Yellow" }; startDeck(newCard); return newCard; }
                    if (chooseColor == "GREEN") { Card newCard = new Card() { cardattribute = null, cardcolor = "Green" }; startDeck(newCard); return newCard; }
                    Card brandnewplaceholder = playersHand[userInput];
                    playersHand.RemoveAt(userInput);
                    return brandnewplaceholder;
                }
                else
                {
                    Card brandnewplaceholder = playersHand[userInput];
                    playersHand.RemoveAt(userInput);
                    return brandnewplaceholder;
                }
            }
        }
        public void drawCard()
        {
            Card placeholderCard = new Card();
            Card newCard = new Card() { cardattribute = placeholderCard.cardAttribute(), cardcolor = placeholderCard.cardColor() };
            if (newCard.cardcolor == "WILD") { newCard.cardattribute = null; }
            playersHand.Add(newCard);
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
        public bool canPlay()
        {
            for (int i = 0; i <= playersHand.Count - 1; i++)
            {
                if (playersHand[i].cardcolor != topDeckCard.cardcolor && playersHand[i].cardattribute != topDeckCard.cardattribute && playersHand[i].cardcolor != "WILD")
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

    } 
}