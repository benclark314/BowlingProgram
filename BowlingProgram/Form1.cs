using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingProgram
{
    public partial class Form1 : Form
    {
        public BowlingGame thisGame;

        public Form1()
        {
            InitializeComponent();
            thisGame = new BowlingGame();
        }

        //Compute the score from values entered in the text fields, and then print it.
        private void button1_Click(object sender, EventArgs e)
        {
            //Enter the text fields into the BowlingGame array
            try
            {
                thisGame.setShotValue(1, 1, textBox1.Text);
                thisGame.setShotValue(1, 2, textBox2.Text);
                thisGame.setShotValue(2, 1, textBox3.Text);
                thisGame.setShotValue(2, 2, textBox4.Text);
                thisGame.setShotValue(3, 1, textBox5.Text);
                thisGame.setShotValue(3, 2, textBox6.Text);
                thisGame.setShotValue(4, 1, textBox7.Text);
                thisGame.setShotValue(4, 2, textBox8.Text);
                thisGame.setShotValue(5, 1, textBox9.Text);
                thisGame.setShotValue(5, 2, textBox10.Text);
                thisGame.setShotValue(6, 1, textBox11.Text);
                thisGame.setShotValue(6, 2, textBox12.Text);
                thisGame.setShotValue(7, 1, textBox13.Text);
                thisGame.setShotValue(7, 2, textBox14.Text);
                thisGame.setShotValue(8, 1, textBox15.Text);
                thisGame.setShotValue(8, 2, textBox16.Text);
                thisGame.setShotValue(9, 1, textBox17.Text);
                thisGame.setShotValue(9, 2, textBox18.Text);
                thisGame.setShotValue(10, 1, textBox19.Text);
                thisGame.setShotValue(10, 2, textBox20.Text);
                thisGame.setAdditionalShotValue(textBox21.Text);
            }
            catch (System.IndexOutOfRangeException exception)
            {
                System.Console.WriteLine(exception.Message);
                MessageBox.Show("Error in code: \n" + exception.Message, "Internal Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //Show error messages if the user enters incorrect values:
            if (thisGame.hasInvalidEntry())
            {
                MessageBox.Show("Please enter valid numbers between 0 and 10", "Invalid Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (thisGame.frameExceedsTenPoints())
            {
                MessageBox.Show("You cannot score more than ten points in a given frame.", "Invalid Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Compute the score and print it on the form.
            else
            {
                try
                {
                    label12.Text = thisGame.computeScore().ToString();
                }
                catch (System.IndexOutOfRangeException exception)
                {
                    System.Console.WriteLine(exception.Message);
                    MessageBox.Show("Error in code: \n" + exception.Message, "Internal Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Make the additional shot visible if the player qualifies for an extra shot
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox19.Text, out int i) && int.TryParse(textBox20.Text, out int j))
            {
                if (j > 10 - i)
                {
                    MessageBox.Show("Your scores for the last frame are impossible to make!", "Invalid Entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (thisGame.playerGetsAddionalShot(textBox19.Text, textBox20.Text))
            {
                label15.Visible = true;
                textBox21.Visible = true;
            }
            else
            {
                label15.Visible = false;
                textBox21.Visible = false;
                textBox21.Clear();
            }
        }

        //Make the additional shot visible if the player qualifies for an extra shot
        private void textBox20_TextChanged(object sender, EventArgs e)
        {

            if (int.TryParse(textBox19.Text, out int i) && int.TryParse(textBox20.Text, out int j))
            {
                if (j > 10 - i)
                {
                    MessageBox.Show("Your scores for the last frame are impossible to make!", "Invalid Entry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (thisGame.playerGetsAddionalShot(textBox19.Text, textBox20.Text))
            {
                label15.Visible = true;
                textBox21.Visible = true;
            }
            else
            {
                label15.Visible = false;
                textBox21.Visible = false;
                textBox21.Clear();
            }
        }

        //Clear all textbox fields
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
        }
    }
}
