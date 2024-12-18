using System.ComponentModel;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();

    private List<string> _questions = new List<string>();

    public ReflectionActivity(string name, string description)
    : base(name, description)
    {
        
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt: ");
        Console.WriteLine();

        Thread.Sleep(1000);
        DisplayPrompt();
        Console.WriteLine("\nWhen you think of something in mind. press enter to continue.");
        string a = Console.ReadLine();
        if (a == "")
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                DisplayQuestions();
            }       
            
            DisplayEndingMessage();
        }
    }

    public string GetRandomPrompt()
    {
        _prompts.Add(" --- Think of a time when you stood up for someone else. --- ");
        _prompts.Add(" --- Think of a time when you did something really difficult. --- ");
        _prompts.Add(" --- Think of a time when you helped someone in need. --- ");
        _prompts.Add(" --- Think of a time when you did something truly selfless. --- ");

        Random random= new Random();
        int i = random.Next(0, _prompts.Count);

        return _prompts[i];
    }

    public string GetRandomQuestion()
    {
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");

        Random random = new Random();
        int i = random.Next(0, _questions.Count);

        return _questions[i];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
        ShowSpinner(10);
    }
}