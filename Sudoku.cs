using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuapp
{
    public class Sudoku : ISudokuChallenge
    {
        public string FileName;

        public int[,] BoardArray = new int[9, 9];

        public int[,] SolvedBoard = new int[9, 9];



        public Sudoku(string fileName)
        {
            FileName = fileName;
        }

        public bool ReadText()
        {
            string text = File.ReadAllText(FileName);
            string finalText = text.Replace("\n", "").Replace("\r", "").Replace("|", "").Replace(".", "0").Replace("+", "").Replace("-", "").Replace(" ", "");

            bool textWasRead = Parse(finalText, BoardArray);
            return textWasRead;

        }

        public int[,] GetBoard()
        {
            return BoardArray;
        }

        public int[,] GetSolvedBoard()
        {
            return SolvedBoard;
        }


        public void SetCurrentBoard(int[,] currentBoard)
        {
            BoardArray = currentBoard;
        }


        public bool CheckValidEntry(int[,] board, int row, int col, int entry)
        {
            for (int i = 0; i < 9; i++)
            {
                // row  
                if (board[i, col] != 0 && board[i, col] == entry)
                    return false;
                // column  
                if (board[row, i] != 0 && board[row, i] == entry)
                    return false;
                // block  
                if (board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] != 0 && board[3 * (row / 3) + i / 3, 3 * (col / 3) + i % 3] == entry)
                    return false;
            }
            return true;
        }

        public bool Parse(string content, int[,] board)
        {
            List<List<int>> numbers = new List<List<int>>();
            for (int i = 0; i < 81; i += 9)
            {
                var line = content.Substring(i, 9);
                List<int> row = new List<int>();
                foreach (char digit in line)
                {
                    row.Add(int.Parse(digit.ToString()));
                }
                numbers.Add(row);

            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = numbers[i][j];
                }
            }
            BoardArray = board;

            if (board.Length == 81)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool Solve(int[,] inputBoard, int[,] solvedBoard)
        {
            for (int i = 0; i < inputBoard.GetLength(0); i++)
            {
                for (int j = 0; j < inputBoard.GetLength(1); j++)
                {
                    if (inputBoard[i, j] == 0)
                    {
                        for (int k = 1; k <= 9; k++)
                        {
                            if (CheckValidEntry(inputBoard, i, j, k))
                            {
                                inputBoard[i, j] = k;

                                if (Solve(inputBoard, solvedBoard))
                                {
                                    SolvedBoard = inputBoard;
                                    return true;
                                }
                                else
                                {
                                    inputBoard[i, j] = 0;
                                }

                            }
                        }
                        return false;
                    }
                }
            }
            SolvedBoard = inputBoard;

            return true;
        }
    }
}
