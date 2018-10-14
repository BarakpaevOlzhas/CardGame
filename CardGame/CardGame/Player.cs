using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {        
        List<Karta> deck;

        public Player()
        {
            deck = new List<Karta>();
        }

        public void TakeKart(Karta karta)
        {
            deck.Add(karta);
        }

        public Karta GetKart(int index)
        {
            return deck[index];
        }

        public List<Karta> GetDeck()
        {
            return deck;
        }

    }
}
