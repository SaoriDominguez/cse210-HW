using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    // Use a single RNG for the whole class
    private static readonly Random _rng = new Random();

    // Private fields
    private Reference _reference;
    private List<Word> _words;

    // Receives a Reference and the full scripture text; splits into Word objects.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Basic split by spaces. (Punctuation stays attached to the token,
        // which Word.GetDisplayText handles correctly.)
        foreach (var token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(token));
        }
    }

    // Join each Word's display text with spaces
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    // Hides a number of random, currently-visible words (STRETCH / EXCEEDS)
    public void HideRandomWords(int numberToHide)
    {
        // Stretch: select from visible words only
        var visible = _words.Where(w => !w.IsHidden()).ToList();
        if (visible.Count == 0) return;

        int toHide = Math.Min(numberToHide, visible.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _rng.Next(visible.Count);
            visible[idx].Hide();
            visible.RemoveAt(idx);
        }

        // --- CORE VERSION (93%): pick from all words, even if they're already hidden ---
        // for (int i = 0; i < numberToHide; i++)
        // {
        //     int idx = _rng.Next(_words.Count);
        //     _words[idx].Hide(); // may already be hidden, which is allowed in core
        // }
    }

    // True if every word is hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
