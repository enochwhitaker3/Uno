using System;
using Card;
using Deck;
using Player;

namespace GameLogic
{
    class gamelogic 
    {
        public bool canPlay(deck deck, player player)
        {
            for (int i = 0; i <= player.PlayersHand.Count - 1; i++)
            {
                if (player.PlayersHand[i].cardcolor != deck.getTopDeck().cardcolor && player.PlayersHand[i].cardattribute != deck.getTopDeck().cardattribute && player.PlayersHand[i].cardcolor != "WILD")
                {
                    if (i == player.PlayersHand.Count - 1)
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
        public bool checkWin(player player)
        {
            
            if (player.PlayersHand.Count == 0)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
        public int specialCase(card card)
        {
            if (card.cardattribute == "+2")
            {
                return 1;
            }
            else if (card.cardattribute == "%")
            {
                return 2;
            }
            return 0;
        }
    } 
}