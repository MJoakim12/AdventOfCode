using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_3_2
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

            int oxygenRating = 0;
            int co2Rating = 0;

            int zeroCounter;
            int oneCounter;
            char toRemove;

            //Process oxygen generator
            for (int i = 0; i < 12; i++)
            {
                if (input.Count == 1)
                {
                    break;
                }

                List<string> filteredInput = new List<string>();

                zeroCounter = 0;
                oneCounter = 0;

                //First run
                foreach (string binary in input)
                {
                    switch (binary[i])
                    {
                        case '0': { zeroCounter++; break; }
                        case '1': { oneCounter++; break; }
                    }
                }

                if (oneCounter >= zeroCounter) toRemove = '0';
                else toRemove = '1';

                //Remove items
                foreach (string binary in input.ToList())
                {
                    if (binary[i] != toRemove)
                    {
                        filteredInput.Add(binary);
                    }
                }

                input = filteredInput.ToList();
            }

            Console.WriteLine(input.Last());
            oxygenRating = Convert.ToInt32(input.Last(), 2);
            Console.WriteLine(oxygenRating);

            sr = new StreamReader("input.txt");
            input = new List<string>();

            //Read lines into list
            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            //Process CO2
            for (int i = 0; i < 12; i++)
            {
                if (input.Count == 1)
                {
                    break;
                }

                List<string> filteredInput = new List<string>();

                zeroCounter = 0;
                oneCounter = 0;

                //First run
                foreach (string binary in input)
                {
                    switch (binary[i])
                    {
                        case '0': { zeroCounter++; break; }
                        case '1': { oneCounter++; break; }
                    }
                }

                if (oneCounter >= zeroCounter) toRemove = '0';
                else toRemove = '1';

                //Remove items
                foreach (string binary in input.ToList())
                {
                    if (binary[i] == toRemove)
                    {
                        filteredInput.Add(binary);
                    }
                }

                input = filteredInput.ToList();
            }

            Console.WriteLine(input.Last());
            co2Rating = Convert.ToInt32(input.Last(), 2);
            Console.WriteLine(co2Rating);

            Console.WriteLine(co2Rating * oxygenRating);

            //Console.WriteLine($"Gamma: {gammaRate}, Epsilon: {epsilonRate}");
            //Console.WriteLine($"Power Consumption: {Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2)}");
        }
    }
}
