using HOSPITAL_MANAGEMENT_SOURCE.DAL;
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
    public partial class FormMajorDetail : Form
    {
        public Major MajorDetail { get; set; }
        public string UserAction { get; set; }
        public FormMajorDetail()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public FormMajorDetail(Major majorDetail, String userAction)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.MajorDetail = majorDetail;
            this.UserAction = userAction;

            SetMajorDetail(majorDetail);
        }
        private void SetMajorDetail(Major majorDetail)
        {
            bunifuTextBoxMajorID.Text = majorDetail.MajorID.ToString();
            bunifuTextBoxMajorName.Text = majorDetail.MajorName;
        }

        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBoxMajorName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên phòng ban", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            Major newMajor = new Major();
            try
            {
                newMajor.MajorName = bunifuTextBoxMajorName.Text;
                if (UserAction == "edit")
                {
                    newMajor.MajorID = Convert.ToInt32(bunifuTextBoxMajorID.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin chuyên ngành", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (DAL.Major.UpdateMajor(newMajor) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Cập nhập thông tin chuyên ngành thành công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                }
                else
                {
                    newMajor.MajorID = 0;
                    if (DAL.Major.InsertMajor(newMajor) > 0)
                    {
                        bunifuSnackbar1.Show(this, "Thêm phòng khoa thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this, $"Lỗi dữ liệu: {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return;
            }
        }

        private void bunifuTextBoxMajorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                          (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                          e.KeyChar == 8 || // Backspace
                          e.KeyChar == 32 || // Space
                          e.KeyChar == 16 || // Shift
                          e.KeyChar == 46 || // Delete
                          (e.KeyChar >= 'À' && e.KeyChar <= 'ỹ') || // Vietnamese characters and accented vowels
                          (e.KeyChar >= 'à' && e.KeyChar <= 'ỹ'));
        }
    }
}
