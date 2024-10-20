using System.IO.Compression;
using System.Threading.Tasks.Dataflow;

class Activity
{
    protected string _name = "";
    protected string _description = "";
    protected int _duration;

    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Thread.Sleep(1000);
        Console.WriteLine($"Welcome to the {_name}.");
        Thread.Sleep(1000);
        Console.WriteLine($"\n{_description}");
        Thread.Sleep(1000);
        Console.WriteLine($"\nHow long, in seconds, would you like for your session? ");
        string seconds = Console.ReadLine();
        _duration = int.Parse(seconds);

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(3);
        Thread.Sleep(1000);
    }

    public void DisplayEndingMessage()
    {
        Thread.Sleep(1000);
        Console.WriteLine("\nWell done!");
        Thread.Sleep(1000);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}");
        ShowSpinner(5);

    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>();
        
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");
    

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(300);
            Console.Write("\b \b");

            i++;

            if (i >= spinner.Count)
            {
                i = 0;
            }
        }

        
    }

    public void ShowCountDown(int seconds)
    {
        while (seconds > 0)
        {
            Console.Write(seconds);
            Thread.Sleep(1000);

            if (seconds >= 10)
            {
                Console.Write("\b\b  \b\b");
            }
            else 
            {
                Console.Write("\b \b");
            }
            seconds--;
        }
    }

}
