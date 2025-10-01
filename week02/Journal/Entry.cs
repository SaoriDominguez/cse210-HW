using System;

namespace Journal
{
    public class Entry
    {
        public string _date;
        public string _prompt;
        public string _response;

        public Entry() { }

        public Entry(string prompt, string response)
        {
            _date = DateTime.Now.ToShortDateString();
            _prompt = prompt;
            _response = response;
        }

       
        public void Display()
        {
            Console.WriteLine($"{_date}");
            Console.WriteLine($"Prompt: {_prompt}");
            Console.WriteLine($"Entry:  {_response}");
        }
    }
}
