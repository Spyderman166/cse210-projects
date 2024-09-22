using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gpString = Console.ReadLine();
        int gradePer = int.Parse(gpString);
        int remainder = 0;
        string sign = "";
        string letter = "";
        
        if (gradePer >= 90) {
            letter = "A";
        }
        else if (gradePer >= 80) {
            letter = "B";
        }
        else if (gradePer >= 70) {
            letter = "C";
        }
        else if (gradePer >= 60) {
            letter = "D";
        }
        else {
            letter = "F";
        }
        
        int quotient = Math.DivRem(gradePer, 10, out remainder);
        
        if (remainder >= 7 && letter != "A" && letter != "F") {
            sign = "+";
        }
        else if (remainder <= 3 && letter != "F") {
            sign = "-";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        if (gradePer >= 70) {
            Console.WriteLine("You passed!");
        }
        else {
            Console.WriteLine("Better luck next time!");
        }
    }
}