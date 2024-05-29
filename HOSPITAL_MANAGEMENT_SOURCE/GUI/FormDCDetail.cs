using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormDCDetail : Form
    {
        public DischargeCertificateDTO DCDetail { get; set; }
        public String UserAction { get; set; }
        public FormDCDetail()
        {
            InitializeComponent();
        }
        //This constructor for insert feature
        public FormDCDetail(int staffID, int patientID)
        {
            InitializeComponent();
            SetDCForInsert(staffID, patientID);
        }
        private void SetDCForInsert(int staffID, int patientID)
        {
            bunifuTextBoxPatientID.Text = patientID.ToString();
            bunifuTextBoxStaffID.Text = staffID.ToString();
            bunifuDatePickerDischarge.Value = DateTime.Today;
            bunifuDropdownState.SelectedIndex = 0;
            bunifuDatePickerDischarge.Enabled = false;
            bunifuDropdownState.Enabled = false;
        }
        //This constructor for update, confirm feature
        public FormDCDetail(DischargeCertificateDTO dcDetail, String userAction)
        {
            InitializeComponent();
            this.DCDetail = dcDetail;
            this.UserAction = userAction;
            SetDCForUpdate(dcDetail);
        }
        private void SetDCForUpdate(DischargeCertificateDTO dcDetail)
        {
            bunifuTextBoxDCID.Text = dcDetail.DCID.ToString();
            bunifuTextBoxPatientID.Text = dcDetail.PatientID.ToString();
            bunifuTextBoxStaffID.Text = dcDetail.StaffID.ToString();
            bunifuDatePickerDischarge.Value = dcDetail.Date;
            bunifuDropdownState.SelectedIndex = dcDetail.State;
            bunifuDropdownState.Enabled = false;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DischargeCertificateDTO newDC = new DischargeCertificateDTO();
                newDC.PatientID = Convert.ToInt32(bunifuTextBoxPatientID.Text);
                newDC.StaffID = Convert.ToInt32(bunifuTextBoxStaffID.Text);
                newDC.Date = bunifuDatePickerDischarge.Value;
                newDC.State = bunifuDropdownState.SelectedIndex;
                if (UserAction == "edit")
                {
                    newDC.DCID = Convert.ToInt32(bunifuTextBoxDCID.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin giấy xuất viện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (DischargeCertificate.UpdateDC(newDC) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Cập nhật thông tin giấy xuất viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }
                }
                else
                {
                    if (DischargeCertificate.IsPatientHadDC(Convert.ToInt32(bunifuTextBoxPatientID.Text)))
                    {
                        bunifuSnackbar1.Show(this, "Bệnh nhân đã có giấy xuất viện", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                    else
                    {
                        newDC.DCID = 0;
                        if (DischargeCertificate.InsertDC(newDC) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Thêm giấy xuất viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }
                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            this.Close();
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuTextBoxDCID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
