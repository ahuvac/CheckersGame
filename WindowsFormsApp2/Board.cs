﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Board
    {
        const int BOARD_SIZE = 8;
        const int SQUARE_SIZE = 50;
        public Board SetUpBoard()
        {
            cbDifficulty.SelectedIndex = 0;
            int left = 1;
            int top = 1;
            PictureBox[,] squares = new PictureBox[BOARD_SIZE, BOARD_SIZE];
            Color[] colors = new Color[] { Color.Black, Color.Red };
            for (int row = 0; row < BOARD_SIZE; row++)
            {
                left = 1;
                Player player;
                if (!checkBoxColor.Checked)
                {
                    player = Player.WHITE;
                }
                else
                {
                    player = Player.BLACK;
                }
                if (row % 2 == 0)
                {
                    colors[0] = Color.Black;
                    colors[1] = Color.Red;
                }
                else
                {
                    colors[0] = Color.Red;
                    colors[1] = Color.Black;
                }
                for (int col = 0; col < BOARD_SIZE; col++)
                {
                    squares[row, col] = new PictureBox();
                    squares[row, col].BackColor = colors[(col % 2 == 0) ? 1 : 0];
                    squares[row, col].Location = new Point(left, top);
                    squares[row, col].Size = new Size(SQUARE_SIZE, SQUARE_SIZE);
                    left += SQUARE_SIZE;
                    if (row < (BOARD_SIZE / 2) - 1 && squares[row, col].BackColor == Color.Black)
                    {
                        squares[row, col].Image = Properties.Resources.Blue2;
                        squares[row, col].Name = ("Blue2");
                    }
                    else if (row > (BOARD_SIZE / 2) && squares[row, col].BackColor == Color.Black)
                    {
                        squares[row, col].Image = Properties.Resources.Purple1;
                        squares[row, col].Name = ("Purple1");
                    }
                    squares[row, col].SizeMode = PictureBoxSizeMode.Zoom;
                    panel1.Controls.Add(squares[row, col]);
                    squares[row, col].MouseHover += (sender2, e2) =>
                    {
                        PictureBox pictureBoxHovered = sender2 as PictureBox;
                        if (pictureBoxHovered.BackColor == Color.Black)
                        {
                            pictureBoxHovered.BackColor = Color.Gray;
                        }
                    };
                    squares[row, col].MouseLeave += (sender2, e2) =>
                    {
                        PictureBox pictureBoxLeave = sender2 as PictureBox;
                        if (pictureBoxLeave.BackColor == Color.Gray)
                        {
                            pictureBoxLeave.BackColor = Color.Black;
                        }
                    };

                    squares[row, col].Click += (sender3, e3) =>
                    {
                        PictureBox pictureBoxClicked = sender3 as PictureBox;
                        int x = pictureBoxClicked.Location.X;
                        int y = pictureBoxClicked.Location.Y;
                        MessageBox.Show(string.Format("x: {0} y: {1}", y, x));
                        int countX = 1;
                        int countY = 1;
                        for (int square = 0; square < 8; square++)
                        {
                            if (x > SQUARE_SIZE)
                            {
                                x -= SQUARE_SIZE;
                                ++countX;
                            }
                            if (y > SQUARE_SIZE)
                            {
                                y -= SQUARE_SIZE;
                                ++countY;
                            }
                        }
                        MessageBox.Show(string.Format("Row: {0} Column: {1}", countY, countX));
                    };

                    panel1.Controls.Add(squares[row, col]);
                }
                top += SQUARE_SIZE;
                Board board = panel1.Controls.addAll(squares);
            }
            //change this
            Board board = new Board();
            return board;
        }
       
    }
}