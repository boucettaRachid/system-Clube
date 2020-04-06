using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.formapp;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.acceuil
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        Access a = new Access();
        info i = new info();
        private void button1_Click(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.CommandText = "select * from Admin where UserName='" + textBox1.Text + "' and pass='" + textBox2.Text + "'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            if (a.dr.Read())
            {
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox1.Clear();
                textBox2.Clear();

                i.TYPEAccess = a.dr[3].ToString();

                a.dr.Close();

                AcceuilForm p = new AcceuilForm();
                p.Show();
                Hide();
            }
            else
            {
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
            a.Deconnection();
        }

        private void login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, 0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Maroon;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Maroon;
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
