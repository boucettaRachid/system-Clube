using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Abdalli_multisport.formapp
{
    public partial class calculator : UserControl
    {
        public calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox2.Visible = false;
                groupBox1.Visible = true;
                button2.Visible = true;
                float s;
                float kcl;
                float pro;
                float car;
                float lip;
                float wth;
                s = float.Parse(textBox1.Text);
                kcl = s * 24;
                textBox2.Text = kcl.ToString();
                car = ((kcl * 50) / 100) / 4;
                textBox3.Text = car.ToString();
                pro = ((kcl * 35) / 100) / 4;
                textBox4.Text = pro.ToString();
                lip = ((kcl * 15) / 100) / 9;
                textBox5.Text = lip.ToString();
                wth = (s * 30) / 1000;
                textBox6.Text = wth.ToString();
            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            button2.Visible = false;
            textBox1.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
