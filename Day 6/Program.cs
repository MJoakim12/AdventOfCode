using System;
using System.IO;
using System.Linq;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] startingFish = new long[10]; //From age -1 to 8
            long[] fish = new long[10]; //From age -1 to 8

            string[] input = new StreamReader("input.txt").ReadToEnd().Split(',');

            foreach (string entry in input) //Fill array
            {
                startingFish[Convert.ToInt64(entry) + 1]++;
            }

            startingFish.CopyTo(fish, 0);
            LetTheFishMultiply(fish, 80); //Answer Part 1

            startingFish.CopyTo(fish, 0);
            LetTheFishMultiply(fish, 256); //Answer Part 2
        }

        private static void LetTheFishMultiply(long[] fish, int days)
        {
            for (int m = 0; m < days; m++)
            {
                for (int i = 1; i < fish.Length; i++) //Shift array content left
                {
                    fish[i - 1] = fish[i];
                }

                fish[fish.Length - 1] = 0; //Set age 8 to zero

                fish[7] += fish[0]; //Add age -1 to age 6
                fish[9] += fish[0];//Add age -1 to age 8
                fish[0] = 0; //Set age -1 to 0
            }

            Console.WriteLine($"After {days} days, there are a total of {fish.Sum()} fish!");
        }
    }
}
