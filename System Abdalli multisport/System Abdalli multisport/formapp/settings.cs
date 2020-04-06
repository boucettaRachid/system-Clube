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
    public partial class settings : UserControl
    {
        public settings()
        {
            InitializeComponent();
        }

        Access a = new Access();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

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
                groupBox5.Enabled = true;

                while (a.dr.Read())
                {
                    textBox4.Text = a.dr[1].ToString();
                }
                a.dr.Close();
            }
            else
            {
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
            a.Deconnection();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.CommandText = "update email set Email_S='" + EmailSendr.Text + "',Email_A='" + EmailAdmin.Text + "',Passwordmail_A='" + password.Text + "',Port='" + Port.Text + "',Smtp='" + SMTP.Text + "',subjecte='" + Subject.Text + "',messag='" + Messsage.Text + "'";
            a.cmd.Connection = a.con;
            a.cmd.ExecuteNonQuery();
            a.Deconnection();
            MessageBox.Show("Update Successfuly");

        }

        TheQuerys t = new TheQuerys();

        private void settings_Load(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.CommandText = "select * from email";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                EmailSendr.Text = a.dr[0].ToString();
                EmailAdmin.Text = a.dr[1].ToString();
                password.Text = a.dr[2].ToString();
                Port.Text = a.dr[3].ToString();
                SMTP.Text = a.dr[4].ToString();
                Subject.Text = a.dr[5].ToString();
                Messsage.Text = a.dr[6].ToString();
            }
            a.dr.Close();
            a.Deconnection();

            t.AllAdmin(dataGridView1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox5.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == textBox5.Text)
                {
                    a.connection();
                    a.cmd.CommandText = "update Admin set UserName='"+textBox4.Text+"',pass='"+textBox3.Text+"' where UserName='"+textBox1.Text+"' end pass='"+textBox2.Text+"'";
                    a.cmd.Connection = a.con;
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();
                    textBox5.BackColor = Color.White;
                    MessageBox.Show("update successfuly");
                }
                else
                {
                    textBox5.BackColor = Color.Red;
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(z.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (password.UseSystemPasswordChar == true)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        info i = new info();
        private void button5_Click(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateAdmin u = new updateAdmin();
            u.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to Delete this admin ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "delete from admin where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'";
                a.cmd.ExecuteNonQuery();
                a.Deconnection();
                MessageBox.Show("delete successfuly");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.Connection = a.con;
            a.cmd.CommandText = "insert into Admin values ('"+textBox7.Text+"','"+textBox6.Text+"','"+comboBox1.Text+"')";
            a.cmd.ExecuteNonQuery();
            a.Deconnection();

            textBox7.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            MessageBox.Show("Add admin successfuly");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.Connection = a.con;
            a.cmd.CommandText = "insert into Sports values ('" + textBox8.Text + "')";
            a.cmd.ExecuteNonQuery();
            a.Deconnection();

            textBox8.Clear();
            MessageBox.Show("Add sport successfuly");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            t.AllAdmin(dataGridView1);
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
    }
}
