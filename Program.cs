// Code written by Therese Bruzell
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Project
{
    class Program{

        // Method that runs  when game is lost
        static void GameOver(){
            Console.Write(" \n *GAME OVER* \n");
            Console.Write("You didn't figure out the word and the man hung \n");
        }

         static void Main(string[] args){

            // Boolean that controls whether application should loop or not
            bool appIsRunning = true;

            // While loop that reruns entire application
            while(appIsRunning){
                Console.Clear();

                // Heading
                Console.WriteLine("\n*HANG MAN*");
                Console.WriteLine("**************** \n");

                // Meny
                Console.WriteLine("What do you want to do? \n");
                Console.WriteLine("1: Start a game \n2: Rules \nQ: Quit");

                // Create instance of wordhandler class
                Wordhandler wordhandler = new Wordhandler();

                var answer = Console.ReadLine();

                    // Switch case for inputted command
                    switch(answer){
                        case "1":
                            // A list for inputted letters
                            var guessed = new List<string>();

                            // Generate word and count letters of it
                            string word = wordhandler.RandomizeWord();
                            int wordLength = word.Count();

                            bool gameIsRunning = true;
                            int wrongGuesses = 0;

                            // While-loop for running game
                            while(gameIsRunning){

                                Console.Clear();

                                // Heading
                                Console.WriteLine("\n*HANG MAN*");
                                Console.WriteLine("_______________________ \n");
                                Console.WriteLine("Figure out the hidden word before the innocent man is hung! \n");

                                // Creates a string from generated word and write it out at underlines or letters if guessed-list contains the right letters
                                string wordDisplay = "";
                                for (int i = 0; i < wordLength; i++)
                                {
                                    if (guessed.Contains(word[i].ToString())) { 
                                        wordDisplay = wordDisplay + " " + word[i].ToString() + " ";
                                    }else{
                                        wordDisplay = wordDisplay + " _ ";
                                    }
                                }

                                Console.WriteLine("The word is " + wordDisplay + " \n");
                                
                                // If all letters has been guessed and found
                                if(!wordDisplay.Contains("_")){
                                    Console.WriteLine("Congratulations! You beat the game!");
                                    break;
                                }

                                // Write out players guessed letters if there are any
                                if(guessed.Count != 0){
                                    string rowOfGuesses = "";
                                    guessed.ForEach(i => rowOfGuesses = rowOfGuesses + " " + i);
                                    Console.WriteLine("Your guesses:" + rowOfGuesses + "\n");
                                }

                                // Write out how many wrong guesses the user has left
                                Console.WriteLine("You have " + (10 - wrongGuesses) + " wrong guesses left \n");

                                // In game meny
                                Console.WriteLine("CHOOSE AN ACTION");
                                Console.WriteLine("\n1: Guess a letter \n2: Guess word \nQ: Exit to menu");
                                var gameChoice = Console.ReadLine();

                                // Switch case for in game choice
                                switch(gameChoice){
                                    
                                    //If player chooses to guess single letters 
                                    case "1":
                                        Console.WriteLine("\n Guess a letter ");
                                        var gameAnswer = Console.ReadLine();

                                        // Run if inputted info isn't null
                                        if(gameAnswer != null){
                                            Console.WriteLine("\n==================\n");

                                            // Check if input contains anything but letters or more than one letter
                                            if(!Regex.IsMatch(gameAnswer, @"^[a-zA-Z]+$") || gameAnswer.Length>1){
                                                Console.WriteLine("Your input was invalid. Use only letters and one at a time.");
                                                Console.WriteLine("Press any key to try again\n");
                                                Console.ReadKey(true);
                                                break;
                                            }
                                            try{
                                                // convert inputted information to lowercase
                                                gameAnswer.ToLower();

                                                //Integer that shows how many times the letter match in the word
                                                int timesMatched = Regex.Matches(word,gameAnswer).Count;
                                                
                                                // Check if inputted letter already has been guessed
                                                if(guessed.Contains(gameAnswer)){
                                                    Console.WriteLine("You have already made a quess for letter " + gameAnswer + ". Please make another guess.");
                                                    Console.WriteLine("Press any key to move on \n \n");
                                                    Console.ReadKey(true);

                                                // Runs if inputted letter hasn't been guessed before
                                                }else{

                                                    // Code that runs if the letter matches
                                                    if(timesMatched > 0){

                                                        Console.WriteLine("The letter "+ gameAnswer + " occurs " + timesMatched + " times in the word! \n \n");
                                                        guessed.Add(gameAnswer);
                                                        Console.WriteLine("Press any key to continue \n \n");
                                                        Console.ReadKey(true);

                                                    // Code that runs if letter doesn't match
                                                    }else{

                                                        Console.WriteLine("Too bad! The word doesn't contain the letter " + gameAnswer + "\n \n");
                                                        guessed.Add(gameAnswer);
                                                        wrongGuesses ++ ;

                                                        // Checks if you've guessed wrong ten times and ends game if you have.
                                                        if(wrongGuesses == 10){
                                                            GameOver();
                                                            Console.WriteLine("Press any key to continue \n \n");
                                                            Console.ReadKey(true);
                                                            gameIsRunning = false;
                                                        }else{
                                                            Console.WriteLine("Press any key to continue \n \n");
                                                            Console.ReadKey(true);
                                                        }

                                                    }
                                                }
                                            }
                                            catch{};
                                        }else{
                                            Console.WriteLine("Invalid answer");
                                        }
                                    break;

                                    // Run if player chooses to guess whole word
                                    case "2":
                                        Console.WriteLine("\n Guess a word");
                                        var gameAnswerWord = Console.ReadLine();

                                        // Check if input isn't null
                                        if(gameAnswerWord != null){
                                            Console.WriteLine("========================== \n \n");
                                            try{

                                                // Turns inputted info to lowercase
                                                gameAnswerWord.ToLower();

                                                // Runs if answer is matching generated word
                                                if(gameAnswerWord == word){

                                                    Console.WriteLine("Correct! The word was " + word + "\nYou saved the innocent man!");
                                                    Console.WriteLine("Press any key to exit to menu");
                                                    Console.ReadKey(true);
                                                    gameIsRunning = false;

                                                // Runs if answer is not matching generated word
                                                }else{

                                                    Console.WriteLine("Sorry, wrong answer. The word was " + word);
                                                    GameOver();
                                                    Console.WriteLine("Press any key to exit to menu ");
                                                    Console.ReadKey(true);
                                                    gameIsRunning = false;

                                                }
                                            }
                                            catch{};
                                        }else{
                                            Console.WriteLine("Invalid answer. Try again.");
                                        }
                                    break;

                                    // Runs if player chooses exit to meny
                                    case "q":
                                    case "Q":
                                        gameIsRunning = false;
                                    break;
                                    
                                    default:
                                    Console.WriteLine("Wrong commando");
                                    break;
                                }
                            }

                        break;
                        
                        // Runs if user chooses to view rules
                        case "2":
                            Console.Clear();
                            Console.WriteLine("\n*HANG MAN*");
                            Console.WriteLine("_______________________ \n");
                            Console.WriteLine("RULES \n");

                            Console.WriteLine("The rules are simple. A word will be generated which you will at first only know the number of letters to.");
                            Console.WriteLine("You will then quess whether a specific letter is in the word or not. If you are right the letter gets put in its correct spot in the word and you can continue guessing.");
                            Console.WriteLine("If you are wrong you get a mark. You may then continue guessing the letters, or the full word if you think you know it. If you guess wrong or get 10 wrong guesses, you lose. If you guess right, you win.");
                            Console.WriteLine("\n Press any key to return to menu.");
                            Console.ReadKey(true);
                        break;

                        // Runs if user choses to exit game
                        case "Q":
                        case "q":
                        //exit application
                        appIsRunning = false;
                        Environment.Exit(0);
                        break;
                        
                        default:
                            Console.WriteLine("Wrong commando");
                        break;
                    }
            }

        }

    } 
}
