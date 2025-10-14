using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Build a single list that holds different shapes (base type).
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 3, 4),
            new Circle("Green", 2.5)
        };

        // Polymorphism in action: same call -> different overridden methods.
        foreach (Shape s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()}, Area: {s.GetArea():F2}");
        }
    }
}
