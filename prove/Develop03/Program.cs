using System;
using System.Diagnostics;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        //set variables and initialize classes
        bool quit;

        string passage = "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do.";
        string book = "2 Nephi";
        int chapter = 32;
        int verse = 3;
        
        Reference reference = new Reference(book, chapter, verse);
        Scripture scripture= new Scripture(reference, passage);

        //loop until user types quit
        do {

            //clear the console, get the text to display, and display it.
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            
            //ask user for input and continue or quit
            Console.WriteLine("Press enter to continue, type 'quit' to exit ");
            string answer = Console.ReadLine();
            if (answer == "quit")
            {
                quit = true;
            }   
            else if (answer != "quit" && scripture.IsCompletelyHidden() == true)
            {
                quit = true;
            }
            else 
            {
                quit = false;
                scripture.HideRandomWords(3);
            }
            
        } while (quit == false);
        Console.Clear();
        Console.WriteLine("Goodbye.");
    }
}

class Scripture 
{
    //create private variables
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    //constructor
    public Scripture(Reference Reference, string text)
    {
        //set _reference and add Word instances to _words
        _reference = Reference;
        string[] words = text.Split(" ");
        foreach (string w in words)
        {
            Word newWord = new Word(w);
            _words.Add(newWord); 
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        //repeat 3 times
        while (numberToHide > 0)
        {
            //choose a random Word instance and set it to hidden 
            Random random = new Random();
            int num = random.Next(0, _words.Count);
            bool hidden = _words[num].IsHidden();
            if (hidden == false){
                _words[num].Hide();
                numberToHide -= 1;
            }
        }
    }

    public string GetDisplayText()
    {
        //gather the different parts of the scripture and piece it together, then return it
        string reference = _reference.GetDisplayText();
        string newPassage = "";
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                string part = word.GetDisplayText() + " ";
                newPassage += part;
            }
            else 
            {
                int number = word.GetDisplayText().Count();
                string part = "";
                while (number > 0) 
                {
                    part += "_";
                    number -= 1;
                }
                newPassage += part;
                newPassage += " ";
            }
        }
        return $"{reference}, {newPassage}";
    }

    public bool IsCompletelyHidden()
    {
        int hiddenCount = 0;
        foreach (Word word in _words)
        {
            bool hidden = word.IsHidden();
            if (hidden == true)
            {
                hiddenCount += 1;
            }
        }
        if (hiddenCount == _words.Count)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}

class Reference
{
    //create variables 
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    
    public string GetDisplayText()
    {
        return $"{_book} {_chapter}: {_verse}";
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text) {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}
