using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);
        DisplayResults(userName, squaredNumber);
    }    
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber() {
        Console.Write("What is your favorite number? ");
        string answer = Console.ReadLine();
        int number = int.Parse(answer);

        return number;
    }

    static int SquareNumber (int number) {
        int squared = number * number;

        return squared;
    }

    static void DisplayResults(string userName, int squared) {
        Console.WriteLine($"{userName}, your number squared is: {squared}");
    }
}