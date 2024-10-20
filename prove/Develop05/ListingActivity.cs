using System.Diagnostics;

class ListingActivity : Activity
{
    private int _count = 0;
    private List<string> _prompts = new List<string>();


    public ListingActivity(string name, string description)
    : base(name, description)
    {

    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        GetRandomPrompt();
        Console.WriteLine("\nYou may begin in:");
        ShowCountDown(10);
        List<string> list = GetListFromUser();
        _count = list.Count;
        ShowSpinner(3);
        Console.WriteLine($"You listed {_count} items!");
        Thread.Sleep(1000);
        DisplayEndingMessage();

    }

    public void GetRandomPrompt()
    {
        _prompts.Add(" --- Who are people that you appreciate? --- ");
        _prompts.Add(" --- What are personal strengths of yours? --- ");
        _prompts.Add(" --- Who are people that you have helped this week? --- ");
        _prompts.Add(" --- When have you felt the Holy Ghost this month? --- ");
        _prompts.Add(" --- Who are some of your personal heroes? --- ");

        Random random = new Random();
        int i = random.Next(0,_prompts.Count);

        Console.WriteLine(_prompts[i]);

    }

    public List<string> GetListFromUser()
    {
        List<string> list = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            string newEntry = Console.ReadLine();
            list.Add(newEntry);
        }
    
        return list;
    }
}