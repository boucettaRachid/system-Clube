using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace System_Abdalli_multisport
{
    class TheQuerys
    {
        Access a = new Access();


        //public void AddPlayer(string name,int phone,string mail,string sex,DateTime dS,DateTime DF,string type,int Icre,double PRX,string image)
        //{
        //    try
        //    {
        //        a.connection();
        //        a.cmd.CommandText = "insert into AllPlayer values('" + name + "','" + phone + "','" + mail + "','" + sex + "','" + dS + "','" + DF + "','" + type + "','" + Icre + "','" + PRX + "','" + image + "')";
        //        a.cmd.Connection = a.con;
        //        a.cmd.ExecuteNonQuery();
        //        a.Deconnection();
        //    }
        //    catch (Exception r)
        //    {
        //        MessageBox.Show(r.Message);
        //    }
        //}


        public void All_player(DataGridView DG,string where)
        {
            a.dt.Clear();

            a.connection();
            a.cmd.CommandText = "select * from AllPlayer " + where;
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            DG.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }

        public void allplayer(string wh, string val, DataGridView DG)
        {
            a.dt.Clear();

            a.connection();
            a.cmd.CommandText = "select * from AllPlayer where " + wh + "='" + val + "'";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            DG.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }

        public void allSport(ComboBox CB, string Q)
        {
            a.connection();
            a.cmd.CommandText = "select * from Sports "+Q;
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                CB.Items.Add(a.dr[1].ToString());
            }
            a.dr.Close();
            a.Deconnection();
        }

        public int PlayerActive()
        {
            a.connection();
            a.cmd.CommandText = "select count(*) from AllPlayer where dateFin>getdate()";
            a.cmd.Connection = a.con;
            return int.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();
        }

        public int PlayerDesactive()
        {
            a.connection();
            a.cmd.CommandText = "select count(*) from AllPlayer where dateFin<getdate()";
            a.cmd.Connection = a.con;
            return int.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();
        }

        public int SumPlayer()
        {
            a.connection();
            a.cmd.CommandText = "select count(*) from AllPlayer";
            a.cmd.Connection = a.con;
            return int.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();
        }


        public Double SumMoney()
        {
            a.connection();
            a.cmd.CommandText = "select sum(monye) from AllPlayer where DATEPART(month,getdate()) < DATEPART(month,datefin)";
            a.cmd.Connection = a.con;
            return Double.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();

        }

        public int SumPlayer_GYM()
        {
            a.connection();
            a.cmd.CommandText = "select count(*) from AllPlayer where typeSport='GYM'";
            a.cmd.Connection = a.con;
            return int.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();
        }

        public int SumPlayer_Aerobic()
        {
            a.connection();
            a.cmd.CommandText = "select count(*) from AllPlayer where typeSport='Aerobic'";
            a.cmd.Connection = a.con;
            return int.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();
        }

        public int SumPlayer_Multi()
        {
            a.connection();
            a.cmd.CommandText = "select count(*) from AllPlayer where not typeSport='GYM' and not typeSport='Aerobic'";
            a.cmd.Connection = a.con;
            return int.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();
        }




        public Double SumMoney_GYM()
        {
            a.connection();
            a.cmd.CommandText = "select sum(monye) from AllPlayer where typeSport='GYM' and DATEPART(month,getdate()) < DATEPART(month,datefin)";
            a.cmd.Connection = a.con;
            return Double.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();

        }

        public Double SumMoney_Aerobic()
        {
            a.connection();
            a.cmd.CommandText = "select sum(monye) from AllPlayer where typeSport='Aerobic' and DATEPART(month,getdate()) < DATEPART(month,datefin)";
            a.cmd.Connection = a.con;
            return Double.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();

        }

        public Double SumMoney_MuSport()
        {
            a.connection();
            a.cmd.CommandText = "select sum(monye) from AllPlayer where not typeSport='GYM' and not typeSport='Aerobic' and DATEPART(month,getdate()) < DATEPART(month,datefin)";
            a.cmd.Connection = a.con;
            return Double.Parse(a.cmd.ExecuteScalar().ToString());
            a.Deconnection();

        }

        public void AllAdmin(DataGridView DG)
        {
            a.dt.Clear();

            a.connection();
            a.cmd.CommandText = "select * from admin ";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            a.dt.Load(a.dr);
            DG.DataSource = a.dt;
            a.dr.Close();
            a.Deconnection();
        }
        
    }
}
