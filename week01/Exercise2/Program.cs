using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        int grade =int .Parse(Console.ReadLine());
    // determine the letter grade
    string letter;
    if (grade >= 90)
    {
        letter = "A";
    }
    else if (grade >= 80)
    {
        letter = "B";
    }
    else if (grade >= 70)
    {
        letter = "C";
    }
    else if (grade >= 60)
    {
        letter = "D";
    }
    else
    {
        letter = "F";
    }
    // Determine whether the student passed
    if (grade>= 70)
    {
        Console.WriteLine("Congratulations! You passed the class with a grade of " + letter);
    }
    else
    {
        Console.WriteLine("You did not pass the class. Your grade is " + letter);
    }
    // string challenge :Determine the +or - sign
    string sign = "";
    int lastdigit=grade%10;
    if (lastdigit >= 7)
    {
        sign = "+";
    }
    else if (lastdigit <= 3)
    {
        sign = "-";
    }
    else
    {
        sign = "";
    }
    // f grade cannot be + or - sign
    if (letter == "F")
    {
        sign = "";
    }
    // Display the final letter grade with sign
    Console.WriteLine("Your final letter grade is: " + letter + sign);
    }
}
