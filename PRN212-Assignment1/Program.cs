using System.Threading.Tasks.Dataflow;

namespace Calculate
{
    using System;

    class Program
    {
        static (double perimeter, double area) CalculateSquare(double side)
        {
            double perimeter = 4 * side;
            double area = side * side;
            return (perimeter, area);
        }

        static (double perimeter, double area) CalculateRectangle(double length, double width)
        {
            double perimeter = 2 * (length + width);
            double area = length * width;
            return (perimeter, area);
        }

        static (double perimeter, double area) CalculateTriangle(double num1, double num2, double num3)
        {
            double perimeter = num1 + num2 + num3;
            double semiPerimeter = perimeter / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - num1) * (semiPerimeter - num2) * (semiPerimeter - num3));
            return (perimeter, area);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----Assignment 1-----");
            Console.WriteLine("Select options below to calculate");
            Console.WriteLine("1. Square");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
            Console.WriteLine("4. Exit");
            while (true)
            {
                try
                {
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter side: ");
                            double side = double.Parse(Console.ReadLine());
                            var (perimeter, area) = CalculateSquare(side);
                            Console.Write($"Square: Perimeter = {perimeter}, Area = {area}");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter length: ");
                            double length1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter width: ");
                            double width1 = double.Parse(Console.ReadLine());
                            var (perimeter1, area1) = CalculateRectangle(length1, width1);
                            Console.Write($"Rectangle: Perimeter = {perimeter1}, Area = {area1}");
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter number 1: ");
                            double num1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter number 2: ");
                            double num2 = double.Parse(Console.ReadLine());
                            Console.Write("Enter number 3: ");
                            double num3 = double.Parse(Console.ReadLine());
                            if (num1 + num2 <= num3 || num1 + num3 <= num2 || num2 + num3 <= num1)
                            {
                                throw new Exception("Invalid triangle");
                            }
                            var (perimeter2, area2) = CalculateTriangle(num1, num2, num3);
                            Console.Write($"Triangle: Perimeter = {perimeter2}, Area = {area2}");
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Exit");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid. Enter again.");
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

}
