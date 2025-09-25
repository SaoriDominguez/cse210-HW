using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Member variable that stores the list of entries
    private List<Entry> _entries = new List<Entry>();

    // Method to add an entry (encapsulation: we don’t expose _entries directly)
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Method to display all entries
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display(); // We let Entry handle how it displays itself
            Console.WriteLine(); // Blank line between entries
        }
    }

    // Save journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                // Format: date|prompt|response
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    // Load journal from a file
    public void LoadFromFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        _entries.Clear(); // Replace any existing entries

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._prompt = parts[1];
                entry._response = parts[2];

                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }
}
