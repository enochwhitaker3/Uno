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
            for (int i = 0; i < 5; i++)
            {
                Card placeholderCard = new Card();
                Card newCard = new Card() { cardnumber = placeholderCard.cardNumber(), cardcolor = placeholderCard.cardColor() };
                playersHand.Add(newCard);
            }
        }
        public void startDeck()
        {
            Card placeholderCard = new Card();
            topDeckCard = new Card() { cardnumber = placeholderCard.cardNumber(), cardcolor = placeholderCard.cardColor() };
            if (topDeckCard.cardcolor == "Red") { Console.ForegroundColor = ConsoleColor.Red; }
            if (topDeckCard.cardcolor == "Blue") { Console.ForegroundColor = ConsoleColor.Blue; }
            if (topDeckCard.cardcolor == "Green") { Console.ForegroundColor = ConsoleColor.Green; }
            if (topDeckCard.cardcolor == "Yellow") { Console.ForegroundColor = ConsoleColor.Yellow; }
            Console.WriteLine(topDeckCard.cardcolor + "\t\t" + topDeckCard.cardnumber);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void displayHand()
        {
            for (int i = 0; i < playersHand.Count; i++)
            {
                string color = i + 1 + ": " + playersHand[i].cardcolor;
                string number = $"{playersHand[i].cardnumber}";
                if (playersHand[i].cardcolor == "Red") { Console.ForegroundColor = ConsoleColor.Red; }
                if (playersHand[i].cardcolor == "Blue") { Console.ForegroundColor = ConsoleColor.Blue; }
                if (playersHand[i].cardcolor == "Green") { Console.ForegroundColor = ConsoleColor.Green; }
                if (playersHand[i].cardcolor == "Yellow") { Console.ForegroundColor = ConsoleColor.Yellow; }
                Console.WriteLine(color.PadRight(16) + number);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void playCard()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            int userInput = Convert.ToInt32(Console.ReadLine());
            userInput--;
            Console.ForegroundColor = ConsoleColor.White;
            if (playersHand[userInput].cardcolor != topDeckCard.cardcolor && playersHand[userInput].cardnumber != topDeckCard.cardnumber)
            {
                Console.WriteLine("You cannot play that card!\nPlease try again: ");
                Thread.Sleep(500);
            }
            else
            {
                playersHand.RemoveAt(userInput);
            }
        }
        public void drawCard()
        {
            Card placeholderCard = new Card();
            Card newCard = new Card() { cardnumber = placeholderCard.cardNumber(), cardcolor = placeholderCard.cardColor() };
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
            for (int i = 0; i < playersHand.Count + 1; i++)
            {
                if (playersHand[i].cardcolor != topDeckCard.cardcolor && playersHand[i].cardnumber != topDeckCard.cardnumber)
                {
                    if (i == playersHand.Count + 1)
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