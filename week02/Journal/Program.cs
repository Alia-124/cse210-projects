using System;
using System.Collections.Generic;

class Program
{
    static void SetEntryField(object entry, string[] fieldNames, object value)
    {
        foreach (string fieldName in fieldNames)
        {
            var field = entry.GetType().GetField(fieldName);
            if (field != null)
            {
                field.SetValue(entry, value);
                return;
            }
        }

        throw new InvalidOperationException(
            $"Could not find a matching field on {entry.GetType().Name}. Tried: {string.Join(", ", fieldNames)}");
    }

    static void Main(string[] args)
    {
        Journal journal = new Journal();

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
            Console.WriteLine();
            Console.WriteLine("Please select one of the following:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.WriteLine("What would you like to do?");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Count)];

                    Console.WriteLine();
                    Console.WriteLine(prompt);
                    Console.Write("> ");

                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._data = DateTime.Now.ToShortDateString();
                    newEntry._prompt = prompt;
		            newEntry._response =response;


                    journal._entries.Add(newEntry);
                    Console.WriteLine("Entry Saved!");
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Your Journal:");
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved successfully!");
                    break;

                case "4":
                    Console.Write("Enter a filename to load the journal from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded successfully!");
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, Please try again.");
                    break;
            }
        }
    }
}
