using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace Hangman
{
        public partial class Hangman : Form
    {
        int wordlistsize, RandomNumber, lives, missingLetters;
        string chosenWord, hiddenWord, usedLetters;
        char userGuess;
        bool success, validguess;
        Pen blackpen = new Pen(Color.FromArgb(255, 0, 0, 0), 3.0f);
        Pen invisiblepen = new Pen(Color.FromArgb(0, 0, 0, 0), 3.0f);

        Random rnd = new Random();
        HangDraw poorJoe = new HangDraw();
        string[] wordlist = File.ReadAllLines("wordlist");  //wordlist is the text file with words
        private SoundPlayer Player = new SoundPlayer();
              

        private void GetTextonClick(object sender, EventArgs e)
        {
            ResetLabelStatus();
            
            System.Windows.Forms.Button buttonx = sender as System.Windows.Forms.Button;
            // label3.Text = buttonx.Text;
            userGuess = buttonx.Text.ToString()[0];
                 
            if (usedLetters == "") validguess = true;

            // label3.Text = userGuess.ToString();
            for (int i = 0; i < usedLetters.Length; i++)
            {
                validguess = true;
                if (userGuess == usedLetters[i])
                {
                    label8.BackColor = Color.Red;
                    label8.ForeColor = Color.White;
                    label8.Text = "You've already used that letter. Try again.";
                    validguess = false;
                    break;
                }

            }

            if (validguess == true) usedLetters += userGuess;
            label6.Text = usedLetters;

            bool hit = false;

            for (int i = 0; i < chosenWord.Length; i++)
            {
                if (validguess && userGuess == chosenWord[i])
                {
                    //hiddenWord.[i + 1] = userGuess;
                    // label3.Text = hiddenWord;

                    //hiddenWord = hiddenWord.Substring(i*2, 2) + userGuess + " ";
                    // hiddenWord.Substring(i,1) = userGuess.ToString();

                    char[] chars = hiddenWord.ToCharArray();
                    chars[i*2] = userGuess;
                    hiddenWord = new string(chars);

                    missingLetters--;
                    hit = true;
                    PlaySounds("yay");
                }
            }

            label2.Text = hiddenWord;
            label9.Text = $"Missing Letters {missingLetters.ToString()}";
            if (validguess == true && hit == false)
            {
                lives--;
                switch (lives)
                {
                    case >= 7:
                        PlaySounds("fail");
                        break;

                    case <= 6 and >= 4:
                        PlaySounds("fail2");
                        break;
                    default:
                        PlaySounds("fail3");
                        break;
                }
               
                label5.Text = "Lives " + lives.ToString();
            }

            this.Invalidate();

            if (missingLetters <= 0) 
            {
                PlaySounds("winner");
                FinalDialog();
            }

            if (lives <= 0)
            {
                PlaySounds("failure");
                label4.Visible = true;
                FinalDialog();
            }
             }


        
        
        public Hangman()
        {
           InitializeComponent();
        }

        private void Hangman_Load(object sender, EventArgs e)
        {
            lives = 10;
            usedLetters = "";
            success = false;
            validguess = false;
            RandomNumber = rnd.Next((wordlist.Length));
            

            chosenWord = (wordlist[RandomNumber]).ToUpper();
            hiddenWord = hideWords(chosenWord);
            missingLetters = chosenWord.Length;

            label4.Text = chosenWord;
            label5.Text = "Lives " + lives.ToString();
            label6.Text = usedLetters;
               

            }
                      

        private string hideWords(string str)
        {
            string underl = "";
            for (int i = 0; i < chosenWord.Length; i++)
            {
                underl += "_ ";
                label2.Text = underl;
            }

            return underl;
        }

        private void ResetLabelStatus() 
        {
            label8.BackColor = SystemColors.Control;
            label8.ForeColor = SystemColors.Control;
        }

    }
}