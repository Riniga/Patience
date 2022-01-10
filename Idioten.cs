using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patience
{
    internal class Idioten
    {
        private Deck deck;
        private Deck[] stack = new Deck[4];
        private Deck rest;

        public Idioten(Deck deck)
        {
            this.deck = deck;
            for (int i = 0; i < stack.Length; i++) { stack[i] = new Deck(); stack[i].Clear(); }
            rest = new Deck();
            rest.Clear();
        }

        public bool Play()
        {
            while (deck.Count > 0)
            {
                Deal();
                //Print();
                PlayRound();
                //Print();
            }
            if (rest.Count > 47) return true;
            return false;
        }

        private bool MoveToEmptySlot()
        {
            var result = false;
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i].Count == 0)
                {
                    var stackId = FindStack();
                    if (stack[stackId].Count() <= 1) continue;
                    stack[i].Push(stack[stackId].Pop());
                    result= true;
                }
            }
            return result;
        }

        private int FindStack()
        {
            // Intelligent stack finder...
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i].Count <= 1) continue;
                if (IsTakeable(stack[i].ElementAt(stack[i].Count - 2))) return i ;
            }
            return GetLongestStack();
        }

        private int GetLongestStack()
        {
            int longest = 0;
            for (int i = 1; i < stack.Length; i++)
            {
                if (stack[i].Count > stack[longest].Count) longest = i;
            }
            return longest;
        }

        private bool IsTakeable(PlayingCard currentCard)
        {
            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i].Count == 0) continue;
                if (currentCard.Suit == stack[i].Peek().Suit)
                    if (currentCard.Rank < stack[i].Peek().Rank)
                        return true;

            }
            return false;
        }

        private void PlayRound()
        {
            for (int i = 0; i < stack.Length; i++)
            {
                TryRemove(i);
            }
            if (MoveToEmptySlot()) PlayRound();

            for (int i = 0; i < stack.Length; i++)
            {
                if (stack[i].Count == 0) continue;
                if (IsTakeable(stack[i].Peek()))
                {
                    PlayRound();
                    return;
                }
            }
        }

        private bool TryRemove(int currentStack)
        {
            if (stack[currentStack].Count == 0) return false;
            var currentCard = stack[currentStack].Peek();
            if (IsTakeable(currentCard))
            {
                rest.Push(stack[currentStack].Pop());
            }
            return false;
        }

        private void Deal()
        {
            for (int i = 0; i < stack.Length; i++)
                stack[i].Push(deck.Pop());
        }


        internal void Print()
        {
            int count = stack[GetLongestStack()].Count();
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < count; i++)
            {
                Console.Write((stack[0].Count > i)?stack[0].ElementAt(i).ToString() + "\t" : "EMPTY\t\t");
                Console.Write((stack[1].Count > i)?stack[1].ElementAt(i).ToString() + "\t" : "EMPTY\t\t");
                Console.Write((stack[2].Count > i)?stack[2].ElementAt(i).ToString() + "\t" : "EMPTY\t\t");
                Console.Write((stack[3].Count > i)?stack[3].ElementAt(i).ToString()  : "EMPTY");
                Console.WriteLine();
            }

            //Console.WriteLine("\r\nRest\r\n--------------");
            //rest.Print();


        }

    }
}
