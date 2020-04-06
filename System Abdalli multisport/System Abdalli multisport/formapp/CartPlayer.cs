using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class CartPlayer : Form
    {
        public CartPlayer()
        {
            InitializeComponent();
        }

        private void CartPlayer_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label2.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label4.BackColor = Color.FromArgb(0, 0, 0, 0);
            label5.BackColor = Color.FromArgb(0, 0, 0, 0);
            label6.BackColor = Color.FromArgb(0, 0, 0, 0);
            label7.BackColor = Color.FromArgb(0, 0, 0, 0);
            label8.BackColor = Color.FromArgb(0, 0, 0, 0);
            label9.BackColor = Color.FromArgb(0, 0, 0, 0);
            label10.BackColor = Color.FromArgb(0, 0, 0, 0);
            label11.BackColor = Color.FromArgb(0, 0, 0, 0);
            label12.BackColor = Color.FromArgb(0, 0, 0, 0);
            label13.BackColor = Color.FromArgb(0, 0, 0, 0);
            label14.BackColor = Color.FromArgb(0, 0, 0, 0);
            label15.BackColor = Color.FromArgb(0, 0, 0, 0);
            label16.BackColor = Color.FromArgb(0, 0, 0, 0);
            label17.BackColor = Color.FromArgb(0, 0, 0, 0);
            label18.BackColor = Color.FromArgb(0, 0, 0, 0);
            label19.BackColor = Color.FromArgb(0, 0, 0, 0);
            label20.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(0, 0, 0, 0);
            ///////////////////
            Access a = new Access();
            info i = new info();

            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where ID='" + i.ID.ToString() + "'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                label11.Text = a.dr[0].ToString();
                label12.Text = a.dr[1].ToString();
                label13.Text = a.dr[2].ToString();
                label14.Text = a.dr[3].ToString();
                label15.Text = a.dr[4].ToString();
                label16.Text = a.dr[5].ToString();
                label17.Text = a.dr[6].ToString();
                label18.Text = a.dr[7].ToString();
                label19.Text = a.dr[8].ToString();
                label20.Text = a.dr[9].ToString();
                ///////////////
                Byte[] data = new Byte[0];
                data = (Byte[])(a.dr[10]);
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
            a.dr.Close();
            a.Deconnection();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CartPlayer.ActiveForm.Close();
        }
    }
}
