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
            int increaseCounter = 0;

            int lastSum = numbers[0] + numbers[1] + numbers[2];
            int currentSum;

            Console.WriteLine($"{lastSum} (N/A - no previous measurement)");

            for (int i = 5; i < numbers.Length; i++)
            {
                currentSum = numbers[i - 2] + numbers[i - 1] + numbers[i];

                if (currentSum > lastSum)
                {
                    increaseCounter++;
                    Console.WriteLine($"{currentSum} (INCREASED)");
                }
                else
                {
                    Console.WriteLine($"{currentSum} (decreased)");
                }

                lastSum = currentSum;
            }

            Console.WriteLine("Increased: " + increaseCounter + " times");
        }
    }
}
