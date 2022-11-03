using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public partial class Hangman : Form
    {

       

        protected override void OnPaint(PaintEventArgs e)
        {
            int manStatus;
            
            Graphics g = e.Graphics;


           // Pen blackpen = new Pen(Color.FromArgb(255,0,0,0), 3.0f);
            
            
            // Pen DrawingPen;

            // g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;


            manStatus = 10 - lives;
            if (missingLetters <= 0) manStatus = 11; // Not hanged
            label10.Text = manStatus.ToString();

            switch (manStatus)
            {
                case 1:
                    poorJoe.basegallows = blackpen;
                    break;
                case 2:
                    poorJoe.post = blackpen;
                    break;
                case 3:
                    poorJoe.pole = blackpen;
                    break;
                case 4:
                    poorJoe.rope = blackpen;
                    break;
                case 5:
                    poorJoe.head = blackpen;
                    break;
                case 6:
                    poorJoe.torso = blackpen;
                    break;
                case 7:
                    poorJoe.rightarm = blackpen;
                    break;
                case 8:
                    poorJoe.leftarm = blackpen;
                    break;
                case 9:
                    poorJoe.rightfoot = blackpen;
                    break;
                case 10:
                    poorJoe.reset();
                    poorJoe.hanged = blackpen;
                    break;
                case 11:
                    poorJoe.reset();
                    poorJoe.happy = blackpen;
                    break;
                default:
                    break;
            }

          //  HangDraw poorJoe = new HangDraw();
            
           // gallows
           g.DrawLine(poorJoe.basegallows, 340, 260, 410, 262);
           g.DrawLine(poorJoe.post, 375, 260, 373, 80);
           g.DrawLine(poorJoe.pole, 372, 80, 440, 81);
           g.DrawLine(poorJoe.pole, 383, 80, 373, 90);
           g.DrawLine(poorJoe.rope, 440, 81, 440, 100);
           // head
           g.DrawEllipse(poorJoe.head, 425.0f, 97.0f, 25.0f, 30.0f);
           g.DrawRectangle(poorJoe.head, 433.0f, 106.0f, 2, 1);
           g.DrawRectangle(poorJoe.head, 442.0f, 106.0f, 2, 1);
           g.DrawLine(poorJoe.head, 432, 120, 445, 120);
           // body
           g.DrawLine(poorJoe.torso, 436, 125, 436, 182);
           g.DrawLine(poorJoe.rightarm, 436, 126, 420, 162);
           g.DrawLine(poorJoe.leftarm, 436, 126, 450, 162);
           // right foot
           g.DrawLine(poorJoe.rightfoot, 436, 181, 420, 212);
           g.DrawLine(poorJoe.rightfoot, 420, 212, 410 , 209);
                       
            // Totally hanged
            g.DrawLine(poorJoe.hanged, 340, 260, 410, 262);
            g.DrawLine(poorJoe.hanged, 375, 260, 373, 80);
            g.DrawLine(poorJoe.hanged, 372, 80, 440, 81);
            g.DrawLine(poorJoe.hanged, 383, 80, 373, 90);
            g.DrawLine(poorJoe.hanged, 440, 81, 440, 120);
            // head
            g.DrawEllipse(poorJoe.hanged, 438.0f, 110.0f, 25.0f, 30.0f);
            g.DrawRectangle(poorJoe.hanged, 448.0f, 122.0f, 4, 1);
            g.DrawRectangle(poorJoe.hanged, 456.0f, 122.0f, 4, 1);
            g.DrawArc(poorJoe.hanged, 448.0f, 135.0f, 10.0f, 5.0f, 180, 180);
            // body
            g.DrawLine(poorJoe.hanged, 440, 130, 440, 200);
            g.DrawLine(poorJoe.hanged, 440, 130, 444, 170);
            g.DrawLine(poorJoe.hanged, 440, 130, 450, 170);
            // feet
            g.DrawLine(poorJoe.hanged, 440, 200, 440, 222);
            g.DrawLine(poorJoe.hanged, 440, 200, 443, 222);
            

            // Happy guy
            // head
            g.DrawEllipse(poorJoe.happy, 400.0f, 130.0f, 25.0f, 30.0f);
            g.DrawRectangle(poorJoe.happy, 410.0f, 138.0f, 1, 1);
            g.DrawRectangle(poorJoe.happy, 420.0f, 138.0f, 1, 1);
            g.DrawArc(poorJoe.happy, 406.0f, 144.0f, 15.0f, 5.0f, 0, 180);
            // body
            g.DrawLine(poorJoe.happy, 410, 160, 410, 210);
            g.DrawLine(poorJoe.happy, 402, 153, 390, 120);
            g.DrawLine(poorJoe.happy, 419, 160, 450, 120);
            // feet
            g.DrawLine(poorJoe.happy, 410, 210, 400, 245);
            g.DrawLine(poorJoe.happy, 410, 209, 430, 242);
           
        }

        public struct HangDraw
        {
            public Pen basegallows, post, pole, rope, head, torso, rightarm, leftarm, rightfoot, hanged, happy;
            

            public HangDraw()
            {
                Pen invisiblepen = new Pen(Color.FromArgb(0, 0, 0, 0), 3.0f);
                basegallows = post = pole = rope = head = torso = rightarm = leftarm = rightfoot = hanged = happy = invisiblepen;
            }
            
            public void reset()
            {
                Pen invisiblepen = new Pen(Color.FromArgb(0, 0, 0, 0), 3.0f);
                basegallows = post = pole = rope = head = torso = rightarm = leftarm = rightfoot = hanged = happy = invisiblepen;
            }
           

        }

      private void  FinalDialog()
        {
            
            DialogResult dialogResult = MessageBox.Show("Do you want to play again?", "Question", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                this.Close();
                Application.Restart();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else

                this.Close();
                Application.Exit();
            }
        }

        private void PlaySounds(String wave)
        {
            try
            {
                 Player.SoundLocation = ".\\sounds\\" + wave + ".wav";
               // label11.Text = wave.ToString();

                Player.Play();

            }
            catch (global::System.Exception)
            {

                MessageBox.Show("Error sound file.");
            }
        }

    }

}