using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private static readonly Random _rng = new Random();

    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (var token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(token));
        }
    }

    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    public void HideRandomWords(int numberToHide)
    {
        var visible = _words.Where(w => !w.IsHidden()).ToList();
        if (visible.Count == 0) return;

        int toHide = Math.Min(numberToHide, visible.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _rng.Next(visible.Count);
            visible[idx].Hide();
            visible.RemoveAt(idx);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public Reference GetReference()
    {
        return _reference;
    }
}

