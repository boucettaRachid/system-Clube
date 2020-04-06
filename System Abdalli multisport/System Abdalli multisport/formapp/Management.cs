using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace System_Abdalli_multisport.formapp
{
    public partial class Management : UserControl
    {
        public Management()
        {
            InitializeComponent();
        }
        TheQuerys t = new TheQuerys();
        private void Management_Load(object sender, EventArgs e)
        {
            label5.Text = (t.SumMoney_GYM()+"HD").ToString();
            label6.Text = (t.SumMoney_Aerobic()+"HD").ToString();
            label7.Text = (t.SumMoney_MuSport()+"HD").ToString();
            label8.Text = (t.SumMoney()+"HD").ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sumfree;
            sumfree = (Convert.ToInt32(textBox1.Text) +
                Convert.ToInt32(textBox2.Text) + 
                Convert.ToInt32(textBox3.Text) +
                Convert.ToInt32(textBox4.Text) +
                Convert.ToInt32(textBox5.Text) +
                Convert.ToInt32(textBox6.Text) +
                Convert.ToInt32(textBox7.Text) +
                Convert.ToInt32(textBox8.Text) +
                Convert.ToInt32(textBox9.Text)).ToString();

            label18.Text = (t.SumMoney()-Convert.ToInt32(sumfree)+"DH").ToString();

        }
        
    }
}
