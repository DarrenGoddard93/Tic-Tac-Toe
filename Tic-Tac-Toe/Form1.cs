using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        
        bool winnerCheck = false;
        int counter = 0;
        int player;

        List<Button> buttons;
        Random RandomNumber = new Random();

        public Form1()
        {
            InitializeComponent();
            loadButtons();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Darren");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        
 public void loadButtons()
 {
     buttons = new List<Button> { buttonA1, buttonA2, buttonA3, buttonB1, buttonB2, buttonB3, buttonC1, buttonC2, buttonC3 };
 }
        


        public void UserClick(object sender, EventArgs e)
        {
            player = 1;
            Button ClickedButton = (Button)sender;
 
            ClickedButton.Text = "X";
            ClickedButton.Enabled = false;
            ClickedButton.BackColor = System.Drawing.Color.Cyan;

            buttons.Remove(ClickedButton); // Remove from array so AI cant select as well

            counter++;

            Console.WriteLine(counter);

            checkHorizWin();
            checkVertWin();
            checkDiagonalWin();
            displayWinners();
            AImoves.Start();


        }
        

        private void AImove(object sender, EventArgs e)
        {
            player = 2;
            int AIPosition = RandomNumber.Next(buttons.Count);

            buttons[AIPosition].Text = "O";
            buttons[AIPosition].Enabled = false;
            buttons[AIPosition].BackColor = System.Drawing.Color.Red;

            buttons.RemoveAt(AIPosition);

            counter++;

            Console.WriteLine(counter);

            checkHorizWin();
            checkVertWin();
            checkDiagonalWin();
            AImoves.Stop();
            displayWinners();
            

        }



        public void checkHorizWin()
        {
            //HORIZONTAL CHECKS
            if ((buttonA1.Text == buttonA2.Text) && (buttonA2.Text == buttonA3.Text) && (!buttonA1.Enabled))
            {
                winnerCheck = true;
            }
            else if ((buttonB1.Text == buttonB2.Text) && (buttonB2.Text == buttonB3.Text) && (!buttonB1.Enabled))
            {
                winnerCheck = true;
            }
            else if ((buttonC1.Text == buttonC2.Text) && (buttonC2.Text == buttonC3.Text) && (!buttonC1.Enabled))
            {
                winnerCheck = true;
            }
        }

        public void checkVertWin()
        {
            //VERTICAL CHECKS
            if ((buttonA1.Text == buttonB1.Text) && (buttonB1.Text == buttonC1.Text) && (!buttonA1.Enabled))
            {
                winnerCheck = true;
            }
            else if ((buttonA2.Text == buttonB2.Text) && (buttonB2.Text == buttonC2.Text) && (!buttonA2.Enabled))
            {
                winnerCheck = true;
            }
            else if ((buttonA3.Text == buttonB3.Text) && (buttonB3.Text == buttonC3.Text) && (!buttonA3.Enabled))
            {
                winnerCheck = true;
            }
        }
        
        public void checkDiagonalWin()
        {
            //DIAGONAL CHECKS
            if ((buttonA1.Text == buttonB2.Text) && (buttonB2.Text == buttonC3.Text) && (!buttonA1.Enabled))
            {
                winnerCheck = true;
            }
            else if ((buttonA3.Text == buttonB2.Text) && (buttonB2.Text == buttonC1.Text) && (!buttonA3.Enabled))
            {
                winnerCheck = true;
            }
        }



        public void displayWinners()
        {
            if (winnerCheck == true)
            {   
                Console.WriteLine("You Win");
                MessageBox.Show("Player " + player + " YOU WIN!", "Winner");
                Application.Restart();      
            }
            else
            {
                if (counter == 9)
                {
                    MessageBox.Show("It's a draw", "DRAW");
                    Console.WriteLine("No Winner yet");
                    Application.Restart();
                }
            }
        }


    }
}
