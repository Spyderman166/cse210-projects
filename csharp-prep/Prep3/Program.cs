using System;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        bool play = true;
        while (play == true) {
            Random randomGenererator = new Random();
            int number = randomGenererator.Next(1, 100);

            bool correct = false;
            int count = 0;

            while (correct == false) {
                Console.Write("What is the magic number? ");
                string guessString = Console.ReadLine();

                int guessInt = int.Parse(guessString);
                count += 1;

                if (guessInt == number) {
                    correct = true;
                }
                else {
                    if (guessInt > number) {
                        Console.WriteLine("Try something LOWER");
                    }
                    else {
                        Console.WriteLine("Try something HIGHER");
                    }
                }    
            }
            Console.Write("Congratulations! You guessed it!");
            Console.WriteLine($"It took you {count} guesses.");
            Console.WriteLine("Do you want to play again? Y/N ");
            string answer = Console.ReadLine();

            if (answer == "n" || answer == "N") {
                play = false;
            }     
        }
    }
}