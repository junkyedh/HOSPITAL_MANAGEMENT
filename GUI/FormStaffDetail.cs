using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormStaffDetail : Form
    {
        private DAL.Staff StaffDetail { get; set; }
        private string UserAction { get; set; } = string.Empty;
        public FormStaffDetail()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public FormStaffDetail(string userAction, DAL.Staff staff)
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            textBoxPasswordCheck.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;

            // Set useraction and staff
            this.UserAction = userAction;
            this.StaffDetail = staff;

            // Set default gender
            dropDownGender.SelectedIndex = 0;
            dropDownState.SelectedIndex = 0;

            // Get department list and set it to dropDown
            dropDownDepartment.DataSource = DAL.Department.GetListDepartment();
            dropDownDepartment.ValueMember = "DEPARTMENTID";
            dropDownDepartment.DisplayMember = "DEPARTMENTNAME";

            // Get major list and set it to dropDown
            dropDownMajor.DataSource = DAL.Major.GetListMajor();
            dropDownMajor.ValueMember = "MAJORID";
            dropDownMajor.DisplayMember = "MAJORNAME";

            // Get role list and set it to dropDown
            dropDownRole.DataSource = DAL.Role.GetListRole();
            dropDownRole.ValueMember = "ROLEID";
            dropDownRole.DisplayMember = "ROLENAME";

            // If useraction is edit then set staffdetail to staffdetail form
            if ("edit".Equals(userAction))
            {
                textBoxPassword.ReadOnly = true;
                textBoxPasswordCheck.ReadOnly = true;
                setStaffDetail(staff);
                return;
            }

            if ("add".Equals(userAction))
            {
                textBoxPassword.ReadOnly = true;
                textBoxPasswordCheck.ReadOnly = true;
                return;
            }

            if ("personalEdit".Equals(userAction))
            {
                textBoxPassword.ReadOnly = false;
                textBoxPasswordCheck.ReadOnly = false;
                SetPersonalDetail(staff);
            }
        }
        private void SetPersonalDetail(Staff staff)
        {
            this.StaffDetail = staff;
            textBoxStaffID.Text = staff.StaffID.ToString();
            textBoxFirstName.Text = staff.FirstName;
            textBoxLastName.Text = staff.LastName;
            dateBirthday.Value = staff.BirthDay;

            if (staff.ICN != 0)
            {
                textBoxIdentityCard.Text = staff.ICN.ToString();
            }

            if (Staff.GENDER_FEMALE.Equals(staff.Gender))
            {
                dropDownGender.SelectedIndex = Staff.GENDER_FEMALE;
            }
            else
            {
                dropDownGender.SelectedIndex = Staff.GENDER_MALE;
            }

            textBoxEmail.Text = staff.Email;
            textBoxPhone.Text = staff.SDT;
            textBoxAddress.Text = staff.Address;

            if (staff.State == 0)
            {
                dropDownState.Text = "Đang làm việc";
            }
            else
            {
                dropDownState.Text = "Đã thôi việc";
            }

            dropDownDepartment.SelectedValue = (object)staff.DepartmentID;
            dropDownMajor.SelectedValue = (object)staff.MajorID;
            dropDownRole.SelectedValue = (object)staff.RoleID;

            dropDownDepartment.Enabled = false;
            dropDownMajor.Enabled = false;
            dropDownRole.Enabled = false;
            dropDownState.Enabled = false;
            textBoxFirstName.ReadOnly = true;
            textBoxLastName.ReadOnly = true;
            textBoxIdentityCard.ReadOnly = true;
            dropDownGender.Enabled = false;
            dateBirthday.Enabled = false;
            textBoxEmail.ReadOnly = false;
            textBoxPhone.ReadOnly = true;
        }
        public void setStaffDetail(Staff staff)
        {
            this.StaffDetail = staff;
            textBoxStaffID.Text = staff.StaffID.ToString();
            textBoxFirstName.Text = staff.FirstName;
            textBoxLastName.Text = staff.LastName;
            dateBirthday.Value = staff.BirthDay;

            if (staff.ICN != 0)
            {
                textBoxIdentityCard.Text = staff.ICN.ToString();
            }

            if (Staff.GENDER_MALE.Equals(staff.Gender))
            {
                dropDownGender.SelectedIndex = Staff.GENDER_MALE;
            }
            else
            {
                dropDownGender.SelectedIndex = Staff.GENDER_FEMALE;
            }

            textBoxEmail.Text = staff.Email;
            textBoxPhone.Text = staff.SDT;
            textBoxAddress.Text = staff.Address;

            if (staff.State == 0)
            {
                dropDownState.Text = "Đang làm việc";
            }
            else
            {
                dropDownState.Text = "Đã thôi việc";
            }

            dropDownDepartment.SelectedValue = (object)staff.DepartmentID;
            dropDownMajor.SelectedValue = (object)staff.MajorID;
            dropDownRole.SelectedValue = (object)staff.RoleID;

            textBoxPassword.ReadOnly = true;
            textBoxPasswordCheck.ReadOnly = true;
        }





        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {
            decimal tempDecimal;
            if (UserAction == "personalEdit")
            {
                if (textBoxPassword.Text != textBoxPasswordCheck.Text)
                {
                    bunifuSnackbar1.Show(this, "Mật khẩu xác nhận không khớp!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }

            // If fields is not validated then do nothing
            if (string.IsNullOrEmpty(textBoxFirstName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên >_<!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxLastName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu họ >_<!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxIdentityCard.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin CCCD >_<!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu email >_<!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPhone.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu số điện thoại >_<!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAddress.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu địa chỉ >_<!!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            // Set StaffDetail property with value in staffdetail form
            StaffDetail.DepartmentID = Convert.ToInt32(dropDownDepartment.SelectedValue.ToString());
            StaffDetail.MajorID = Convert.ToInt32(dropDownMajor.SelectedValue.ToString());
            StaffDetail.RoleID = Convert.ToInt32(dropDownRole.SelectedValue.ToString());

            //StaffDetail.Password = textBoxPassword.Text;
            StaffDetail.FirstName = textBoxFirstName.Text;
            StaffDetail.LastName = textBoxLastName.Text;
            StaffDetail.BirthDay = dateBirthday.Value;

            if (Decimal.TryParse(textBoxIdentityCard.Text, out tempDecimal))
            {
                StaffDetail.ICN = Convert.ToInt64(textBoxIdentityCard.Text);
            }
            if ("Nam".Equals(dropDownGender.SelectedItem.ToString()))
            {
                StaffDetail.Gender = Staff.GENDER_MALE;
            }
            else
            {
                StaffDetail.Gender = Staff.GENDER_FEMALE;
            }

            StaffDetail.Email = textBoxEmail.Text;
            StaffDetail.SDT = textBoxPhone.Text;
            StaffDetail.Address = textBoxAddress.Text;

            if (dropDownState.SelectedIndex == 0)
            {
                StaffDetail.State = 0;
            }
            else
            {
                StaffDetail.State = 1;
            }
            // Process user action
            try
            {
                // If useraction is add then insert to database else update
                if ("add".Equals(this.UserAction))
                {
                    string createPassword = StaffDetail.SDT + StaffDetail.BirthDay.Date.ToString();
                    StaffDetail.Password = DAL.Bcrypt.CreateMD5(createPassword);

                    string subject = "Mật khẩu tài khoản Hospital Management";
                    string body = "Mật khẩu của bạn nè (●ˇ∀ˇ●) (Bạn nên đổi mật khẩu mới để an toàn hơn nha): " + createPassword;

                    SendNewPassword(StaffDetail.Email, subject, body);

                    Staff.InsertStaff(StaffDetail);
                    bunifuSnackbar1.Show(this, "Thêm nhân viên mới thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    return;
                }
                if ("edit".Equals(this.UserAction))
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Staff.UpdateStaff(StaffDetail);
                        bunifuSnackbar1.Show(this, "Cập nhật thông tin thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    return;
                }
                if ("personalEdit".Equals(this.UserAction))
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin tài khoản cá nhân", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (textBoxPassword.Text != "")
                        {
                            StaffDetail.Password = DAL.Bcrypt.CreateMD5(textBoxPassword.Text);
                        }
                        Staff.UpdateStaff(StaffDetail);
                        bunifuSnackbar1.Show(this, "Cập nhật thông tin thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                    return;
                }
                return;
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this, ex.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                e.KeyChar == 8 || // Backspace
                e.KeyChar == 32 || // Space
                e.KeyChar == 16 || // Shift
                e.KeyChar == 46 || // Delete
                (e.KeyChar >= 'À' && e.KeyChar <= 'Ỹ') || // Vietnamese characters and accented vowels
                (e.KeyChar >= 'à' && e.KeyChar <= 'ỹ'));
        }

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
              (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
              e.KeyChar == 8 || // Backspace
              e.KeyChar == 32 || // Space
              e.KeyChar == 16 || // Shift
              e.KeyChar == 46 || // Delete
              (e.KeyChar >= 'À' && e.KeyChar <= 'Ỹ') || // Vietnamese characters and accented vowels
              (e.KeyChar >= 'à' && e.KeyChar <= 'ỹ'));
        }

        private void textBoxIdentityCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép chỉ là số hoặc các phím điều khiển (Backspace, Delete)
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                // Nếu chiều dài của chuỗi là 9, không cho phép nhập thêm
                if (textBoxIdentityCard.Text.Length >= 12 && e.KeyChar != 8 && e.KeyChar != 127)
                {
                    e.Handled = true;
                }
            }
            else
            {
                // Nếu ký tự không phải là số hoặc không phải là các phím điều khiển, không cho phép nhập
                e.Handled = true;
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
    }
}
