using System;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Transactions;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos= new List<Video>();

        List<Comment> comments1 = new List<Comment>();
        comments1.Add(new Comment("name1", "Thanks! I've been struggling with mine for weeks!"));
        comments1.Add(new Comment("name2", "this video is awesome!"));
        comments1.Add(new Comment("name3", "Mine still won't open even though I did exactly what you showed in the video."));

        Video video1 = new Video("How to Unscrew a Pickle Jar", "Mr. Pickles", 7, comments1);
        videos.Add(video1);

        List<Comment> comments2 = new List<Comment>();
        comments2.Add(new Comment("name4", "this video is great!"));
        comments2.Add(new Comment("name5", "That guy what pretty good..."));
        comments2.Add(new Comment("name6", "Wow! so cool!"));

        Video video2 = new Video("This Guy Though He Could Beat Me in a Dance Off", "TheDancingQueen123", 1080, comments2);
        videos.Add(video2);

        List<Comment> comments3 = new List<Comment>();
        comments3.Add(new Comment("name7", "this video is great!"));
        comments3.Add(new Comment("name8", "this video is awesome!"));
        comments3.Add(new Comment("name9", "this video needs some work..."));

        Video video3 = new Video("First Look at New Mclaren W1!", "TheCarGuy", 1493, comments3);
        videos.Add(video3);
        
        foreach(Video video in videos)
        {
            string info = video.DisplayVideoInfo();
            int commentNum = video.ReturnCommentNum();
            Console.WriteLine(Environment.NewLine + $"{info}, Comment total: {commentNum}");
            string commentInfo = video.GetCommentInfo();
            Console.WriteLine(commentInfo);
        }
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _seconds;
    private List<Comment> _comments = new List<Comment>();


    public Video(string title, string author, int seconds, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _seconds = seconds;
        _comments = comments;
    }

    public int ReturnCommentNum()
    {
        return _comments.Count;
    }

    public string DisplayVideoInfo()
    {
        return $"Title: {_title}, Author: {_author}, Length: {_seconds}";
    }

    public string GetCommentInfo()
    {
        string displayText = "";
        foreach (Comment comment in _comments)
        {
            string newComment = comment.DisplayCommentInfo();
            displayText += Environment.NewLine + newComment;
        }
        return displayText;
    }
}

class Comment 
{
    private string _username;
    private string _text;


    public Comment(string username, string text)
    {
        _username = username;
        _text = text;

    }

    public string DisplayCommentInfo()
    {
        return $"Commenter: {_username}, Comment: {_text}";
    }

}
