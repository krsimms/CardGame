using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAlpha
{
    //Creates each type of hand that can be made and measured 
    public enum Hand
    {
        nothing, OnePair, TwoPair, ThreeKind, Straight, Flush, FullHouse,  FourKind
    }

    //Gives the value of the card hands
    public struct HandValue
    {
        //Integer for the Total card Value
        public int Total { get; set;}

        //Integer for the Highest card in either hand in the vent of a tie
        public int HighCard { get; set; }
    }

    //Class for checking the type of hand the computer or play has
    class CheckHand
    {

        //Integer variable for the result of the heart suit
        private int HeartSum;

        //Integer variable for the result of the Diamond suit
        private int DiamondSum;

        //Integer variable for the result of the Club suit
        private int ClubSum;

        //Integer variable for the result of the Spade suit
        private int SpadeSum;

        private CardSuitAndValue[] cards;
        private HandValue handValue;

        //Checks the hand based around the value of each suit
        public CheckHand(CardSuitAndValue[] sortedHand)
        {
            HeartSum = 0;
            DiamondSum = 0;
            ClubSum = 0;
            SpadeSum = 0;
            cards = new CardSuitAndValue[5];
            Cards = sortedHand;
            handValue = new HandValue();
            
        }

        //Get's the value of the Hand
        public HandValue HandValue
        {
            get { return handValue;  }
            set { handValue = value; }
        }

        //Get'sthe 5 cards of the hand and determines their value
        public CardSuitAndValue[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
          
        }

        //Checks for the Type of hands and returns that those hands have occured
        public Hand HandCheck()
        {
            //Gets the hand based on the the Number of each suit 
            getnumberofSuit();
          
            if (fourofKind())
                return Hand.FourKind;

            else if (FullHouse())
                return Hand.FullHouse;

            else if (flush())
                return Hand.Flush;

            else if (Straight())
                 return Hand.Straight;

            else if (ThreeofKind())
                 return Hand.ThreeKind;

            else if (TwoPair())
                 return Hand.TwoPair;

            else if (OnePair())
                  return Hand.OnePair;

            //If nothing comes up, it returns the value of the highest card
            handValue.HighCard = (int)cards[4].MyValue;
            return Hand.nothing;

        }

        //Get's value of the Suit
        private void getnumberofSuit()
        {
            foreach (var element in Cards)
            {
                if (element.MySuit == CardSuitAndValue.Suit.Hearts)
                    HeartSum++;
                else if (element.MySuit == CardSuitAndValue.Suit.Diamonds)
                    DiamondSum++;
                else if (element.MySuit == CardSuitAndValue.Suit.Clubs)
                    ClubSum++;
                else if (element.MySuit == CardSuitAndValue.Suit.Spades)
                    SpadeSum++;
            }
        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to be a four of a kind
        private bool fourofKind()
        {
            //Determines if the cards make a 4 of a kind and has the last card be the "highest" card in the event of a tie
            if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;

        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to be a Full House
        private bool FullHouse()
        {
            //Determines if the cards make a Full House and has the last card be the "highest" card in the event of a tie
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue) ||
                   (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue))
            {
                handValue.Total = (int)(cards[0].MyValue) + (int)(cards[1].MyValue) + (int)(cards[2].MyValue) +
                    (int)(cards[3].MyValue) + (int)(cards[4].MyValue);
                return true;
            }
            return false;

        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to be a Flush
        private bool flush()
        {
            //Determines if the cards make a Flush and has the last card be the "highest" card in the event of a tie
            if (HeartSum == 5 || DiamondSum == 5 || ClubSum == 5 || SpadeSum == 5)
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to be a Straight
        private bool Straight()
        {
            //Determines if the cards make a Straight and has the last card be the "highest" card in the event of a tie
            if (cards[0].MyValue + 1 == cards[1].MyValue &&
                cards[1].MyValue + 1 == cards[2].MyValue &&
                cards[2].MyValue + 1 == cards[3].MyValue &&
                cards[3].MyValue + 1 == cards[4].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to be a Three of a Kind
        private bool ThreeofKind()
        {
            //Determines if the cards make a Three of a Kind and has the last card be the "highest" card in the event of a tie
            if ((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[3].MyValue) ||
            (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue))
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to be a Two Pair
        private bool TwoPair()
        {
            //Determines if the cards make a Two Pair and has the last card be the "highest" card in the event of a tie
            if (cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[0].MyValue == cards[1].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }

        // PRECONDITIONs: The Cards have been created and suited
        // POSTCONDITIONs: After being evaluted the hand is determined to have One Pair
        private bool OnePair()
        {
            //Determines if the cards make One Pair and has the last card be the "highest" card in the event of a tie
            if (cards[0].MyValue == cards[1].MyValue)
            {
                handValue.Total = (int)cards[0].MyValue*2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue * 2;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[3].MyValue * 2;
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }

            return false;
        }

    }
}
