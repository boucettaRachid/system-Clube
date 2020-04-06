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
    public partial class paying_off : Form
    {
        public paying_off()
        {
            InitializeComponent();
        }
        Access a = new Access();
        info i = new info();

        private void button3_Click(object sender, EventArgs e)
        {
            paying_off.ActiveForm.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int INS;

            if (checkBox1.Checked == true)
            {
                INS = 1;
            }
            else
            {
                INS = 0;
            }

            a.connection();
            a.cmd.CommandText = "update AllPlayer set dateStart='" + dateTimePicker1.Value + "',dateFin='" + dateTimePicker2.Value + "',Insurance='" + INS + "', monye='" + textBox5.Text + "' where ID=" + i.ID;
            a.cmd.Connection = a.con;
            a.cmd.ExecuteNonQuery();
            a.Deconnection();

            email m = new email();
            m.mailAdmin("paying some player in system");
           
        }

        private void paying_off_Load(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where ID='" + i.ID.ToString() + "'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                label1.Text = a.dr[1].ToString();

                dateTimePicker1.Value = Convert.ToDateTime(a.dr[5]);
                dateTimePicker1.Value = Convert.ToDateTime(a.dr[6]);

                if (Convert.ToBoolean(a.dr[8].ToString()) == false)
                {
                    checkBox1.Checked = false;
                }
                else if (Convert.ToBoolean(a.dr[8].ToString()) == true)
                {
                    checkBox1.Checked = true;
                }

                Byte[] data = new Byte[0];
                data = (Byte[])(a.dr[10]);
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
            a.dr.Close();
            a.Deconnection();


        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            textBox5.Text = "15";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "150";
            dateTimePicker2.Value = DateTime.Now.AddMonths(1);
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddMonths(6);
            textBox5.Text = "700";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddYears(1);
            textBox5.Text = "1200";
        }
    }
}
