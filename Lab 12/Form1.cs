using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TeamInit();
        }

        Dictionary<string, double> Teams = new Dictionary<string, double>();
        int day = 0;
        public int getValue(double lambda)
        {
            Random rnd = new Random();
            int m = 0;
            double a = rnd.NextDouble();
            double S = Math.Log(a);
            while (S > lambda)
            {
                m++;
                a = rnd.NextDouble();
                S += Math.Log(a);
            }
            return m;
        }
        public void TeamInit()
        {
            Teams.Add("Russia", -1.8);
            Teams.Add("Italy", -1.5);
            Teams.Add("Spain", -2.0);
            Teams.Add("France", -1.3);
            Teams.Add("Argentina", -2.0);
            Teams.Add("USA", -1.1);
            Teams.Add("Brazil", -2.1);
            Teams.Add("Germany", -2.0);
        }
        private void play(Label team1, Label team2, Label result1, Label result2, Label winner)
        {
            int a, b;
            a = getValue(Teams[team1.Text]);
            b = getValue(Teams[team2.Text]);
            result1.Text = a.ToString();
            result2.Text = b.ToString();
            if (a > b) winner.Text = team1.Text;
            if (a < b) winner.Text = team2.Text;
            if (a == b) play(team1, team2, result1, result2, winner);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (day)
            {
                case 0:
                    play(label2, label4, label1, label3, label18);
                    play(label6, label8, label5, label7, label20);
                    play(label10, label12, label9, label11, label22);
                    play(label14, label16, label13, label15, label24);
                    break;
                case 1:
                    play(label18, label20, label17, label19, label26);
                    play(label22, label24, label21, label23, label28);
                    break;
                case 2:
                    play(label26, label28, label25, label27, label29);
                    break;
                default:
                    Form1 NewForm = new Form1();
                    NewForm.ShowDialog();
                    this.Close();
                    break;
            }
            day++;
        }
    }
}
