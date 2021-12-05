using System;
using System.IO;
using System.Collections.Generic;

namespace Day_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read input
            //StreamReader sr = new StreamReader("input.txt");
            StreamReader sr = new StreamReader("testinput.txt");
            List<string> input = new List<string>();

            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            int maxX, maxY;

            //Get max x and y values to create array
            GetMax(input, out maxX, out maxY);
            int[,] lineTracker = new int[maxX + 1, maxY + 1];

            //"Draw" lines into array
            DrawLines(input, lineTracker);

            //Test output
            string output;

            for (int i = 0; i < lineTracker.GetLength(1); i++)
            {
                output = "";

                for (int j = 0; j < lineTracker.GetLength(0); j++)
                {
                    output += lineTracker[j, i].ToString();
                }

                Console.WriteLine(output);
            }

            //Check for 2+
            int crossings = 0;

            for (int i = 0; i < lineTracker.GetLength(0); i++)
            {
                for (int j = 0; j < lineTracker.GetLength(1); j++)
                {
                    if (lineTracker[i, j] >= 2)
                    {
                        crossings++;
                    }
                }
            }

            Console.WriteLine(crossings);
        }

        static void GetMax(List<string> input, out int maxX, out int maxY)
        {
            int _maxX = 0;
            int _maxY = 0;

            int temp = 0;

            foreach (string entry in input)
            {
                //x1
                temp = Convert.ToInt32(entry.Split(' ')[0].Split(',')[0]);
                if (temp > _maxX) _maxX = temp;

                //x2
                temp = Convert.ToInt32(entry.Split(' ')[1].Split(',')[0]);
                if (temp > _maxX) _maxX = temp;

                //y1
                temp = Convert.ToInt32(entry.Split(' ')[0].Split(',')[1]);
                if (temp > _maxY) _maxY = temp;

                //y2
                temp = Convert.ToInt32(entry.Split(' ')[1].Split(',')[1]);
                if (temp > _maxY) _maxY = temp;
            }

            maxX = _maxX;
            maxY = _maxY;
        }

        static void DrawLines(List<string> input, int[,] tracker)
        {
            int[] coords = new int[4];

            foreach (string entry in input)
            {
                coords[0] = Convert.ToInt32(entry.Split(' ')[0].Split(',')[0]);
                coords[1] = Convert.ToInt32(entry.Split(' ')[0].Split(',')[1]);
                coords[2] = Convert.ToInt32(entry.Split(' ')[1].Split(',')[0]);
                coords[3] = Convert.ToInt32(entry.Split(' ')[1].Split(',')[1]);

                //coords[0] -> x1 | coords[2] -> x2 | coords[1] -> y1 | coords[3] -> y2 

                if ((coords[0] - coords[2]) == 0)
                {
                    //X equal
                    int length = coords[3] - coords[1];
                    bool goesNegative = false;

                    //Make length positive and add 1
                    if (length < 0) { length *= -1; goesNegative = true; }
                    length++;

                    for (int i = 0; i < length; i++)
                    {
                        //Increase that point by one (X stays constant)
                        if (goesNegative)
                        {
                            tracker[coords[0], coords[1] - i]++;
                        }
                        else
                        {
                            tracker[coords[0], coords[1] + i]++;
                        }

                    }
                }
                else if ((coords[1] - coords[3]) == 0)
                {
                    //Y equal
                    int length = coords[2] - coords[0];
                    bool goesNegative = false;

                    //Make length positive and add 1
                    if (length < 0) { length *= -1; goesNegative = true; }
                    length++;

                    for (int i = 0; i < length; i++)
                    {
                        //Increase that point by one (Y stays constant)
                        if (goesNegative)
                        {
                            tracker[coords[0] - i, coords[3]]++;
                        }
                        else
                        {
                            tracker[coords[0] + i, coords[3]]++;
                        }

                    }
                }
                else
                {
                    //This line is diagonal

                }
            }
        }
    }
}
