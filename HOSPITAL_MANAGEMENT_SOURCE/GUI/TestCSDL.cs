using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class TestCSDL : Form
    {
        public TestCSDL()
        {
            InitializeComponent();
        }
        string strConnection = "Server=localhost;Port=5432;Database=Hospital_Management;User Id=postgres;";
        NpgsqlConnection vCon;
        NpgsqlCommand vCmd;
        private void connection()
        {
            vCon = new NpgsqlConnection();
            vCon.ConnectionString = strConnection;
            if (vCon.State == ConnectionState.Closed)
            {
                vCon.Open();
            }
        }
        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            connection();
            vCmd = new NpgsqlCommand();
            vCmd.Connection = vCon;
            vCmd.CommandText = sql;

            NpgsqlDataReader dr = vCmd.ExecuteReader();
            dt.Load(dr);
            return dt;
        }

        private void TestCSDL_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtgetdata = new DataTable();
            dtgetdata = getData("SELECT * FROM \"ASSIGNMENT\";");
            dgData.DataSource = dtgetdata;
        }
    }
}
