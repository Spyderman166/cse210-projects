using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>(); 
        int newNum = 0;
        do {
            Console.Write("Enter a number (press 0 when finished): ");
            string a = Console.ReadLine();
            newNum = int.Parse(a);
            numbers.Add(newNum);
        } while (newNum !=0);

        int sum = 0;
        int average = 0;
        int largest = 0;

        foreach (int num in numbers) {
            sum += num;
        }

        foreach (int num in numbers) {
            if (num > largest) {
                largest = num;
            }
        }

        int count = numbers.Count;
        average = sum / (count - 1);
        
        Console.WriteLine(sum);
        Console.WriteLine(average);
        Console.WriteLine(largest);

    }
}