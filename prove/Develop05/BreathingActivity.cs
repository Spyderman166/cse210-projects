class BreathingActivity : Activity
{

    public BreathingActivity(string name, string description)
    : base(name, description)
    {
        
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\nBreathe in...");
            ShowCountDown(3);
            Console.WriteLine("\nBreathe out...");
            ShowCountDown(3);
        }

        DisplayEndingMessage();
        ShowSpinner(5);
        
    }
}
