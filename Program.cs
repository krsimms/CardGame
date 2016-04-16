using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAlpha
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets the windows size for the sake of maintaing the aesthetics of the program
            Console.SetWindowSize(65, 40);

            //Changes the buffer of the window to eliminate Horizontal scroll bar
            Console.BufferWidth = 65;

            //Changes the buffer of the window to eliminate Verticle scroll bar
            Console.BufferHeight = 40;

            //Places the Title of the game on the Window
            Console.Title = "Kyle's Poker Game";

            //Changes the background color to black
            Console.BackgroundColor = ConsoleColor.Black;

            //Changes the Foreground Color to the letters be green 
            Console.ForegroundColor = ConsoleColor.Green;

            //Wrties the intro into the window
            Console.WriteLine("\n\n\n\n\n\n\n\n\t\t Welcome to Neon Poker");
            Console.WriteLine("\n\n\n\n\n\n\t\t Press any key to begin");

            //Allows the user to press any key to continue
            Console.ReadKey(); // Use for intro graphic?

            //Clears the intro from the screen
            Console.Clear();

            //Writes an explanation of the program\game
            Console.WriteLine("\n\n\nWelcome to Neon Pocker. This is a basic poker game created by    Kyle Simms. This program allows the player to play a basic 5 cardhand game of poker with a computer player, the cards are drawn & their value is determined then compared to determine the victor.");
            Console.WriteLine("\n\t Press any key to start the game");
            //Allows the user to press any key to continue
            Console.ReadKey(); // Use for intro graphic?

            //Clears the intro from the screen
            Console.Clear();

            //Creates an 'cd' object to be used to continue or quit the game
            CardDeal cd = new CardDeal();

            //Bool variable to allow player to quit
            bool quit = false;

            //A while loop made to let players to quit the game
            while (!quit)
            {
                //Object gets the 'Deal' function
                cd.Deal();

                //Creates space for player to input their choice
                char selection = ' ';

                //A while loop to give functionality to users input
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Play Again? Y-N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    //If the player type Y the program draws another hand
                    if (selection.Equals('Y'))
                        quit = false;

                    //If the player type N the program quits
                    else if (selection.Equals('N'))
                        quit = true;

                    //If the player input something else the program tells them it's an invalid input
                    else
                        Console.WriteLine("Invalid Selection. Try again");
                }
                        
            }

            //Allows for a pause
            Console.ReadKey();

        }
    }
}
