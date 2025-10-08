using System;

public class Comment
{
    // Public fields per W02 style (abstraction focus)
    public string _author;
    public string _text;

    // Convenience constructor
    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }

    // Show "author: text"
    public void Display()
    {
        Console.WriteLine($"- {_author}: {_text}");
    }
}
