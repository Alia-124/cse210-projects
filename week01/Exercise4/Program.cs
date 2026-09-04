using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter Number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);

        }
        //core Requirements 1: compte the sum
        int sum = numbers.Sum();

        if (numbers.Count > 0)
        {
            // Core requirement 2: compute the average
            double average = numbers.Average();

            // Core requirement 3: compute the maximum
            int largest = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");

            // Stretch challenge 1: smallest positive number
            var positiveNumbers = numbers.Where(n => n > 0).ToList();
            if (positiveNumbers.Count > 0)
            {
                int smallestPositive = positiveNumbers.Min();
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch challenge 2: sort the list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
