using System;
using System.Collections.Generic;

public class Video
{
    // Core data for a video
    public string _title;
    public string _author;
    public int _lengthSeconds;

    // Related comments
    public List<Comment> _comments = new List<Comment>();

    // Add a comment to this video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Return number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Display video header + comments
    public void Display()
    {
        Console.WriteLine($"Title:  {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthSeconds} seconds");
        Console.WriteLine($"Comments: {GetCommentCount()}");

        foreach (Comment c in _comments)
        {
            c.Display();
        }

        Console.WriteLine(); // blank line between videos
    }
}
