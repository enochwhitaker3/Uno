using System;
using System.Security.Cryptography;

namespace Cards
{
    public class Card
    {
        public string? cardcolor { get; set; }
        public int cardnumber { get; set; }
        public int cardNumber()
        {
            Random rnd = new Random();  
            int cardnubmer = rnd.Next(0,10);
            return cardnubmer;
        }
        public string cardColor()
        { 
            Random rnd = new Random();
            int cardColor = rnd.Next(0,4);
            var rndColor = new List<string> {"Red", "Blue", "Green", "Yellow" };
            return rndColor[cardColor];
        }
    }
}
