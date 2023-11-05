using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

class Listing : Activity
{
    private List<string> listPrompts = new List<string>
    {
        "---Who are people that you appreciate?---",
        "---What are personal strengths of yours?---",
    };

    private List<string> additionalQuestions = new List<string>
    {
        "---Who are people that you have helped this week?---",
        "---When have you felt the Holy Ghost this month?---",
        "---Who are some of your personal heroes?---"
    };

    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        string randomPrompt = GetRandomPrompt(listPrompts);
        listPrompts.Remove(randomPrompt);
        Console.WriteLine(randomPrompt);

        DateTime startTime = DateTime.Now;
        List<string> itemsListed = new List<string>();
        TimeSpan elapsedTime = TimeSpan.Zero;

        do
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemsListed.Add(item);
                elapsedTime = DateTime.Now - startTime;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-empty item.");
            }
        } while (elapsedTime.TotalSeconds < _duration);

        Console.WriteLine($"You've listed {itemsListed.Count} items.");

        if (_duration > 0)
        {
            Console.Write("Would you like to list more items? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                _duration = Math.Min(_duration, additionalQuestions.Count * 4);
                PerformAdditionalQuestions();
            }
        }
    }

    private string GetRandomPrompt(List<string> prompts)
    {
        int randomIndex = random.Next(prompts.Count);
        return prompts[randomIndex];
    }

    private void PerformAdditionalQuestions()
    {
        while (_duration > 0 && additionalQuestions.Count > 0)
        {
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            string randomPrompt = GetRandomPrompt(additionalQuestions);
            additionalQuestions.Remove(randomPrompt);
            Console.WriteLine(randomPrompt);

            DateTime startTime = DateTime.Now;
            List<string> itemsListed = new List<string>();
            TimeSpan elapsedTime = TimeSpan.Zero;

            do
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    itemsListed.Add(item);
                    elapsedTime = DateTime.Now - startTime;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a non-empty item.");
                }
            } while (elapsedTime.TotalSeconds < 4);
            _duration -= 4;
        }
    }
}