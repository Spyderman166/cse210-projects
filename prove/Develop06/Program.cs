using System;
using System.Net.Quic;
using System.Runtime.InteropServices.Marshalling;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        int score = 0;
        List<Goal> goals = new List<Goal>();
        GoalManager gM = new GoalManager(score, goals);

        Console.Clear();
        while (!quit)
        {
            gM.Start();
            Console.WriteLine("Select a choice from the menu: ");
            string answerStr = Console.ReadLine();
            int answerInt = int.Parse(answerStr);
            if (answerInt == 1)
            {
                gM.CreateGoal();
            }
            else if (answerInt == 2)
            {
                gM.ListGoalDetails();
            }
            else if (answerInt == 3)
            {
                gM.SaveGoals();
            }
            else if (answerInt == 4)
            {
                gM.LoadGoals();
                
            }
            else if (answerInt == 5)
            {
                gM.RecordEvent();
            }
            else
            {
                quit = true;
            }
        }
    }
}

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager(int score, List<Goal> goals)
    {
        _score = score;
        _goals = goals;
    }

    public void Start()
    {
        Console.WriteLine($"\nYou have {_score} points.");

        Console.WriteLine("\nMenu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
    }

    public void DisplayPlayerInfo()
    {

    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            string[] parts = goal.GetDetails().Split("(");
            
            Console.WriteLine($" {i}. {parts[0]}");
            i++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (Goal goal in _goals)
        {
            bool complete = goal.IsComplete();
            if (complete)
            {
                Console.WriteLine($"{i} [X] {goal.GetDetails()}");
            }
            else 
            {
                Console.WriteLine($"{i} [ ] {goal.GetDetails()}");
            }
            i++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();
        int goalTypeInt = int.Parse(goalType);
        if (goalTypeInt == 1)
        {
            Console.WriteLine("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.WriteLine("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.WriteLine("what is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            SimpleGoal newSG = new SimpleGoal(name, description, points);
            _goals.Add(newSG);
        }
        else if (goalTypeInt == 2)
        {
            Console.WriteLine("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.WriteLine("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.WriteLine("what is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            EternalGoal newEG = new EternalGoal(name, description, points);
            _goals.Add(newEG);
        }
        else
        {
            Console.WriteLine("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.WriteLine("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.WriteLine("what is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            Console.WriteLine("How many times does this goal need to be accompished for a bonus? ");
            string bonus = Console.ReadLine();
            int bonusInt = int.Parse(bonus);
            Console.WriteLine("What is the bonus for accomplishing it that many times? ");
            string target = Console.ReadLine();
            int targetInt = int.Parse(target);
            ChecklistGoal newCG = new ChecklistGoal(name, description, points, targetInt, bonusInt);
            _goals.Add(newCG);
        }

    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.WriteLine("Which goal did you accomplish? ");
        int goalAccomplished = int.Parse(Console.ReadLine()) - 1;
        _goals[goalAccomplished].RecordEvent();
        string[] parts = _goals[goalAccomplished].GetStringRepresentation().Split("_");
        _score += int.Parse(parts[2]);

        if (_goals[goalAccomplished] is ChecklistGoal)
        {   
            if (_goals[goalAccomplished].IsComplete())
            {
                _score += int.Parse(parts[3]);
            }
           
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("score:" + _score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);        

        foreach (string line in lines)
        {
            if (line.StartsWith("score"))
            {
                string[] parts = line.Split(":");
                string newScore = parts[1];
                _score = int.Parse(newScore);
            }
            else
            {
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string goalInfo = parts[1];
                if (goalType == "SimpleGoal")
                {
                    string[] parts2 = goalInfo.Split("_");
                    string name = parts2[0];
                    string description = parts2[1];
                    string points = parts2[2];
                    string complete = parts2[3];
                    SimpleGoal newSG = new SimpleGoal(name, description, points);
                    if (complete == "true")
                    {
                        newSG.RecordEvent();
                    }
                    _goals.Add(newSG);
                }
                else if (goalType == "EternalGoal")
                {
                    string[] parts2 = goalInfo.Split("_");
                    string name = parts2[0];
                    string description = parts2[1];
                    string points = parts2[2];
                    EternalGoal newEG = new EternalGoal(name, description, points);
                    _goals.Add(newEG);
                }
                else
                {
                    string[] parts2 = goalInfo.Split("_");
                    string name = parts2[0];
                    string description = parts2[1];
                    string points = parts2[2];
                    int target = int.Parse(parts2[3]);
                    int bonus = int.Parse(parts2[4]);
                    int amountCompeleted = int.Parse(parts2[5]);
                    ChecklistGoal newCG = new ChecklistGoal(name, description, points, target, bonus);
                    while (amountCompeleted > 0)
                    {
                        newCG.RecordEvent();
                        amountCompeleted--;
                    }
                    _goals.Add(newCG);
                }
            }      
        }
    }
}