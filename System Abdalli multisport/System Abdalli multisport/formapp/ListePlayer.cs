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
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class ListePlayer : UserControl
    {
        public ListePlayer()
        {
            InitializeComponent();
            
        }

        TheQuerys T = new TheQuerys();
        Access a = new Access();
        info i = new info();
        email m = new email();
       

        public void allplayer()
        {
            a.dt.Clear();
            a.connection();
            a.cmd.CommandText = "select * from AllPlayer ";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            dataGridView1.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox2.Text == "Multi Sports")
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }


            if (comboBox2.Text == "All")
            {
                allplayer();
            }
            else
            {
                T.allplayer("typeSport", comboBox2.Text.ToString(), dataGridView1);
            }


        }

        private void ListePlayer_Load(object sender, EventArgs e)
        {
            allplayer();

            T.allSport(comboBox1, "where not NameSport='GYM' and not NameSport='Aerobic'");

            T.allSport(comboBox2, "where  NameSport='GYM' or  NameSport='Aerobic'");

            dataGridView1.RowTemplate.Height = 80;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[10];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a.dt.Clear();

            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where Name like '%"+textBox1.Text+"%'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            dataGridView1.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
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
                allplayer();
                m.mailAdmin("delete player in system");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            T.allplayer("typeSport", comboBox1.Text.ToString(), dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updatePlayer u = new updatePlayer();
            u.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            CartPlayer c = new CartPlayer();
            c.Show();
        }

        Bitmap bmp;
        private void button5_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
