using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class updatePlayer : Form
    {
        public updatePlayer()
        {
            InitializeComponent();
        }
        Access a = new Access();
        info i = new info();

        private void updatePlayer_Load(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where ID='"+i.ID.ToString()+"'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                textBox1.Text = a.dr[1].ToString();
                textBox2.Text = a.dr[2].ToString();
                textBox3.Text = a.dr[3].ToString();
                textBox4.Text = a.dr[11].ToString();

                if (a.dr[4].ToString() == "woman")
                {
                    radioButton1.Checked = true;
                }
                else if (a.dr[4].ToString() == "Man")
                {
                    radioButton2.Checked = true;
                }

                dateTimePicker1.Value = Convert.ToDateTime(a.dr[5]);
                dateTimePicker2.Value = Convert.ToDateTime(a.dr[6]);


                if (a.dr[7].ToString() == "GYM")
                {
                    radioButton3.Checked = true;
                }
                else if (a.dr[7].ToString() == "Aerobic")
                {
                    radioButton4.Checked = true;
                }
                else
                {
                    comboBox1.Visible = true;
                    comboBox1.Text = a.dr[7].ToString();
                }


                if (Convert.ToBoolean(a.dr[8].ToString()) == false)
                {
                    checkBox1.Checked = false;
                }
                else if (Convert.ToBoolean(a.dr[8].ToString()) == true)
                {
                    checkBox1.Checked = true;
                }


                textBox5.Text = a.dr[9].ToString();



                Byte[] data = new Byte[0];
                data = (Byte[])(a.dr[10]);
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
                    

            }
            a.dr.Close();
            a.Deconnection();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatePlayer.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string se = "";
            string Type;
            int INS;

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


            if (checkBox1.Checked == true)
            {
                INS = 1;
            }
            else
            {
                INS = 0;
            }


            a.connection();
            a.cmd.CommandText = "update AllPlayer set name='" + textBox1.Text + "',phone='" + textBox2.Text + "',Email='" + textBox3.Text + "',sex='" + se + "',dateStart='" + dateTimePicker1.Value + "',dateFin='" + dateTimePicker2.Value + "',typeSport='" + Type + "',Insurance='" + INS + "', monye='" + textBox5.Text + "', rest='"+textBox4.Text+"' where ID="+i.ID;
            a.cmd.Connection = a.con;
            a.cmd.ExecuteNonQuery();
            a.Deconnection();
            email m = new email();
            m.mailAdmin("update player in system");
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddMonths(1);
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "150";
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
