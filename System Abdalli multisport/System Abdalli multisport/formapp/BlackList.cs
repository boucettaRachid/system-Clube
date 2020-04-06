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
    public partial class BlackList : UserControl
    {
        public BlackList()
        {
            InitializeComponent();
        }
        TheQuerys t = new TheQuerys();
        Access a = new Access();
        info i = new info();

        private void BlackList_Load(object sender, EventArgs e)
        {
            t.allSport(comboBox2,"");
            t.All_player(dataGridView1, " where dateFin<getdate()");


            dataGridView1.RowTemplate.Height = 80;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[10];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to delete this Player ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                a.connection();
                a.cmd.CommandText = "delete from AllPlayer where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                a.cmd.Connection = a.con;
                a.cmd.ExecuteNonQuery();
                a.Deconnection();
                a.dt.Clear();
                t.All_player(dataGridView1, "where dateFin<getdate()");

                email m = new email();
                m.mailAdmin("delete player in system");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string q;
            if (comboBox2.Text == "all")
            {
                q = "";
            }
            else
            {
                q = "and typeSport='" + comboBox2.Text + "'";
            }

            a.dt.Clear();
            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where Name like '%" + textBox1.Text + "%' and  dateFin<getdate() " + q; 
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            dataGridView1.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q;
            if (comboBox2.Text == "All")
            {
                q = "";
            }
            else
            {
                q = "and typeSport='" + comboBox2.Text+"'";
            }

            a.dt.Clear();
            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where Name like '%" + textBox1.Text + "%' and  dateFin<getdate() " + q;
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            dataGridView1.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            CartPlayer c = new CartPlayer();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            email l = new email();
            l.mailPlayer(dataGridView1.CurrentRow.Cells[3].Value.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            paying_off p = new paying_off();
            p.Show();
        }
    }
}
