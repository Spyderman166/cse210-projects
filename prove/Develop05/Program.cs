using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            //print menu
            Console.Clear();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Select an option from the menu: ");
            string choiceStr = Console.ReadLine();
            int choceInt = int.Parse(choiceStr);

            //Breathing Activity
            if (choceInt == 1)
            {
                BreathingActivity bActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                bActivity.Run();
            }
            //Reflection Activity
            else if (choceInt == 2)
            {
                ReflectionActivity rActivity = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on the times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                rActivity.Run();
            }
            //Listing Activity
            else if (choceInt == 3)
            {
                ListingActivity lActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                lActivity.Run();
            }
            //Quit
            else
            {
                quit = true;
            }

        }   
    }
}