using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden) return _text;

        StringBuilder sb = new StringBuilder(_text.Length);
        foreach (char c in _text)
        {
            sb.Append(char.IsLetter(c) ? '_' : c);
        }
        return sb.ToString();
    }
}
