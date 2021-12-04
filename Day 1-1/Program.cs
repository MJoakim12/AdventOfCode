using System;

namespace Day_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string text = System.IO.File.ReadAllText("input.txt");
            string[] split = text.Split('\n');

            //Convert to int[]
            int[] numbers = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                numbers[i] = Convert.ToInt32(split[i]);
            }

            //Run through list
            int lastNumber = numbers[0];
            int increaseCounter = 0;

            Console.WriteLine($"{lastNumber} (N/A - no previous measurement)");

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > lastNumber)
                {
                    increaseCounter++;
                    Console.WriteLine($"{numbers[i]} (INCREASED)");
                }
                else
                {
                    Console.WriteLine($"{numbers[i]} (decreased)");
                }

                lastNumber = numbers[i];
            }

            Console.WriteLine("Increased: " + increaseCounter + " times");
        }
    }
}
