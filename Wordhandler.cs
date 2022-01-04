
// Code written by Therese Bruzell
using System.IO;

namespace Project{

    // Class for words
    public class Wordhandler{
        
        private string word;
        private List<string> listOfWords;
     

        // Construct that adds information to list of words
        public Wordhandler(){
            this.listOfWords = new List<string>() { "apple", "argentina", "anthrax" };
            this.word ="";
        }

        //Generate random word from list of words 
        public string RandomizeWord(){
            Random rnd = new Random();
            int randomNumb = rnd.Next(this.listOfWords.Count);
            this.word = this.listOfWords[randomNumb];
            return word;
        }
        
    }

}