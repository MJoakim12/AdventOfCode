using System;
using System.Collections.Generic;
using System.IO;

namespace Day_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            List<string> input = new List<string>();

            //Read lines into list
            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            int zeroCounter;
            int oneCounter;

            string gammaRate = "";
            string epsilonRate = "";

            //Process
            for (int i = 0; i < 12; i++)
            {
                zeroCounter = 0;
                oneCounter = 0;

                foreach (string binary in input)
                {
                    switch (binary[i])
                    {
                        case '0': { zeroCounter++; break; }
                        case '1': { oneCounter++; break; }
                    }
                }

                if (oneCounter > zeroCounter) { gammaRate += '0'; epsilonRate += '1'; }
                else { gammaRate += '1'; epsilonRate += '0'; }
            }

            Console.WriteLine($"Gamma: {gammaRate}, Epsilon: {epsilonRate}");
            Console.WriteLine($"Power Consumption: {Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2)}");
        }
    }
}
