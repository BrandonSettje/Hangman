using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
       
        public static Random rng = new Random();
        static string pName = string.Empty;
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 40);
            Console.SetWindowSize(80, 40);
            Console.WriteLine("   ************************    ");
            Console.WriteLine("   *      HANGMAN!        *    ");
            Console.WriteLine("   *   Hardcore Mode!     *    ");
            Console.WriteLine("   ************************    ");
            string greeting = ("Let's play some Hangman! This hangman can be tough!");
            for (int i = 0; i < greeting.Length; i++)
            {
                Console.Write(greeting[i].ToString());
                System.Threading.Thread.Sleep(80);
            }
            System.Threading.Thread.Sleep(800);
            Console.WriteLine();
            Console.WriteLine("   Hope you've studied up on your words!");
            //user types in a name
            Console.Write("Enter a name: ");
            pName = Console.ReadLine();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine();
            string pNameInp = ("Good luck " + pName + "!" + @" Your head is foggy but your 
            name startled booming over the speaker had woken you up. The speakers blare again, 
            'The rules are simple...guess the word and the random person lives!'. The deep 
            black covers are thrust off and sitting in front of you is an empty rope. TO the 
            side a board, slightly angled, with a box of tiles sitting on the ground. A man in 
            black starts picking tiles...");
            for (int i = 0; i < pNameInp.Length; i++)
            {
                Console.Write(pNameInp[i].ToString());
                System.Threading.Thread.Sleep(50);
            }
            Hangman();
        }
        /// <summary>
        /// Hangman function to put together the functions to run through the list, and tell user if they are right or wrong
        /// </summary>
        static void Hangman()
        {
            //Number of lives
            int numberOfGuessesLeft = 7;
            string lettersGuessed = string.Empty;
            bool playing = true;
            //word list for computer to select from
            List<string> wordSet = new List<string>() { "supercalifragilisticexpialidocious", "antidisestablismentarianism", "dogs", "Colorado", 
                "psychotherapy", "ambidextrously", "copyright", "discover", "computer", "Dermatology", "internal", "hospitable", "lumberjack", "Wolverine" };
            string wordToGuess = wordSet[rng.Next(0, wordSet.Count())];
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine();
            System.Threading.Thread.Sleep(400);
            Console.WriteLine();
            //make user think the comouter is 'thinking'
            Console.WriteLine("Coming up with a hardcore word for you!");
            System.Threading.Thread.Sleep(2000);

            while (playing)
            {
                //display the round info
                roundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                if (numberOfGuessesLeft == 6)
                {
                    //building artwork if they get guesses wrong
                    Console.WriteLine();
                    Console.WriteLine("BRING OUT THE CONTENSTANT'S BROTHER!");
                    Console.WriteLine();
                    Console.WriteLine(@" 
                                    ____________
                                   |           
                                   |           
                                   |          
                                   |        
                                   |           
                                   |     ___   
                                   |    |   |     
                                   |    |   |    
                                   |____|___|_________");

                }
                if (numberOfGuessesLeft == 5)
                {
                    Console.Clear();
                    roundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                    Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |         
                                   |        
                                   |         
                                   |       
                                   |    _____     
                                   |    |   |    
                                   |____|___|_________");
                }
                if (numberOfGuessesLeft == 4)
                {
                    Console.Clear();
                    roundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                    Console.WriteLine();
                    Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |    (   ) 
                                   |      | 
                                   |           
                                   |       
                                   |    _____     
                                   |    |   |    
                                   |____|___|_________");
                }
                if (numberOfGuessesLeft == 3)
                {
                    Console.Clear();
                    roundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                    Console.WriteLine();
                    Console.WriteLine("He is writhing in pain " + pName + " ... WRITHING!!");
                    Console.WriteLine();
                    Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |       
                                   |    _____    
                                   |    |   |    
                                   |____|___|_________");
                }
                if (numberOfGuessesLeft == 2)
                {
                    Console.Clear();
                    roundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                    Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]___    
                                   |    |   |    
                                   |____|___|_________");
                }
                if (numberOfGuessesLeft == 1)
                {
                    Console.Clear();
                    roundInfo(lettersGuessed, wordToGuess, numberOfGuessesLeft);
                    Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                }
                Console.WriteLine();
                string input = getUserInput(lettersGuessed);
                //puts it to lower and asks if there are less than two
                if (input.Length > 2 && input.ToLower() == wordToGuess.ToLower())
                {
                    playing = true;
                }
                else if (input.Length == 1)
                {
                    lettersGuessed += input;
                    //asks if letters are matching
                    if (wordToGuess.ToUpper().Contains(input.ToUpper()))
                    {
                        if (!getMaskedWord(lettersGuessed, wordToGuess).Contains("_"))
                        {
                            playing = false;
                        }
                    }
                    else
                    {
                        numberOfGuessesLeft--;
                        playing = (numberOfGuessesLeft > 0);
                    }
                }
                    //check if the word is done
                else
                {
                    if (input.ToLower() == wordToGuess.ToLower())
                    {
                        playing = true;
                    }
                    else
                    {
                        numberOfGuessesLeft--;
                        playing = (numberOfGuessesLeft > 0);
                    }
                }
            }
            if (numberOfGuessesLeft > 0)
            {
                //PLayer won, with some artwork!
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                System.Threading.Thread.Sleep(1100);
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |       <---<<
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |   <---<<  
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |<---<<  
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |  <---<<  
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |    
                                   |    (   )  Im free!   
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");

                Console.WriteLine("Wow, you beat Hardcore Mode.");
                Console.WriteLine("You and your brother have ten seconds to get out of here!");
                Console.WriteLine("The word is: " + wordToGuess.ToUpper());
            }
            else
            {
                //Player loss
                Console.Clear();
                Console.WriteLine(@" 
                                    ____________
                                   |      |     
                                   |      |     
                                   |    (   )     
                                   |   ><-|-><    
                                   |      |      
                                   |      | 
                                   |    _]_[_   
                                   |    |   |    
                                   |____|___|_________");
                System.Threading.Thread.Sleep(300);
                Console.WriteLine("Pull the lever, Executioner!");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine(@"
                                    ____________
                                   |      |     
                                   |      |
                                   |      |
                                   |      | 
                                   |    (x x)     
                                   |   ><-|-><    
                                   |      |      
                                   |     ] [    
                                   |                       
                                   |__________________");
                System.Threading.Thread.Sleep(1800);
                Console.WriteLine("Really? That word was easy " + pName + ". Now you've gone and hung your brother.");
                Console.WriteLine("You must live with that for the rest of your days.");
            }
            //play again check
            Console.WriteLine();
            string anotherGame = "Would you like to play again?";
            for (int i = 0; i < anotherGame.Length; i++)
            {
                Console.Write(anotherGame[i].ToString());
                System.Threading.Thread.Sleep(60);
            }
            Console.WriteLine();
            Console.Write("(Y or N) ");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain == "Y")
            {
                Hangman();
            }
        }
        /// <summary>
        /// Puts round info in where necessary
        /// </summary>
        /// <param name="lettersGuessed">the letters guessed by human</param>
        /// <param name="wordToGuess">word selected from comp</param>
        /// <param name="guessesLeft">how many guess player has left</param>
        static void roundInfo(string lettersGuessed, string wordToGuess, int guessesLeft)
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(getMaskedWord(lettersGuessed, wordToGuess));
            Console.WriteLine();
            Console.WriteLine("# of guesses left: " + guessesLeft + "   Letters guessed: " + lettersGuessed.ToUpper());

        }
        /// <summary>
        /// Gets word and masks it for player
        /// </summary>
        /// <param name="lettersGuessed">the letter guessed</param>
        /// <param name="wordToGuess">word selected by computer</param>
        /// <returns></returns>
        static string getMaskedWord(string lettersGuessed, string wordToGuess)
        {
            string returnString = string.Empty;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                //Checks with letters in word selected by computer
                string currentLetter = wordToGuess[i].ToString().ToUpper();
                if (lettersGuessed.ToUpper().Contains(currentLetter))
                {
                    returnString += currentLetter + " ";
                }
                else
                {
                    returnString += "_ ";
                }
            }
            return returnString;
        }
        /// <summary>
        /// checks to validate user input
        /// </summary>
        /// <param name="lettersGuessing">letter guessed by user</param>
        /// <returns></returns>
        static string getUserInput(string lettersGuessing)
        {

            returnString = string.Empty;
            bool guessValidator = true;
            do
            {
                Console.WriteLine("Enter a guess:");
                returnString = Console.ReadLine();
                if (returnString.Length > 1)
                {
                    //more than one character, the word check is elsewhere
                    Console.WriteLine();
                    Console.WriteLine("Please guess 1 letter at a time!");
                    guessValidator = false;
                }
                    //if its one char long, checks for number
                else if (returnString.Length == 1)
                {
                    guessValidator = char.IsLetter(returnString[0]);
                    if (guessValidator)
                    {
                        //if the player has already used that letter
                        Console.WriteLine();
                        Console.WriteLine("You have already chosen that letter!");
                        guessValidator = !(lettersGuessing.ToUpper().Contains(returnString.ToUpper()));
                    }
                    else
                    {
                        //if its anything else
                        Console.WriteLine();
                        Console.WriteLine("Please guess a letter!");
                    }
                }
                    //if user didn't put anything
                else if (returnString.Length == 0)
                {
                    Console.WriteLine("Enter a letter.");
                    guessValidator = false;
                }
            }
            //while returning a false, type invalid
            while (guessValidator == false);
            Console.WriteLine("invalid");
            return returnString;
        }
        static string returnString = string.Empty;
    }
        

}
