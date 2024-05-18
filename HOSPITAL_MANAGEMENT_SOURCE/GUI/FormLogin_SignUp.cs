using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
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
    public partial class FormLogin_SignUp : Form
    {
        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 20, 10, 300, 100);
        }
        public FormLogin_SignUp()
        {
            this.Paint += MyForm_Paint;
            InitializeComponent();
            var data = PostgreHelper.GetAll<Patient>();
            Console.WriteLine(data);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButtonRememberPassword_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.PlaceholderText = "Nhập Email";
            string username = "Bá Nam";
            var statement = "select * from \"PATIENT\" where lastname ='" + username + "'";
            var users = PostgreHelper.QueryFirst<PatientDTO>(statement);
            Console.WriteLine(users.FirstName);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.PlaceholderText = "Nhập Số điện thoại";
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
