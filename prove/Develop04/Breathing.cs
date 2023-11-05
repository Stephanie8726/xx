using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        while (_duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Console.WriteLine("Now breathe out...");
            Console.WriteLine();
            Spinner(_duration >= 4 ? 4 : _duration);
            _duration -= 4;
        }
    }
}
