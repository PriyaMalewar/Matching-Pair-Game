using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Pair_Game
{
    public partial class Form1 : Form
    {
        Label firstclick = null;
        Label seconclick = null;

        List<string> icons = new List<string>()
            { "a","a","b","b","c","c","d","d","e","e","f","f","g","g","h","h" };

        public Form1()
        {
            InitializeComponent();
            AssignIconToSquare();
        }
        private void AssignIconToSquare()
        {
            

            


            foreach (var control in tableLayoutPanel1.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    Random random = new Random();
                    var randomNumber = random.Next(icons.Count);

                    label.Text = icons[randomNumber];
                    label.ForeColor = label.BackColor;
                    icons.RemoveAt(randomNumber);

                }

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelClick(object sender, EventArgs e)
        {

            if (timer1.Enabled==true)
                return;

            

            Label clicklabel = sender as Label;

          

            if (firstclick==null)  //user not first clicked as its empty 
            {
                firstclick = clicklabel;   //any first click stored as firstclick
                firstclick.ForeColor = Color.Black;  //reveals the firstclick 
                return;

            }

            seconclick = clicklabel;
            seconclick.ForeColor = Color.Black;

            Checkwinner();   //winner checking method


            if (firstclick.Text==seconclick.Text)
            {
                firstclick = null;
                seconclick = null;

                return;

            }


            timer1.Start();


            //when user clicks any next click then as firstclick not empty it not reveals that next click



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstclick.ForeColor = firstclick.BackColor;
            seconclick.ForeColor = seconclick.BackColor;

            firstclick = null;
            seconclick = null;

        }

        private void Checkwinner()
        {


            foreach (var control in tableLayoutPanel1.Controls)
            {
                Label label = control as Label;

                if (label.ForeColor==label.BackColor)
                {

                    return;

                }

               




            }

            MessageBox.Show("Congratulations! You won the match.");


            Close();



        }






    }
}
