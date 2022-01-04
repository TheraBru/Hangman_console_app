// Code written by Therese Bruzell
using System.IO;

namespace Project{

    // Class for words
    public class Messagehandler{
    
        private string word;

     // Construct that adds information to word
        public Messagehandler(string word){
            this.word = word;
        }

        public void Header(){
            Console.WriteLine("\n*HANG MAN*");
            Console.WriteLine("______________________\n");
        }

        public void MainMenu(){
            Console.WriteLine("What do you want to do? \n");
            Console.WriteLine("1: Start a game \n2: Rules \nQ: Quit");
        }

        public void InGameMenu(string wordDisplay, int wrongGuesses){
            Console.WriteLine("Figure out the hidden word before the innocent man is hung! \n");
            Console.WriteLine("The word is " + wordDisplay + " \n");
            Console.WriteLine("You have " + (10 - wrongGuesses) + " wrong guesses left \n");
            Console.WriteLine("CHOOSE AN ACTION");
            Console.WriteLine("\n1: Guess a letter \n2: Guess word \nQ: Exit to menu");
        }

        public void YourGuesses(string guesses){
            Console.WriteLine("Your guesses:" + guesses + "\n");
        }

        public void LetterWordHeader(int chosenCase){
            if(chosenCase==1){
                Console.WriteLine("\nGuess a letter ");
            }else if(chosenCase == 2){
                Console.WriteLine("\nGuess a word");
            }
        }

        public void RepeatedGuess(string guess){
            Console.WriteLine("\nYou have already made a quess for letter " + guess + ". Please make another guess.");
        }

        public void Occurence(string letter, int occurence){
            Console.WriteLine("\nThe letter "+ letter + " occurs " + occurence + " times in the word! \n \n");
        }

        public void NoMatch(string letter){
            Console.WriteLine("\nToo bad! The word doesn't contain the letter " + letter + ".\n \n");
        }

        public void GameOver(){
            Console.Write(" \n *GAME OVER* \n The word was " + word);
            Console.Write("\nYou didn't figure out the word and the man hung. \n");
        }

        public void GameWon(){
            Console.WriteLine("Congratulations! You beat the game!\nThe word was " + word + ".\nYou saved the innocent man! \n");
        }

        public void MoveOn(){
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);
        }

        public void Rules(){
            Console.WriteLine("RULES \n");
            Console.WriteLine("The rules are simple. A word will be generated which you will at first only know the number of letters to.");
            Console.WriteLine("You will then quess whether a specific letter is in the word or not. If you are right the letter gets put in its correct spot in the word and you can continue guessing.");
            Console.WriteLine("If you are wrong you get a mark. You may then continue guessing the letters, or the full word if you think you know it. If you guess wrong or get 10 wrong guesses, you lose. If you guess right, you win.");
        }

        public void InvalidAns(){
            Console.WriteLine("Invalid answer. Try again.");
        }

        public void ErrorMsg(){
            Console.WriteLine("Oops! Something went wrong.");
        }
        
    }

}