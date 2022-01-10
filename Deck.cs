using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patience
{
    public class Deck : Stack<PlayingCard>
    {
        public bool AceHigh = true;
        public Deck()
        {
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                for (int i = 0; i < 13; i++)
                {
                    Push(new PlayingCard(suit, (Rank)i ));
                }
            }
        }
        public void Scramble()
        {
            Random random = new Random();
            var cards = this.ToList();
            Stack<PlayingCard> result= new Stack<PlayingCard> ();
            while (cards.Count > 0)
            { 
                int id = random.Next(cards.Count);
                result.Push(cards.ElementAt(id));
                cards.RemoveAt(id);
            }
            Clear();
            foreach (var item in result) Push(item);
        }
        public void Print()
        {
            foreach (var card in this)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
