// Code written by Therese Bruzell
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Project
{
    class Program{

         static void Main(string[] args){

            // Boolean that controls whether application should loop or not
            bool appIsRunning = true;

            // While loop that reruns entire application
            while(appIsRunning){
                Console.Clear();

                // Create instance of wordhandler class
                Wordhandler wordhandler = new Wordhandler();
                string word = wordhandler.RandomizeWord();

                //  Create instance of messagehandler class
                Messagehandler messagehandler = new Messagehandler(word);
                messagehandler.Header();
                messagehandler.MainMenu();

                var answer = Console.ReadLine();

                // Switch case for inputted command
                switch(answer){
                    case "1":
                        // A list for inputted letters
                        var guessed = new List<string>();
                        int wordLength = word.Count();
                        bool gameIsRunning = true;
                        int wrongGuesses = 0;

                        // While-loop for running game
                        while(gameIsRunning){

                            Console.Clear();
                            messagehandler.Header();

                            // Creates a string from generated word and write it out at underlines or letters if guessed-list contains the right letters
                            string wordDisplay = "";
                            for (int i = 0; i < wordLength; i++){

                                if (guessed.Contains(word[i].ToString())) { 
                                    wordDisplay = wordDisplay + " " + word[i].ToString() + " ";
                                }else{
                                    wordDisplay = wordDisplay + " _ ";
                                }
                            }

                                
                            // If all letters has been guessed and found
                            if(!wordDisplay.Contains("_")){
                                messagehandler.GameWon();
                                messagehandler.MoveOn();
                                break;
                            }

                            // Write out players guessed letters if there are any
                            if(guessed.Count != 0){
                                string rowOfGuesses = "";
                                guessed.ForEach(i => rowOfGuesses = rowOfGuesses + " " + i);
                                messagehandler.YourGuesses(rowOfGuesses);
                            }

                            messagehandler.InGameMenu(wordDisplay, wrongGuesses);
                            var gameChoice = Console.ReadLine();

                            // Switch case for in game choice
                            switch(gameChoice){
                                    
                                //If player chooses to guess single letters 
                                case "1":
                                    messagehandler.LetterWordHeader(1);
                                    var gameAnswer = Console.ReadLine();

                                    // Run if inputted info isn't null
                                    if(gameAnswer != null){

                                        // Check if input contains anything but letters or more than one letter
                                        if(!Regex.IsMatch(gameAnswer, @"^[a-öA-Ö]+$") || gameAnswer.Length>1){
                                            messagehandler.InvalidAns();
                                            messagehandler.MoveOn();
                                            break;
                                        }
                                        try{
                                            // convert inputted information to lowercase
                                            gameAnswer.ToLower();

                                            //Integer that shows how many times the letter match in the word
                                            int timesMatched = Regex.Matches(word,gameAnswer).Count;
                                                
                                            // Check if inputted letter already has been guessed
                                            if(guessed.Contains(gameAnswer)){
                                                messagehandler.RepeatedGuess(gameAnswer);
                                                messagehandler.MoveOn();

                                            }else{

                                                // Code that runs if the letter matches
                                                if(timesMatched > 0){
                                                    messagehandler.Occurence(gameAnswer, timesMatched);
                                                    guessed.Add(gameAnswer);
                                                    messagehandler.MoveOn();

                                                }else{
                                                    messagehandler.NoMatch(gameAnswer);
                                                    guessed.Add(gameAnswer);
                                                    wrongGuesses ++ ;

                                                    // Checks if you've guessed wrong ten times and ends game if you have.
                                                    if(wrongGuesses == 10){
                                                        messagehandler.GameOver();
                                                        gameIsRunning = false;
                                                    }else{
                                                        messagehandler.MoveOn();
                                                    }

                                                }
                                            }
                                        }
                                        catch{
                                            messagehandler.ErrorMsg();
                                            messagehandler.MoveOn();
                                        };
                                    }else{
                                        messagehandler.InvalidAns();
                                    }
                                break;

                                // Run if player chooses to guess whole word
                                case "2":
                                    messagehandler.LetterWordHeader(2);
                                    var gameAnswerWord = Console.ReadLine();

                                    // Check if input isn't null
                                    if(gameAnswerWord != null){
                                        try{
                                            gameAnswerWord.ToLower();

                                            // Runs if answer is matching generated word
                                            if(gameAnswerWord == word){
                                                messagehandler.GameWon();
                                                messagehandler.MoveOn();
                                                gameIsRunning = false;

                                            }else{
                                                messagehandler.GameOver();
                                                messagehandler.MoveOn();
                                                gameIsRunning = false;
                                            }
                                        }
                                        catch{
                                            messagehandler.ErrorMsg();
                                            messagehandler.MoveOn();
                                        };
                                    }else{
                                        messagehandler.InvalidAns();
                                        messagehandler.MoveOn();
                                    }
                                break;

                                // Runs if player chooses exit to meny
                                case "q":
                                case "Q":
                                    gameIsRunning = false;
                                break;
                                    
                                default:
                                    messagehandler.InvalidAns();
                                    messagehandler.MoveOn();
                                break;
                            }
                        }
                    break;
                        
                    // Runs if user chooses to view rules
                    case "2":
                        Console.Clear();
                        messagehandler.Header();
                        messagehandler.Rules();
                        messagehandler.MoveOn();
                    break;

                    // Runs if user choses to exit game
                    case "Q":
                    case "q":
                    //exit application
                        appIsRunning = false;
                        Environment.Exit(0);
                    break;
                        
                    default:
                        messagehandler.InvalidAns();
                        messagehandler.MoveOn();
                    break;
                }
            }

        }

    } 
}
