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
    public partial class FormService : Form
    {
        public Service ServiceDetail { get; set; }
        public string UserAction { get; set; }
        public FormService()
        {
            InitializeComponent();
        }
        public FormService(Service serviceDetail, String userAction)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;      
            this.ServiceDetail = serviceDetail;
            this.UserAction = userAction;
            if (this.UserAction == "edit")
                SetServiceDetail(serviceDetail);
        }
        private void SetServiceDetail(Service serviceDetail)
        {
            textBoxServiceID.Text = ServiceDetail.ServiceID.ToString();
            textBoxServiceName.Text = ServiceDetail.ServiceName;
            textBoxPrice.Text = Convert.ToInt64(ServiceDetail.Price).ToString();
        }
        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxServiceName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên dịch vụ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin giá dịch vụ", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            try
            {
                if (UserAction == "edit")
                {
                    ServiceDetail.ServiceName = textBoxServiceName.Text;
                    ServiceDetail.Price = decimal.Parse(textBoxPrice.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin dịch vụ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Service.UpdateService(ServiceDetail) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Cập nhập dịch vụ thành công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }

                }
                else
                {
                    Service newService = new Service(0, textBoxServiceName.Text, decimal.Parse(textBoxPrice.Text));
                    if (Service.InsertService(newService) > 0)
                    {
                        bunifuSnackbar1.Show(this, "Thêm dịch vụ thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this, $"Lỗi dữ liệu {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            this.Close();
        }

        private void textBoxServiceName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormService_Load(object sender, EventArgs e)
        {

        }
    }
}
