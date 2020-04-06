using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.acceuil;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class AcceuilForm : Form
    {
        public AcceuilForm()
        {
            InitializeComponent();
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listePlayer1.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            home1.BringToFront();
        }

        private void listePlayer1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            addPlayers1.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to Exit this Sytem ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            management1.BringToFront();
        }

        private void home1_Load(object sender, EventArgs e)
        {

        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            settings1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calendar1.BringToFront();
        }

        private void calculator1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculator1.BringToFront();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AcceuilForm_Load(object sender, EventArgs e)
        {
            TheQuerys t = new TheQuerys();
            info i = new info();

            if (t.PlayerDesactive() != 0)
            {
                label2.Visible = true;
            }

            Timer timer = new Timer();
            timer.Interval = (1000); // 1 secs
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            
            if (i.TYPEAccess.ToString() != "admin")
            {
                button6.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            blackList1.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            blackList1.BringToFront();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AcceuilForm.ActiveForm.Close();

            login l = new login();
            l.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            help1.BringToFront();
        }
    }
}
