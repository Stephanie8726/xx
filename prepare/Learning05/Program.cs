using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"The {shape.Color} shape has an area of {shape.GetArea()}");
        }
    }
}
