using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport.Controle;

namespace System_Abdalli_multisport.formapp
{
    public partial class TypeListe : Form
    {
        public TypeListe()
        {
            InitializeComponent();
        }
         

        private void button3_Click(object sender, EventArgs e)
        {
            info i = new info();
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            updatePlayer u = new updatePlayer();
            u.Show();
        }

        private void TypeListe_Load(object sender, EventArgs e)
        {
            info info = new info();

            TheQuerys t = new TheQuerys();

            

            if (info.SPORTS.ToString() == "Multi Sports")
            {
                groupBox1.Visible = true;
                t.allplayer("not typeSport", "GYM' and not typeSport='Aerobic", dataGridView1);
            }
            else
            {
                t.allplayer("typeSport", info.SPORTS.ToString(), dataGridView1);
            }


            dataGridView1.RowTemplate.Height = 100;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[10];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;

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

        private void button2_Click(object sender, EventArgs e)
        {

            info info = new info();
            TheQuerys t = new TheQuerys();

            if (info.SPORTS.ToString() == "Multi Sports")
            {
                groupBox1.Visible = true;
                t.allplayer("not typeSport", "GYM' and not typeSport='Aerobic", dataGridView1);
            }
            else
            {
                t.allplayer("typeSport", info.SPORTS.ToString(), dataGridView1);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Access a = new Access();
            info info = new info();
            string Query;

            if (info.SPORTS.ToString() == "Multi Sports")
            {
                groupBox1.Visible = true;
                Query = "select * from AllPlayer where Name like '%" + textBox1.Text + "%' and typeSport='" + comboBox1.Text + "'";
            }
            else
            {
                Query = "select * from AllPlayer where Name like '%" + textBox1.Text + "%' and typeSport='" + info.SPORTS.ToString() + "'";
            }

            a.dt.Clear();
            a.connection();
            a.cmd.CommandText = Query;
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            dataGridView1.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TypeListe.ActiveForm.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        Bitmap bmp;
        info i = new info();
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

        private void button4_Click(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            CartPlayer c = new CartPlayer();
            c.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            i.ID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updatePlayer u = new updatePlayer();
            u.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            info info = new info();
            TheQuerys t = new TheQuerys();

            if (info.SPORTS.ToString() == "Multi Sports")
            {
                groupBox1.Visible = true;
                t.allplayer("not typeSport", "GYM' and not typeSport='Aerobic", dataGridView1);
            }
            else
            {
                t.allplayer("typeSport", info.SPORTS.ToString(), dataGridView1);
            }

            dataGridView1.RowTemplate.Height = 100;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[10];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Access a = new Access();
            email m = new email();

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
                m.mailAdmin("delete player in system");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            dataGridView1.RowTemplate.Height = 100;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[10];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
