using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HangMan {
 public partial class GameHangMan : Form
    {
        private Bitmap[] hangImages = {HangMan.Properties.Resources.empty,HangMan.Properties.Resources.face,HangMan.Properties.Resources.body,
       HangMan.Properties.Resources.onehand, HangMan.Properties.Resources.twohands, HangMan.Properties.Resources.oneleg, HangMan.Properties.Resources.full};

        private int wrongGuesses = 0;
        private string current = "";
        private string copyCurrent = "";
        private String[] words;
        private System.Windows.Forms.Timer timer1;
        private int counter = 60;
        public GameHangMan()
        {
            InitializeComponent();
        }

        private void loadwords()
        {
            char[] delimiterChars = {','};
            string[] readText = File.ReadAllLines("hints.csv");
             words = new string[readText.Length];
            int index = 0;
            foreach (string s in readText)
            {
                string[] line = s.Split(delimiterChars);
                words[index++] = line[1];
            }
        }

        private void setupWordChoice()
        {
            wrongGuesses = 0;
            hangImage.Image = hangImages[wrongGuesses];
            int baIndex = (new Random()).Next(words.Length);
            current = words[baIndex];
            

            copyCurrent = "";
            for (int index = 0; index < current.Length; index++ )
            {
                copyCurrent += "_";
            }
            displayCopy();

        }
        private void displayCopy()
        {
            showword.Text = "";
            for (int index = 0; index < copyCurrent.Length; index++)
            {
                showword.Text += copyCurrent.Substring(index, 1);
                showword.Text += " ";
            }
        }

        private void updateCopy(char ba)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Frame_Load(object sender, EventArgs e)
        {
            loadwords();
            setupWordChoice();
        }

        private void baClick(object sender, EventArgs e) 
        {
            Button choice = sender as Button;
            choice.Enabled = false;
            if (current.Contains(choice.Text))
                {

                char[] temp = copyCurrent.ToCharArray();
                char[] find = current.ToCharArray();
                char baChar = choice.Text.ElementAt(0);
                for (int index = 0; index < find.Length ; index++)
                {
                    if (find[index] == baChar)
                    {
                        temp[index] = baChar;
                    }
                }

                copyCurrent = new string(temp);
                displayCopy();
            }
            else
            {
                wrongGuesses++;
            }
                if (wrongGuesses < 7)
            {
                hangImage.Image = hangImages[wrongGuesses];
            }
            else
            {
                result.Text = "You Lose!!!";
            }
                if (copyCurrent.Equals(current))
            {
                result.Text = "You Win!!!";
            }

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            lblCountDown.Text = counter.ToString();


        }

        private void CClick(object sender, EventArgs e)
        {
            setupWordChoice();
            result.Text = "";

            foreach (Button ba in Controls.OfType<Button>())
            {
                ba.Text = "A";
                bb.Text = "B";
                bc.Text = "C";
                bd.Text = "D";
                be.Text = "E";
                bf.Text = "F";
                bg.Text = "G";
                bh.Text = "H";
                bi.Text = "I";
                bj.Text = "J";
                bk.Text = "K";
                bl.Text = "L";
                bm.Text = "M";
                bn.Text = "N";
                bo.Text = "O";
                bp.Text = "P";
                bq.Text = "Q";
                br.Text = "R";
                bs.Text = "S";
                bt.Text = "T";
                bu.Text = "U";
                bv.Text = "V";
                bw.Text = "W";
                bx.Text = "X";
                by.Text = "Y";
                bz.Text = "Z";
                C.Text = "Clear";
                ba.Enabled = true;
            }
        }

        private void showword_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer1.Stop();
            lblCountDown.Text = counter.ToString();
        }
    }
}
