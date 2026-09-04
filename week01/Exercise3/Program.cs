using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic nuber?");
        int magicNumber = int.Parse(Console.ReadLine());
        int guess = 0;
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Your guess is too low.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Your guess is too high.");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number!");
            }
        }
        Console.Write("What is your guess? ");
         guess = int.Parse(Console.ReadLine());

        if(guess<magicNumber)
        {
            Console.WriteLine("Your guess is too low.");
        }
        else if(guess>magicNumber)
        {
            Console.WriteLine("Your guess is too high.");
        }
        else
        {
            Console.WriteLine("Congratulations! You guessed the magic number!");
        }
    }
}
