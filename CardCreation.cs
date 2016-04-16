using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAlpha
{
    class CardCreation
    {
        // PRECONDITIONs: Deck is instantiated 
        // POSTCONDITIONs: Draws the card on the console
        public static void CardCreationOutline(int xcoor, int ycoor)
        {
            //Makes the background color black
            Console.BackgroundColor = ConsoleColor.Black;

            //Makes the card borders the color green 
            Console.ForegroundColor = ConsoleColor.Green;

            //Interger for the x coordinate 
            int x = xcoor * 12;

            //Interger for the y coordinate 
            int y = ycoor;

            //Sets the cursor position
            Console.SetCursorPosition(x, y);

            //Writes the top border of the cards
            Console.Write(" __________\n");

            //for loop to interatively draw the side borders of the cards
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                //if statement to draw the left and right border of the cards
                if (i != 9)
                    Console.WriteLine("|          |"); 
                //else statement to create the bottom edge of the card after 9 increments of the sid eborders
                else
                    Console.WriteLine("|__________|"); 
            }
        }//end of CardCreationOutline function


        // PRECONDITIONs: The Card border has been created 
        // POSTCONDITIONs: The card shows the suit and value of the card in the border 
        public static void CardCreationSuitValue(CardSuitAndValue card, int xcoor, int ycoor)
        {
            char cardSuit =' ';

            //Interger for the x coordinate 
            int x = xcoor * 12;

            //Interger for the y coordinate 
            int y = ycoor;

            //Pulls the symbol from the CodePage and uses them as symbols as well as chaning their colors
            switch (card.MySuit)
            {
                //Gets and sets the symbol of the heart and changes the color of the symbol to red
                case CardSuitAndValue.Suit.Hearts:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                //Gets and sets the symbol of the Diamonds and changes the color of the symbol to red
                case CardSuitAndValue.Suit.Diamonds:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                //Gets and sets the symbol of the Clubs and changes the color of the symbol to black
                case CardSuitAndValue.Suit.Clubs:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                //Gets and sets the symbol of the Spades and changes the color of the symbol to black
                case CardSuitAndValue.Suit.Spades:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }

            //display the Suit symbols and value of the card
            Console.SetCursorPosition(x +5, y + 5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.MyValue);


        }//end of CardCreationSuitValue function
    }
}
