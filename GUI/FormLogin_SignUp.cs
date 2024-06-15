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
        // Nút này đổi thành thoát chương trình
        private void bunifuButtonRememberPassword_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.PlaceholderText = "Nhập Số điện thoại";
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.PlaceholderText = "Nhập Email";
        }
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox4_Click(object sender, EventArgs e)
        {
            bunifuPictureBox5.BringToFront();
            bunifuTextBox2.PasswordChar = '\0';
        }
        private void bunifuPictureBox5_Click(object sender, EventArgs e)
        {
            bunifuPictureBox4.BringToFront();
            bunifuTextBox2.PasswordChar = '*';
        }
        private void bunifuButtonLogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("bunifuButtonLogin_Clicked");
            Login();
        }
        private void Login()
        {
            int staffID;
            Staff loginStaff;
            if (string.IsNullOrEmpty(bunifuTextBox1.Text))
            {
                bunifuSnackbar1.Show(this, "Vui lòng nhập Số điện thoại hoặc Email!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(bunifuTextBox2.Text))
            {
                bunifuSnackbar1.Show(this, "Vui lòng nhập mật khẩu!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }

            var phoneNumber_Email = bunifuTextBox1.Text;
            var password = bunifuTextBox2.Text;
            var statement = "";

            if (bunifuTextBox1.TextPlaceholder == "Nhập Số điện thoại")
            {
                statement = "select * from \"STAFF\" where sdt = '" + phoneNumber_Email + "'";
            }
            else
            {
                statement = "select * from \"STAFF\" where email = '" + phoneNumber_Email + "'";
            }
            var user = PostgreHelper.QueryFirst<StaffDTO>(statement);
            if (user == null)
            {
                if (bunifuTextBox1.PlaceholderText == "Nhập Số điện thoại")
                {
                    bunifuSnackbar1.Show(this, "Số điện thoại không hợp lệ!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Email không hợp lệ!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                }
                return;
            }

            password = HOSPITAL_MANAGEMENT_SOURCE.DAL.Bcrypt.CreateMD5(password);
            if (user.Password != password)
            {
                bunifuSnackbar1.Show(this, "Sai mật khẩu!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, "Sai mật khẩu", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }

            loginStaff = DAL.Staff.GetStaff(user.StaffID);
            bunifuSnackbar1.Show(this, "Đăng nhập thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);

            FormMainUser form = new FormMainUser(loginStaff);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void bunifuTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        // Nút này để reset password
        private void ResetPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormResetPassword resetPassword = new FormResetPassword();
            resetPassword.ShowDialog();
            this.Show();
        }
    }
}
