using System;

class Program
{
    static void Main(string[] args)
    {
        string date = DateTime.Now.ToString("dd MMM yyyy");
        List<Activity> activities= new List<Activity>();

        activities.Add(new RunningActivity(date, 30, 3.5));
        activities.Add(new CyclingActivity(date, 60, 13));
        activities.Add(new SwimmingActivity(date, 20, 100));

        Console.Clear();
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
