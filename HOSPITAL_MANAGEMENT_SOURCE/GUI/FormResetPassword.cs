using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormResetPassword : Form
    {
        public FormResetPassword()
        {
            InitializeComponent();
            bunifuButton1.Enabled = false;  
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButtonSignUp_Click(object sender, EventArgs e)
        {
        
        }

        private void bunifuButtonReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBox1.Text))
            {
                bunifuSnackbar1.Show(this, "Vui lòng nhập Email!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            
            // Khúc này dùng PostgreHelper để lấy user có Email đã nhập
            string EMAIL = bunifuTextBox1.Text; 
            var statement = 
                "select * " +
                "from \"STAFF\" " +
                "where email = '" + EMAIL + "'";
            StaffDTO staffDTO = PostgreHelper.QueryFirst<StaffDTO>(statement);
            if (staffDTO is null) 
            {
                bunifuSnackbar1.Show(this, "Email không hợp lệ. Vui lòng nhập lại Email!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }

            string newPassword = GenerateRandomPassword(8, 14);
            string hashedPassword = DAL.Bcrypt.CreateMD5(newPassword);
            string subject = "Mật khẩu mới (Hospital Management)";
            string body = "Mật khẩu mới (Bạn hãy lưu lại mật khẩu này ở đâu đó nha (●ˇ∀ˇ●): " + newPassword;

            DAL.Staff staffDB = new DAL.Staff();
            staffDB = DAL.Staff.GetStaff(staffDTO.StaffID);
            staffDB.Password = hashedPassword;
            DAL.Staff.UpdateStaff(staffDB);

            SendNewPassword(EMAIL, subject, body);
            bunifuSnackbar1.Show(this, "Mật khẩu mới gửi thành công. Xin hãy kiểm tra Email của bạn!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
        }
        private string GenerateRandomPassword(int minLength, int maxLength)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-=_+";

            using (var rng = new RNGCryptoServiceProvider())
            {
                int length = new Random().Next(minLength, maxLength + 1);

                char[] password = new char[length];
                byte[] randomData = new byte[length];

                rng.GetBytes(randomData);

                for (int i = 0; i < length; i++)
                {
                    password[i] = validChars[randomData[i] % validChars.Length];
                }

                return new string(password);
            }
        }

        public SmtpClient client = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("hoangduy06104@gmail.com", "zdzqvzxnxknlgkus");
        public void SendNewPassword(string sendTo, string subject, string body)
        {
            try
            {
                //setup SMTP Host Here
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = smtpCreds;
                client.EnableSsl = true;

                //converte string to MailAdress
                MailAddress to = new MailAddress(sendTo);
                MailAddress from = new MailAddress("22520393@gm.uit.edu.vn (Dương Hải Hân)", "Hospital Management");

                //set up message settings
                msg.Subject = subject;
                msg.Body = body;
                msg.From = from;
                msg.To.Add(to);

                // Enviar E-mail
                client.Send(msg);

            }
            catch (Exception error)
            {
                MessageBox.Show("Unexpected Error: " + error);
            }
        }
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin_SignUp LoginSignUp = new FormLogin_SignUp();      
            LoginSignUp.ShowDialog();
            this.Close();       
        }
    }
}
