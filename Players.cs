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
            Console.WriteLine(topDeckCard.cardcolor + "\t\t" + topDeckCard.cardnumber);
        }
        public void displayHand()
        {
            for (int i = 0; i < playersHand.Count; i++)
            {
                string color = i + 1 + ": " + playersHand[i].cardcolor;
                string number = $"{playersHand[i].cardnumber}";
                Console.WriteLine(color.PadRight(16) + number);
            }
        }
        public void playCard()
        {
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (playersHand[userInput].cardcolor != topDeckCard.cardcolor && playersHand[userInput].cardnumber != topDeckCard.cardnumber)
            {
                Console.WriteLine("You cannot play that card!\nPlease try again: ");
                Thread.Sleep(500);
            }
            else
            {
                playersHand.RemoveAt(userInput);
                Console.WriteLine($"{playersHand[userInput].cardcolor} {playersHand[userInput].cardnumber} was played succesfully");
  
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
                    if (i == playersHand.Count - 2)
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