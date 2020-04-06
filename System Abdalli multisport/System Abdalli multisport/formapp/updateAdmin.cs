using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class updateAdmin : Form
    {
        public updateAdmin()
        {
            InitializeComponent();
        }
        Access a = new Access();
        info i = new info();

        private void updateAdmin_Load(object sender, EventArgs e)
        {
            a.dt.Clear();

            a.connection();
            a.cmd.CommandText = "select * from admin where id='"+i.ID.ToString()+"'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                textBox7.Text = a.dr[1].ToString();
                textBox6.Text = a.dr[2].ToString();
                comboBox1.Text = a.dr[3].ToString();
            }
            a.dr.Close();
            a.Deconnection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            email m = new email();
            a.connection();
            a.cmd.CommandText = "update admin set username='" + textBox7.Text + "',pass='"+textBox6.Text+"',access='"+comboBox1.Text+"' where ID='" + i.ID.ToString() + "'";
            a.cmd.Connection = a.con;
            a.cmd.ExecuteNonQuery();
            a.Deconnection();
            MessageBox.Show("update seccussfuly");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox6.UseSystemPasswordChar == true)
            {
                textBox6.UseSystemPasswordChar = false;
            }
            else
            {
                textBox6.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateAdmin.ActiveForm.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
