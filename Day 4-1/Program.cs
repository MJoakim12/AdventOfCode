using System;
using System.Collections.Generic;
using System.IO;

namespace Day_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BingoBoard> boards = new List<BingoBoard>();
            List<int> draw = new List<int>();

            #region Read boards
            StreamReader sr = new StreamReader("boards.txt");
            string boardInput;

            while (!sr.EndOfStream)
            {
                boardInput = "";

                for (int i = 0; i < 5; i++)
                {
                    boardInput += sr.ReadLine();
                    boardInput += " ";
                }

                boards.Add(new BingoBoard(boardInput.Split(' ', StringSplitOptions.RemoveEmptyEntries)));

                sr.ReadLine();
            }
            #endregion

            #region Read draw
            sr = new StreamReader("draws.txt");

            string temp = sr.ReadLine();
            string[] temp2 = temp.Split(',');

            foreach (string number in temp2)
            {
                draw.Add(Convert.ToInt32(number));
            }
            #endregion

            //Run through draws
            for (int i = 0; i < draw.Count; i++)
            {
                //Console.WriteLine($"This is the {i + 1}th draw.");
                //Console.WriteLine("-----------------------");
                //Console.WriteLine();

                //Get 5 draws
                int currentDraw = draw[i];

                //Mark boards
                foreach (BingoBoard board in boards)
                {
                    board.MarkBoard(currentDraw);
                }

                //Check for Bingo
                foreach (BingoBoard board in boards)
                {
                    //Check if Board already won, if yes, skip
                    if (!board.HasWon)
                    {
                        //If bingo is found, return marked/unmarked multiplication
                        if (board.HasBingo())
                        {
                            Console.WriteLine("BINGO FOUND!");
                            Console.WriteLine($"Winning Number: {draw[i]}\n");

                            board.PrintBoard();

                            board.HasWon = true;

                            Console.WriteLine($"Bingo Board Score: {draw[i] * board.GetUnmarkedSum()}");
                            Console.WriteLine($"------------------------------");
                        }
                    }
                }
            }
        }
    }

    class BingoBoard
    {
        private int[,] board = new int[5, 5];
        private bool[,] boardMarks = new bool[5, 5];
        private bool hasWon = false;

        public BingoBoard(string[] numbers)
        {
            int major;
            int minor;

            for (int i = 0; i < 25; i++)
            {
                major = i / 5;
                minor = i % 5;

                board[major, minor] = Convert.ToInt32(numbers[i]);
                boardMarks[major, minor] = false;
            }
        }

        #region Properties

        public bool HasWon
        {
            get { return hasWon; }
            set { hasWon = value; }
        }

        #endregion

        #region Methods

        public void MarkBoard(int draw)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == draw)
                    {
                        boardMarks[i, j] = true;
                    }
                }
            }
        }

        public bool HasBingo()
        {
            return (HasBingoRow() || HasBingoColumn());
        }

        private bool HasBingoRow()
        {
            for (int i = 0; i < 5; i++)
            {
                if (boardMarks[0, i] && boardMarks[1, i] && boardMarks[2, i] && boardMarks[3, i] && boardMarks[4, i])
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasBingoColumn()
        {
            for (int i = 0; i < 5; i++)
            {
                if (boardMarks[i, 0] && boardMarks[i, 1] && boardMarks[i, 2] && boardMarks[i, 3] && boardMarks[i, 4])
                {
                    return true;
                }
            }

            return false;
        }

        public int GetMarkedSum()
        {
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (boardMarks[i, j])
                    {
                        sum += board[i, j];
                    }
                }
            }

            return sum;
        }

        public int GetUnmarkedSum()
        {
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!boardMarks[i, j])
                    {
                        sum += board[i, j];
                    }
                }
            }

            return sum;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //Check if marked, if yes print in green
                    if (boardMarks[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(board[i, j].ToString().PadLeft(2, ' ') + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(board[i, j].ToString().PadLeft(2, ' ') + " ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        #endregion
    }
}
