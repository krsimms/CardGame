using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAlpha
{
    // Class for determining the cards suit and value
    class CardSuitAndValue
    {
        //Creates the four suits for the cards
        public enum Suit
        {
            Hearts, Spades, Diamonds, Clubs
        }

        //Creates the Value for the cards starting at Ace for one
        public enum Value
        {
            Ace, Two, Three, Four, Five, Six, Seven,
            Eight, Nine, Ten, Jack, Queen, King
        }

        //USed to determine properties of the Suit and Values for other classes
        public Suit MySuit { get; set; }
        public Value MyValue { get; set; }
    }
}
