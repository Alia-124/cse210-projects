using System;

class Program
{
    static void Main(string[] args)
    {
        //CREATIVE FEATURES BEYOND THE CORE REQUIRMENTS:
        //1.A leveling and rank system based on accumulaye points.
        //2.Achievement nofication for quest milestones.
        //3. A timetamped quest jounal showing earned points.
        //4. JSON saving/loading to preserve goals,score and history.
        //5. Input vaildation and protection against reapted simple-goal
        // rewards and repeated checkist completion bounses.

        QuestManager questManager = new QuestManager();
        
        bool running = true;
        while (running)
        {


            Console.WriteLine("Eternal Quest Menu:");
            Console.WriteLine("1. Create Simple Goal");
            Console.WriteLine("2. Create Checklist Goal");
            Console.WriteLine("3. Create Eternal Goal");
            Console.WriteLine("4. List Goals");
            Console.WriteLine("5. Display Score and Rank");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice from the menu: ");
            Console.WriteLine(
                $"Score: {questManager.score}, Level: {questManager.Level}, Rank: {questManager.Rank}"
            );

            Console.WriteLine("/n1. Create Simple Goal");
            Console.WriteLine("2. list Goals");
            Console.WriteLine("3. Record a goal event");
            Console.WriteLine("4. Display Score and level");
            Console.WriteLine("5. save quest");
            Console.WriteLine("6. load quest");
            Console.WriteLine("7. View quest history");
            Console.WriteLine("8. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    questManager.CreateSimpleGoal();
                    break;
                case "2":
                    questManager.CreateChecklistGoal();
                    break;
                case "3":
                    questManager.CreateEternalGoal();
                    break;
                case "4":
                    questManager.LListGoals();
                    break;
                case "5":
                    Console.WriteLine($"Score: {questManager.score}, Level: {questManager.Level}, Rank: {questManager.Rank}");
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }

    }
}
