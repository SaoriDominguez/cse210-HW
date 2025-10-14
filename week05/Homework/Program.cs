using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            //  base
            Assignment a = new Assignment("Samuel Bennett", "Multiplication");
            Console.WriteLine(a.GetSummary());

            //  MathAssignment
            MathAssignment m = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
            Console.WriteLine(m.GetSummary());
            Console.WriteLine(m.GetHomeworkList());

            // WritingAssignment
            WritingAssignment w = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
            Console.WriteLine(w.GetSummary());
            Console.WriteLine(w.GetWritingInformation());
        }
    }
}
