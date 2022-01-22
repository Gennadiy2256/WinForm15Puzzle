using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15Puzzle
{
    public partial class Form1 : Form
    {
        private readonly PuzzleBuilderRO builder;
        private Button[,] buttons;

        private bool gameStart = false;

        public Form1(PuzzleBuilderRO builder)
        {
            this.builder = builder;
            buttons = new Button[this.builder.Side, this.builder.Side];
            InitializeComponent();
        }

        private void ClickButtonStart(object sender, EventArgs e)
        {
            builder.SortButtons();

            if (!gameStart)
            {
                ChangeFlagStartTheGame();
                buttonStart.Location = new Point(400, 40);
                LoadButtons();
            }
            
            builder.ShuffleButtons();
            DrawText();
        }

        private void ChangeFlagStartTheGame()
        {
            gameStart = true;
        }

        private void ClickButtonMove(object sender, EventArgs e)
        {
            // Take out pressed button
            Button btn = (Button)sender;
            //Detect position by property "Tag"
            int i = ((Point)btn.Tag).X;
            int j = ((Point)btn.Tag).Y;
            int voidX = builder.VoidX;
            int voidY = builder.VoidY;

            //If pressed button are left or right or top or bottom near void button
            if (builder.IsMovePossible(i, j))
            {
                DrawNewText(voidX, voidY);
                DrawNewVoidText(i, j);

                if (builder.CheckVictory())
                {
                    ShowVictoryMessage();
                }
            }
        }

        #region --==## UI PART ##==--

        private void LoadButtons()
        {
            for (int i = 0; i < builder.Side; i++)
            {
                for (int j = 0; j < builder.Side; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point),
                        Location = new Point(10 + j * 90, 40 + i * 90),
                        Name = "button" + Convert.ToString(builder.NumbersArray[i, j]),
                        Size = new Size(90, 90),
                        Tag = new Point(i, j)
                    };

                    buttons[i, j].Click += new EventHandler(ClickButtonMove);
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void DrawText()
        {
            for (int i = 0; i < builder.Side; i++)
            {
                for (int j = 0; j < builder.Side; j++)
                {
                    if (builder.NumbersArray[i, j] != builder.Void)
                    {
                        buttons[i, j].Text = Convert.ToString(builder.NumbersArray[i, j]);//разница?
                    }
                    else
                    {
                        buttons[i, j].Text = "";
                    }
                }
            }
        }

        private void DrawNewText(int voidX, int voidY)
        {
            buttons[voidX, voidY].Text = builder.NumbersArray[voidX, voidY].ToString();//разница? 
        }

        private void DrawNewVoidText(int i, int j)
        {
            buttons[i, j].Text = "";
        }

        private void ShowVictoryMessage()
        {
            string msg = "VICTORY";
            MessageBox.Show(string.Format("{0, 18}", msg));
        }

        #endregion






    }
}
