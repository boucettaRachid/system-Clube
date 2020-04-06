using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            TypeListe t = new TypeListe();
            info a = new info();
            a.SPORTS = "GYM";
            t.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TypeListe t = new TypeListe();
            info a = new info();
            a.SPORTS = "aerobic";
            t.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TypeListe t = new TypeListe();
            info a = new info();
            a.SPORTS = "Multi Sports";
            t.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            TheQuerys t = new TheQuerys();


            int PA = t.PlayerActive();
            int PD = t.PlayerDesactive();
            int TGYM = t.SumPlayer_GYM();
            int TAER = t.SumPlayer_Aerobic();
            int TMU = t.SumPlayer_Multi();

            label1.Text = Convert.ToString(t.SumPlayer());
            label2.Text = Convert.ToString(t.PlayerActive());
            label3.Text = Convert.ToString(t.PlayerDesactive());
            label8.Text = Convert.ToString(t.SumMoney());

            chart1.Series["Series1"].Points.AddXY("Player Active", PA);
            chart1.Series["Series1"].Points.AddXY("Player Desactive", PD);


            chart2.Series["Series1"].Points.AddXY("Gym", TGYM);
            chart2.Series["Series1"].Points.AddXY("Aearobic", TAER);
            chart2.Series["Series1"].Points.AddXY("Multi Sports", TMU);
            
        }

        private void Home_MouseHover(object sender, EventArgs e)
        {
           TheQuerys t = new TheQuerys();

           label1.Text = Convert.ToString(t.SumPlayer());
           label2.Text = Convert.ToString(t.PlayerActive());
           label3.Text = Convert.ToString(t.PlayerDesactive());
           label8.Text = Convert.ToString(t.SumMoney());

        }
    }
}
