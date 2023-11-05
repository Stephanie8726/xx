using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

class Reflection : Activity
{
    private List<string> prompts = new List<string>
    {
        "---Think of a time when you stood up for someone else.---",
        "---Think of a time when you did something really difficult.---",
        "---Think of a time when you helped someone in need.---",
        "---Think of a time when you did something truly selfless.---"
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflection() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        string randomPrompt = GetRandomPrompt(prompts);
        prompts.Remove(randomPrompt);
        Console.WriteLine(randomPrompt);

        while (_duration > 0 && questions.Count > 0)
        {
            Console.WriteLine($"> {questions[0]}");
            Spinner(4);
            questions.RemoveAt(0);
            _duration -= 4;
        }
    }

    private string GetRandomPrompt(List<string> prompts)
    {
        int randomIndex = random.Next(prompts.Count);
        return prompts[randomIndex];
    }
}