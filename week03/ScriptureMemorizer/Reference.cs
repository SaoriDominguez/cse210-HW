public class Reference
{
    // Private fields (encapsulation: hide data)
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // -1 means "no range"

    // Constructor: single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1;
    }

    // Constructor: verse range (start to end)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Displays "Book Chapter:Verse" or "Book Chapter:Start-End"
    public string GetDisplayText()
    {
        if (_endVerse > 0 && _endVerse != _verse)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        return $"{_book} {_chapter}:{_verse}";
    }
}
