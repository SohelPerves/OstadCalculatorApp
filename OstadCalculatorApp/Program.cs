using System;

namespace OstadCalculatorApp
{
    public interface IBasicCalculator
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
    }

    public interface IScientificCalculator
    {
        double SquareRoot(double x);
        double Power(double baseNum, double exponent);
    }

    public class BasicCalculator : IBasicCalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
    }

    public class ScientificCalculator : BasicCalculator, IScientificCalculator
    {
        public double SquareRoot(double x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Cannot calculate square root of a negative (-) number.");
            }
            return Math.Sqrt(x);
        }

        public double Power(double baseNum, double exponent)
        {
            return Math.Pow(baseNum, exponent);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ScientificCalculator calc = new ScientificCalculator();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===== Ostad Calculator App  By Sohel =====");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Square Root");
                Console.WriteLine("6. Power");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            var (a, b) = GetTwoInputs();
                            Console.WriteLine($"Result: {calc.Add(a, b)}");
                            break;
                        }
                    case "2":
                        {
                            var (a, b) = GetTwoInputs();
                            Console.WriteLine($"Result: {calc.Subtract(a, b)}");
                            break;
                        }
                    case "3":
                        {
                            var (a, b) = GetTwoInputs();
                            Console.WriteLine($"Result: {calc.Multiply(a, b)}");
                            break;
                        }
                    case "4":
                        {
                            var (a, b) = GetTwoInputs();
                            Console.WriteLine($"Result: {calc.Divide(a, b)}");
                            break;
                        }
                    case "5":
                        {
                            double x = GetSingleInput("Enter a number: ");
                            Console.WriteLine($"Result: {calc.SquareRoot(x)}");
                            break;
                        }
                    case "6":
                        {
                            Console.Write("Enter base: ");
                            double baseNum = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter exponent: ");
                            double exponent = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"Result: {calc.Power(baseNum, exponent)}");
                            break;
                        }
                    case "0":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static (double, double) GetTwoInputs()
        {
            Console.Write("Enter first number: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            double b = Convert.ToDouble(Console.ReadLine());
            return (a, b);
        }

        static double GetSingleInput(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}
