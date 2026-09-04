using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("welcome to the program!");

        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name, number, square);
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int number, int square)
    {
        Console.WriteLine($"Hello {name}, the square of {number} is {square}.");
    }
}
