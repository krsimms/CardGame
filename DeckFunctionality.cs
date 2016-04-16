using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAlpha
{
    //Class for giving the deck of cards the functionality of creating the deck and card shuffling 
    class DeckFunctionality: CardSuitAndValue 
    {
        //Instantiates the number of cards in the deck
        const int NUM_OF_CARDS = 52;

        // Creates an array for the playing cards
        private CardSuitAndValue[] deck;


        // POSTCONDITIONs: Creates the object of the number of cards
        public DeckFunctionality()
        {
            deck = new CardSuitAndValue[NUM_OF_CARDS];
        }//End of Deckfunctionality Function

        // POSTCONDITIONs: gets the current deck
        public CardSuitAndValue[] getDeck
        {
            get
            {
                return deck;
            }

        }//End of CardSuitAndValue Function

        // PRECONDITIONs: Deck is instantiated 
        // POSTCONDITIONs: Creates a deck of fifty-two cards with the suits and values
        public void setupDeck()
        {
            int i = 0;

            //Foreach loop that creates each individual deck of cards both hands pull from
            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    deck[i] = new CardSuitAndValue { MySuit = s, MyValue = v };
                    i++;
                }
            }

            //Shuffles the cards after the decks creation
            ShuffleCards();
        }//End of SetupDeck function

        // PRECONDITIONs: Deck is instantiated 
        // POSTCONDITIONs: Shuffles the deck of cards
        public void ShuffleCards()
        {
            //Allows for a sudo-random functionality to be applied to the shuffling function
            Random rand = new Random();
            CardSuitAndValue temp;

            //Foor loop that runs the shuffling effect one hundread times. 
            for (int shuffleTimes = 0; shuffleTimes < 100; shuffleTimes++)
            {
                for (int i = 0; i < NUM_OF_CARDS; i++)
                {
                    //Performs the functionality of swaping the cards and shuffling them
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }//end of ShuffleCards function

    }
}
