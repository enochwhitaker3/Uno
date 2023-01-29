using System;
using System.Security.Cryptography;

namespace Card
{
    public class card
    {
        public string? cardcolor { get; set; }
        public string? cardattribute { get; set; }
        public string cardAttribute()
        {
            Random rnd = new Random();  
            int cardNubmer = rnd.Next(0,11);
            var rndAttribute = new List<string> {"1","2","3","4","5","6","7","8","9","+2","%"};
            return rndAttribute[cardNubmer];
        }
        public string cardColor()
        { 
            Random rnd = new Random();
            int cardColor = rnd.Next(0,5);
            var rndColor = new List<string> {"Red", "Blue", "Green", "Yellow", "WILD"};
            return rndColor[cardColor];
        }
    }
}
