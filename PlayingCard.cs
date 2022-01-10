using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patience
{
    public class PlayingCard
    {
        public Suit Suit{ get; set; }
        public Rank Rank{ get; set; }
        public PlayingCard(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public override string ToString()
        {
            if (Rank == Rank.ACE) return "Ace of " + PlayingCard.GetString(Suit);
            return PlayingCard.GetString(Suit) + "-" + PlayingCard.GetString(Rank);
        }

        private static string GetString(Suit suit)
        {
            string lower = suit.ToString().ToLower();
            return ToStringFirstletterUpper(lower);
        }
        private static string GetString(Rank rank)
        {
            string lower = rank.ToString().ToLower();
            return ToStringFirstletterUpper(lower);
        }
        private static string ToStringFirstletterUpper(string input)
        {
            return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
        }
    }
}
