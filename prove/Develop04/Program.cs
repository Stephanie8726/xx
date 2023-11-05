using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 4)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (choice >= 1 && choice <= 3)
                {
                    Activity activity = null;

                    if (choice == 1)
                    {
                        activity = new Breathing();
                    }
                    else if (choice == 2)
                    {
                        activity = new Reflection();
                    }
                    else if (choice == 3)
                    {
                        activity = new Listing();
                    }

                    if (activity != null)
                    {
                        activity.RunActivity();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
