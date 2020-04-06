using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace System_Abdalli_multisport.formapp
{
    public partial class addPlayers : UserControl
    {
        public addPlayers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddMonths(1);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddMonths(6);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddYears(1);
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "150";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "700";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "1200";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "15";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        string img = "";

        private void button2_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                img = dialog.FileName;
                pictureBox1.ImageLocation = img;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true) && (radioButton3.Checked == true || radioButton4.Checked == true || radioButton5.Checked == true))
            {
                Access a = new Access();
                textBox1.BackColor = Color.White;
                string se = "";
                string Type;
                int INS;

                //for sex player
                if (radioButton1.Checked)
                {
                    se = "Woman";
                }
                else if (radioButton2.Checked)
                {
                    se = "Man";
                }
                else
                {
                    MessageBox.Show("! Plaes Check sex of the Player");

                }

                //for type sport
                if (radioButton3.Checked)
                {
                    Type = "GYM";
                }
                else if (radioButton4.Checked)
                {
                    Type = "Aerobic";
                }
                else
                {
                    Type = comboBox1.Text;
                }

                //for insurance
                if (checkBox1.Checked == true)
                {
                    INS = 1;
                }
                else
                {
                    INS = 0;
                }



                try
                {
                    byte[] imge = null;
                    FileStream FS = new FileStream(img, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(FS);
                    imge = br.ReadBytes((int)FS.Length);
                    /////////
                    if (imge != null)
                    {
                        a.connection();
                        a.cmd.Connection = a.con;
                        a.cmd.CommandText = "insert into AllPlayer values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + se + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + Type + "','" + INS + "','" + textBox5.Text + "',@img,'"+textBox4.Text+"')";
                        a.cmd.Parameters.Add(new SqlParameter("@img", imge));
                        a.cmd.ExecuteNonQuery();
                        a.Deconnection();
                        //////////
                        email m = new email();
                        m.mailAdmin("add player in system");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                        checkBox1.Checked = false;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        radioButton7.Checked = false;
                        radioButton8.Checked = false;
                        radioButton9.Checked = false;
                        radioButton10.Checked = false;
                        radioButton11.Checked = false;
                        radioButton12.Checked = false;
                        radioButton13.Checked = false;
                       
                        button2.FlatAppearance.BorderSize = 0;
                        //////
                        pictureBox1.Image = Properties.Resources.icon_user_default;
                        MessageBox.Show("Successful");
                    }
                    else
                    {
                        MessageBox.Show("Please check Photo");
                        button2.FlatAppearance.BorderSize = 1;
                        button2.FlatAppearance.BorderColor = Color.Red;
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show(r.Message);
                }
                //////////
            }
            else
            {
                MessageBox.Show("You Need a Enter all information for this player");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.BackColor = Color.White;
            }
        }

        private void addPlayers_Load(object sender, EventArgs e)
        {
            Access a = new Access();

            a.connection();
            a.cmd.Connection = a.con;
            a.cmd.CommandText = "select * from sports where not NameSport='GYM' and not NameSport='Aerobic'";
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                comboBox1.Items.Add(a.dr[1].ToString());
            }
            a.dr.Close();
            a.Deconnection();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Access a = new Access();
            if (textBox1.Text != "")
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "select * from AllPlayer where Name like '%" + textBox1.Text + "%'";
                if (a.cmd.ExecuteScalar() != null)
                {
                    MessageBox.Show("This player exists");
                    textBox1.BackColor = Color.Red;
                }
                a.Deconnection();
            }
            else
            {
                MessageBox.Show("Please First Enter Full Name Player");
                textBox1.BackColor = Color.Red;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please First Enter Phone Player");
                textBox2.BackColor = Color.Red;
            }
        }
    }
}
