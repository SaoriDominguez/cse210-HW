using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    public class Journal
    {
        private readonly List<Entry> _entries = new List<Entry>();

        // Add an entry
        public void AddEntry(Entry entry) => _entries.Add(entry);

        // Display all entries
        public void DisplayAll()
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
                Console.WriteLine();
            }
        }

        // Save journal to file
        public void SaveToFile(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }

        // Load journal from file
        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File not found: {filename}");
                return;
            }

            _entries.Clear();

            foreach (string line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    var entry = new Entry
                    {
                        _date = parts[0],
                        _prompt = parts[1],
                        _response = parts[2]
                    };
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
    }
}
