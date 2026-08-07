using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_fundmentals
{
    public abstract class Shape
    {
        public abstract double Area();

        public void Describe() 
        {
            Console.WriteLine($"Shape: {this.GetType().Name}, Area: {Area():F2}");
        }
    }

    public class Circle : Shape , IDrawable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public void Draw()
        {
            Console.WriteLine("  ***  ");
            Console.WriteLine(" *   * ");
            Console.WriteLine(" *   * ");
            Console.WriteLine("  ***  ");
        }


    }

    public class Rectangle : Shape, IDrawable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public void Draw()
        {
            Console.WriteLine(" +---+ ");
            Console.WriteLine(" |   | ");
            Console.WriteLine(" +---+ ");
        }

        
    }


    public class Triangle : Shape, IDrawable
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double Area()
        {
            return 0.5 * BaseLength * Height;
        }

        public void Draw()
        {
            Console.WriteLine("   *   ");
            Console.WriteLine("  ***  ");
            Console.WriteLine(" ***** ");
        }

    }



}
