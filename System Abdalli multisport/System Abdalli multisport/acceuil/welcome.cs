using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Abdalli_multisport.acceuil
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void welcome_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 10;

            if (panel2.Width > panel1.Width)
            {
                login l = new login();
                l.Show();
                Hide();
                timer1.Stop();
            }
        }
    }
}
