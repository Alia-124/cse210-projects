using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        activities.Add(new Activity("Running", 30));
        activities.Add(new Activity("Cycling", 45));
        activities.Add(new Activity("Swimming", 60));

        Console.WriteLine("Exercise Tracking Application");
        Console.WriteLine("-----------------------------");
        Console.WriteLine();

        foreach (var activity in activities)
        {
            Console.WriteLine($"Activity: {activity.Name}, Duration: {activity.Duration} minutes");
        }
    }
}

class Activity
{
    public string Name { get; }
    public int Duration { get; }

    public Activity(string name, int duration)
    {
        Name = name;
        Duration = duration;
    }
}
