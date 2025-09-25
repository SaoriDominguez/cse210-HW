using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1) Read numbers into a List<int> until user enters 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            if (n == 0) break;      // stop condition (0 is NOT added)
            numbers.Add(n);          // append to the list
        }

        // Edge case: empty list (user typed 0 first)
        if (numbers.Count == 0)
        {
            Console.WriteLine("The sum is: 0");
            Console.WriteLine("The average is: 0");
            Console.WriteLine("The largest number is: 0");
            return;
        }

        // 2) Core: sum, average, max
        int sum = 0;
        int max = numbers[0];
        foreach (int x in numbers)
        {
            sum += x;
            if (x > max) max = x;
        }
        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // 3) Stretch: smallest positive (>0 and closest to 0)
        int smallestPositive = int.MaxValue;
        foreach (int x in numbers)
        {
            if (x > 0 && x < smallestPositive)
            {
                smallestPositive = x;
            }
        }
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // 4) Stretch: sort and print ascending
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }
    }
}
