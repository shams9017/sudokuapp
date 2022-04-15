using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var textWasRead = sudoku.ReadText();
            if (textWasRead)
            {
                var inputBoard = sudoku.GetBoard();
                DrawBoard(inputBoard);
            }
            else
            {
                int[,] emptyBoard = new int[9, 9];
                DrawBoard(emptyBoard);
            }

        }

        private void button10_Click(object sender, EventArgs e) // this is the solve button
        {
            // please wait button
            MessageBoxButtons pleaseWait = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show("Please Click Ok and Wait a Few Seconds While The Board is Being Solved.", "Sudoku Challenge", pleaseWait);


            var inputBoard = sudoku.GetBoard();
            int[,] solvedBoard = new int[9, 9];
            if (sudoku.Solve(inputBoard, solvedBoard))
            {
                var finalBoard = sudoku.GetSolvedBoard();
                sudoku.SetCurrentBoard(finalBoard);

                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (Controls[i] is Button)
                    {
                        Controls.RemoveAt(i);
                        i--;
                    }
                }

                DrawBoard(finalBoard);
            }
        }

        Sudoku sudoku = new Sudoku("sample2.txt"); // Change the file name parameter here to test other texts

        private void DrawBoard(int[,] board)
        {

            var newBoard = board;

            int top = 50;
            int left = 50;
            int width = 50;
            int height = 50;
            int buttonNum = 1;
            Font font = new Font("Arial", 12, FontStyle.Bold);

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {

                    Button button = new Button();
                    button.Height = height;
                    button.Width = width;
                    button.Location = new Point((left * j) - j, (top * i) - j);
                    button.Name = buttonNum.ToString();
                    var boardEntry = (newBoard[i - 1, j - 1]).ToString();

                    if (boardEntry == "0")
                    {
                        boardEntry = "";
                    }
                    button.Text = boardEntry;
                    button.Font = font;
                    this.Controls.Add(button);


                }


            }

        }
    }
}
