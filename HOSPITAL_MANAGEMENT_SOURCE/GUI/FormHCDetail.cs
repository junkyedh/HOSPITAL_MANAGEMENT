using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormHCDetail : Form
    {
        public HospitalizationCertificate HCDetail { get; set; }
        public String UserAction { get; set; }
        public FormHCDetail()
        {
            InitializeComponent();
            SetHCDetail();
        }
        private void SetHCDetail()
        {
            bunifuDropdownState.Enabled = false;
            bunifuDropdownState.SelectedIndex = 0;
            //Need a function to get current user
            bunifuTextBoxStaffID.Text = 10000000.ToString();

            bunifuDatePickerHospitalizate.Enabled = false;
            bunifuDatePickerHospitalizate.Text = DateTime.Now.ToShortDateString();

            SetAutoComplete();
        }
        private void SetAutoComplete()
        {
            /*DataTable dtPatientID = Patient.GetListPatientID();
            for (int i = 0; i < dtPatientID.Rows.Count; i++)
            {
                bunifuTextBoxHICD.AutoCompleteCustomSource.Add(dtPatientID.Rows[i][0].ToString());
            }*/
        }
        public FormHCDetail(int staffID, int patientID)
        {
            InitializeComponent();
            SetHCDetail(staffID, patientID);
        }
        private void SetHCDetail(int staffID, int patientID)
        {
            bunifuTextBoxPatientID.Text = patientID.ToString();
            bunifuTextBoxStaffID.Text = staffID.ToString();
            bunifuDropdownState.Enabled = false;
            bunifuDropdownState.SelectedIndex = 0;

            bunifuDatePickerHospitalizate.Enabled = false;
            bunifuDatePickerHospitalizate.Value = DateTime.Today;
        }
        public FormHCDetail(HospitalizationCertificate hcDetail, String userAction)
        {
            InitializeComponent();
            this.HCDetail = hcDetail;
            this.UserAction = userAction;
            SetHCDetail(hcDetail);
        }
        private void SetHCDetail(HospitalizationCertificate hcDetail)
        {
            bunifuTextBoxHICD.Text = hcDetail.HCID.ToString();
            bunifuTextBoxStaffID.Text = hcDetail.StaffID.ToString();
            bunifuTextBoxPatientID.Text = hcDetail.PatientID.ToString();
            bunifuTextBoxReason.Text = hcDetail.Reason;
            bunifuDatePickerHospitalizate.Value = hcDetail.Date;
            bunifuDropdownState.SelectedIndex = hcDetail.State;
            bunifuDropdownState.Enabled = false;

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBoxReason.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu lý do nhập viện", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            try
            {
                if (UserAction == "edit")
                {
                    HospitalizationCertificate newHC = new HospitalizationCertificate();
                    newHC.HCID = int.Parse(bunifuTextBoxHICD.Text);
                    newHC.PatientID = int.Parse(bunifuTextBoxPatientID.Text);
                    newHC.StaffID = int.Parse(bunifuTextBoxStaffID.Text);
                    newHC.Reason = bunifuTextBoxReason.Text;
                    newHC.State = (int)bunifuDropdownState.SelectedIndex;
                    newHC.Date = bunifuDatePickerHospitalizate.Value;

                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhật thông tin giấy nhập viện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (HospitalizationCertificate.UpdateHC(newHC) > 0)
                            bunifuSnackbar1.Show(this, "Cập nhật thông tin giấy nhập viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
                else
                {
                    if (HospitalizationCertificate.IsPatientHadHC(int.Parse(bunifuTextBoxPatientID.Text)))
                    {
                        bunifuSnackbar1.Show(this, "Bệnh nhân đã có giấy nhập viện", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                    else
                    {
                        HospitalizationCertificate newHC = new HospitalizationCertificate();
                        newHC.HCID = 0;
                        newHC.PatientID = int.Parse(bunifuTextBoxPatientID.Text);
                        newHC.StaffID = int.Parse(bunifuTextBoxStaffID.Text);
                        newHC.Reason = bunifuTextBoxReason.Text;
                        newHC.State = 0;
                        newHC.Date = bunifuDatePickerHospitalizate.Value;
                        if (HospitalizationCertificate.InsertHC(newHC) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Thêm giấy nhập viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
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

        private void bunifuTextBoxReason_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuTextBoxStaffID_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBoxHICD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
