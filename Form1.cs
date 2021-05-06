using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class Form1 : Form
    {
        //set up random number and real value variable
        Random randomNum = new Random();

        int realValue;

        public Form1()
        {
            InitializeComponent();

            //pick a random number
            realValue = randomNum.Next(1, 101);
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            //set up variables for the guess, and distance
            int guess;
            int distance;
            
            try
            {
                //store the guess, and calculate the absolute distance from the real value
                guess = Convert.ToInt32(inputBox.Text);
                distance = realValue - guess;
                int absoluteDistance = Math.Abs(distance);

                //display message depending on if the player is above, below, or right on the real number
                if (guess > realValue)
                { 
                    outputLabel.Text = "Too High!";
                    inputBox.Clear();
                }
                else if (guess < realValue)
                {
                    outputLabel.Text = "Too Low!";
                    inputBox.Clear();
                }
                else
                { 
                    outputLabel.Text = "You Win!";
                    distanceLabel.Visible = false;
                    guessButton.Enabled = false;
                    //enable the reset button
                    resetButton.Visible = true;
                }

                //display a message depending on how large the absolute distance is 
                if (absoluteDistance > 50)
                {
                    distanceLabel.Text = "Freezing!";
                }
                else if (absoluteDistance > 25)
                {
                    distanceLabel.Text = "Cold";
                }
                else if (absoluteDistance > 15)
                {
                    distanceLabel.Text = "Cool";
                }
                else if (absoluteDistance > 10)
                {
                    distanceLabel.Text = "Warm";
                }
                else if(absoluteDistance >= 5)
                {
                    distanceLabel.Text = "Hot";
                }
                else
                {
                    distanceLabel.Text = "Boiling!";
                }
            }
            catch
            {
                //display error message if invalid number is guessed
                outputLabel.Text = "Please guess a Real Number!";
                inputBox.Clear();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //pick a new random number, reset all values and text boxes
            realValue = randomNum.Next(1, 101);
            outputLabel.Text = null;
            distanceLabel.Text = null;
            distanceLabel.Visible = true;
            guessButton.Enabled = true;
            resetButton.Visible = false;
            inputBox.Clear();
        }
    }
}
