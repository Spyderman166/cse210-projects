using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Blue", 6));

        shapes.Add(new Rectangle("Green", 3, 5));

        shapes.Add(new Circle("Yellow",4));
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor() + "," + shape.GetArea());
        }
        
    }
}