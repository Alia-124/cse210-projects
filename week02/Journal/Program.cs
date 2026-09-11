using System;

class Program
{
    static void Main(string[] args)
    {
       Journal journal =new Journal();

       List<string> prompts = new List<string>
       {
           "What was the best part of your day?",
           "What did you learn today?",
           "What are you grateful for today?",
           "What challenges did you face today?",
           "What made you smile today?"
       };

       Random random = new Random();

       Console.WriteLine("Welcome to the Journal Program!");

       string choice = "";
       while (choice != "5")
       {
           Console.WriteLine("\nPlease select one of the following:");
           Console.WriteLine("1. Write a new entry");
           Console.WriteLine("2. Display the journal");
           Console.WriteLine("3. Save the journal to a file");
           Console.WriteLine("4. Load the journal from a file");
           Console.WriteLine("5. Quit");

           choice = Console.ReadLine();

           switch (choice)
           {
               case "1":
                   // Implementation for writing a new entry
                   break;
               case "2":
                   journal.DisplayAll();
                   break;
               case "3":
                   Console.Write("Enter a filename to save the journal: ");
                   string saveFilename = Console.ReadLine();
                   journal.SaveToFile(saveFilename);
                   break;
               case "4":
                   Console.Write("Enter a filename to load the journal from: ");
                   string loadFilename = Console.ReadLine();
                   journal.LoadFromFile(loadFilename);
                   break;
               case "5":
                   Console.WriteLine("Goodbye!");
                   break;
               default:
                   Console.WriteLine("Invalid choice. Please try again.");
                   break;
           }
       }
   }
