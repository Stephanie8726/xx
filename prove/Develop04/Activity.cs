using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected Random random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void RunActivity()
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        if (int.TryParse(Console.ReadLine(), out _duration) && _duration > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            Spinner(4);

            PerformActivity();

            Console.WriteLine();
            Console.WriteLine($"Well done! You've completed the {_name} Activity.");
            Console.WriteLine();
            if (this is Listing)
            {
                Console.WriteLine($"You've listed {_duration} items.");
                Console.WriteLine();
            }
            // Console.WriteLine($"You've spent {_duration} seconds on this activity.");
        }
        else
        {
            Console.WriteLine("Invalid duration. Please enter a positive number.");
        }
    }

    protected virtual void PerformActivity()
    {
        // Base class has no specific activity
    }

    protected void Spinner(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...");
            Thread.Sleep(1000);
            Console.Write("\b\b\b\b\b\b\b\b\b\b");
        }
    }
}
