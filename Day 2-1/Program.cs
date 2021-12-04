using System;
using System.Collections.Generic;
using System.IO;

namespace Day_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int horizontal = 0;
            int depth = 0;

            StreamReader sr = new StreamReader("input.txt");
            List<string> input = new List<string>();

            //Read lines into list
            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            //Process commands
            string direction = "";
            int amount = 0;

            foreach (string command in input)
            {
                direction = command.Split(' ')[0];
                amount = Convert.ToInt32(command.Split(' ')[1]);

                switch (direction)
                {
                    case "forward": { horizontal += amount; break; }
                    case "up": { depth -= amount; break; }
                    case "down": { depth += amount; break; }
                }
            }

            Console.WriteLine($"Horizontal: {horizontal}");
            Console.WriteLine($"Depth: {depth}");
            Console.WriteLine($"Mulitplied: {horizontal * depth}");
        }
    }
}
