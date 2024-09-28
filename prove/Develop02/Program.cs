using System;
using System.Diagnostics.Tracing;
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.IO;
using System.Security.AccessControl;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;

        //welcome message
        Console.WriteLine(Environment.NewLine + "Welcome to the Journal App!");

        //initialize the journal
        Journal journal = new Journal();

        //loop until user quits
        while (quit == false) {

            //menu
            Console.WriteLine(Environment.NewLine + "Please choose an option by typing the corresponding number");
            Console.WriteLine("1.Write");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Load");
            Console.WriteLine("4.Save");
            Console.WriteLine("5.Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            int choiceNum = int.Parse(choice);

            //write to journal
            if (choiceNum == 1)
            {
                //initialize prompt generation
                GeneratePrompt newPrompt = new GeneratePrompt();

                //add prompts
                newPrompt._prompts.Add("What was my favorite part of today? ");
                newPrompt._prompts.Add("What is something I would do differently? ");
                newPrompt._prompts.Add("Who did I talk to today, What did we talk about? ");
                newPrompt._prompts.Add("Where did I go today? ");
                newPrompt._prompts.Add("What did I learn today? ");

                //randomply select a prompt, print it, and store the user's answer
                string prompt = newPrompt.GetPrompt();
                Console.Write(Environment.NewLine + prompt);
                string answer = Console.ReadLine();

                //get date and time
                DateTime now = DateTime.Now;
                string dateText = now.ToShortDateString();

                //add data to new entry
                Entry newEntry = new Entry();
                newEntry._date = dateText;
                newEntry._promptText = prompt;
                newEntry._entryText = answer;

                //store entry in _entries list
                journal.AddEntry(newEntry);
            }

            //display current journal entries
            else if (choiceNum == 2)
            {
                Console.WriteLine("displaying");
                journal.DisplayAll();

            }

            //load entries from external file
            else if (choiceNum == 3) 
            {
                //ask for filename
                Console.WriteLine(Environment.NewLine + "Enter the name of the file you would like to load from: ");
                string fileName = Console.ReadLine();

                //load the file
                journal.LoadFromFile(fileName);
            }

            //save current entries to external file - TODO
            else if (choiceNum == 4)
            {
                //ask for filename 
                Console.WriteLine(Environment.NewLine + "enter the name of the file you would like to save to: ");
                string fileName = Console.ReadLine();

                //save to file
                journal.SaveToFile(fileName);
            }

            //quit
            else {
                quit = true;
            }        
        } 
    }
}


public class Journal
{
    //list of entries
    public List<Entry> _entries = new List<Entry>();
    
    //Method to add entries to the entry list
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    //Method to save to a file
    public void SaveToFile(String fileName)
    {
        //access the file
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            //loop through all entries and print them to the file
            foreach (Entry entry in _entries) {
                outputFile.WriteLine($"{entry._date}-{entry._promptText}-{entry._entryText}");
            }
        }
    }

    //Method to load from a file
    public void LoadFromFile(String fileName) 
    {
        //clear current entries to avoid duplicates
        _entries.Clear();
        
        //access the file
        string[] lines = System.IO.File.ReadAllLines(fileName);

        //loop through each line in the file
        foreach (string line in lines)
        {
            //split the strings 
            string[] parts = line.Split("-");

            string dateText = parts[0];
            string promptText = parts[1];
            string entryText = parts[2];

            //initialize entry
            Entry newEntry =  new Entry();

            //add loaded entry to list of entries
            newEntry._date = dateText;
            newEntry._promptText = promptText;
            newEntry._entryText = entryText;
            _entries.Add(newEntry);
        }
    }

    //Method to display all entries
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
}


public class Entry
{
    //create variables
    public string _date;
    public string _promptText;
    public string _entryText;

    //Method to display each entry
    public void Display()
    {
        Console.WriteLine(Environment.NewLine + _date + " - " + _promptText + _entryText);
    }
}


public class GeneratePrompt 
{
    //list of prompts
    public List<string> _prompts = new List<string>();
    
    //pick a random prompt and return it    
    public string GetPrompt() 
    {
        Random random = new Random();
        int number = random.Next(0, 5);
        
        if (number == 0) 
        {
            return _prompts[0];
        }
        else if (number == 1) 
        {
            return _prompts[1];
        }
        else if (number == 2)
        {
            return _prompts[2];
        }
        else if (number == 3)
        {
            return _prompts[3];
        }
        else
        {
            return _prompts[4];
        }
    }
}

