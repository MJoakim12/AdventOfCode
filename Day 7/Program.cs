using System;
using System.IO;
using System.Linq;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new StreamReader("input.txt").ReadToEnd().Split(',');
            int[] crabPositions = new int[input.Length];

            //Convert to int array
            for (int i = 0; i < input.Length; i++)
            {
                crabPositions[i] = Convert.ToInt32(input[i]);
            }

            //Find max and min
            int minPosition = crabPositions.Min();
            int maxPosition = crabPositions.Max();

            CalcFuel(minPosition, maxPosition, crabPositions, 1);
            CalcFuel(minPosition, maxPosition, crabPositions, 2);
        }

        static void CalcFuel(int minPosition, int maxPosition, int[] crabPositions, int part)
        {
            int leastFuelRequired = int.MaxValue;
            int mostEfficientPosition = -1;

            for (int i = minPosition; i < maxPosition; i++)
            {
                int runningFuelTally = 0;

                for (int j = 0; j < crabPositions.Length; j++)
                {
                    if (part == 1)
                    {
                        runningFuelTally += Math.Abs(i - crabPositions[j]);
                    }
                    else
                    {
                        //Gaußsche Summenformel (n*(n+1))/2
                        int n = Math.Abs(i - crabPositions[j]);
                        runningFuelTally += (n * (n + 1)) / 2;
                    }

                    if (runningFuelTally >= leastFuelRequired)
                    {
                        break;
                    }
                }

                if (runningFuelTally < leastFuelRequired)
                {
                    leastFuelRequired = runningFuelTally;
                    mostEfficientPosition = i;
                }
            }

            Console.WriteLine($"Part {part} - The most efficient position is {mostEfficientPosition}, using up only {leastFuelRequired} fuel!");
        }
    }
}
