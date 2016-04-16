using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAlpha
{
    class CardDeal : DeckFunctionality
    {
        //Creates an array for the playerhand
        private CardSuitAndValue[] playerhand;

        //Creates an array for the computerhand
        private CardSuitAndValue[] computerhand;

        //Creates an array for the sortedPlayerHand
        private CardSuitAndValue[] sortedPlayerHand;

        //Creates an array for the sortedComputerHand
        private CardSuitAndValue[] sortedComputerHand;

        //Function to Deal and sort the cards of the player and computer's hand 
        public CardDeal()
        {
            playerhand = new CardSuitAndValue[5];
            sortedPlayerHand = new CardSuitAndValue[5];
            computerhand = new CardSuitAndValue[5];
            sortedComputerHand = new CardSuitAndValue[5];

        }

        // PRECONDITIONs: The Cards have been created
        // POSTCONDITIONs: Determines what goes on when the program "deals" the cards
        public void Deal()
        {
            //Makes and shuffles a card deck
            setupDeck();

            //Gets the hand for the computer and player
            gethand();

            //Sorts the cards of the computer and player
            sortcards();

            //Displays the cards of the computer and player 
            displaycards();

            //Checks the cards of the computer and player
            checkhands();
        }

        // PRECONDITIONs: The Cards have been created 
        // POSTCONDITIONs: Gets the hand of the computer and player
        public void gethand()
        {
            //Gets 5 cards from the deck for the players
            for (int i = 0; i < 5; i++)
                playerhand[i] = getDeck[i];

            //Gets 5 cards from the deck for the computer
            for (int i = 5; i < 10; i++)
                computerhand[i-5] = getDeck[i];
        }

        // PRECONDITIONs: The Cards have been dealt 
        // POSTCONDITIONs: Sorts the cards of the computer and player
        public void sortcards()
        {
            //Orders the player's hand based around the cards value
            var queryPlayer = from hand in playerhand
                              orderby hand.MyValue
                              select hand;

            //Orders the computer's hand based around the cards value
            var queryComputer = from hand in computerhand
                              orderby hand.MyValue
                              select hand;

            //Sorts the cards in the Players hands
            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            //Sorts the cards in the Computer hands
            index = 0;
            foreach (var element in queryComputer.ToList())
            {
                sortedComputerHand[index] = element;
                index++;
            }
        }

        // PRECONDITIONs: Cards have been dealt and sorted
        // POSTCONDITIONs: Determines what's displayed 
        public void displaycards()
        {
            Console.Clear();
            // X coordinate for the horizontal posisition of the cursor
            int x = 0;

            // Y coordinate for the verticle posisition of the cursor
            int y = 1; 
             

            //Changes the color of the Value and Suit of the player's hand to red
            Console.ForegroundColor = ConsoleColor.Red;

            //Writes a line to show which hand is the players hand
            Console.WriteLine("Player's hand");

            //Creates and sorts the cards for the players
            for (int i = 0; i < 5; i++)
            {
                //Creates the Outline of the computer's hards
                CardCreation.CardCreationOutline(x, y);

                // Creates the Suit and Value for the player's hand
                CardCreation.CardCreationSuitValue(sortedPlayerHand[i], x, y);
                
                //Moves each card to the right once it's created
                x++;
            }

            //Makes it so the computer cards are below the players
            y = 15; 

            //This resets the position for the computer's cards
            x = 0; 

            //Sets the cursor position for where the computer's hand will begin to display on the console
            Console.SetCursorPosition(x, 14);

            //Changes the color of the Value and Suit of the computer's hand to blue
            Console.ForegroundColor = ConsoleColor.Blue;

            //Writes a line to show which hand is the computer's hand
            Console.WriteLine("Computer's hand");

            //Creates and sorts the cards for the computer's 
            for (int i = 5; i < 10; i++)
            {
                //Creates the Outline of the computer's hards
                CardCreation.CardCreationOutline(x, y);

                // Creates the Suit and Value for the computer's hand
                CardCreation.CardCreationSuitValue(sortedComputerHand[i - 5], x, y);

                //Moves each card to the right once it's created
                x++;
            }

        }


        // PRECONDITIONs: The Cards have been dealt and sorted
        // POSTCONDITIONs: The hands of the players and computers is created and checked by gooing through the constructor
        public void checkhands()
        {          
            //Player's hand is made an object so it can be checked 
            CheckHand playerhandCheck = new CheckHand(sortedPlayerHand);

            //Computer's hand is made an object so it can be checked 
            CheckHand computerrhandCheck = new CheckHand(sortedComputerHand);

            //Gets player's hand
            Hand playerhand = playerhandCheck.HandCheck();

            //Gets Computer's hands
            Hand computerhand = computerrhandCheck.HandCheck();

            //Display player's hand
            Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playerhand);

            //Display computer's hand
            Console.WriteLine("Computer's Hand: " + computerhand);

            //Determines and checks the win condition for the player
            if (playerhand > computerhand)
            {
                Console.WriteLine("Player WINS!");
            }

            //Determines and checks the win condition for the computer
            else if (playerhand < computerhand)
            {
              
                Console.WriteLine("Computer WINS!");
            }

            //Determines and checks what happens when the intial hands worth are the same
            else 
            {
                //Checks between computer and player to determine which hand has a higher value
                if (playerhandCheck.HandValue.Total > computerrhandCheck.HandValue.Total)
                    Console.WriteLine("Player Wins!");
                else if (playerhandCheck.HandValue.Total < computerrhandCheck.HandValue.Total)
                    Console.WriteLine("Computer Wins!");

                //Determine the win, lose and draw condition based on the computers and player's hand value.
                else if (playerhandCheck.HandValue.HighCard > computerrhandCheck.HandValue.HighCard)
                    Console.WriteLine("Player Wins!");
                else if (playerhandCheck.HandValue.HighCard < computerrhandCheck.HandValue.HighCard)
                    Console.WriteLine("Computer Wins!");
                else
                    Console.WriteLine("Draw, no one wins!");
            }

        }
    }
}
