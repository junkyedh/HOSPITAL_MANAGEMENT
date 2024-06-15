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
    public partial class FormHNDetail : Form
    {
        public HealthMonitoringNote HNDetail { get; set; }
        public String UserAction { get; set; }
        public FormHNDetail()
        {
            InitializeComponent();
        }
        //This constructor for Heath Note Management feature
        public FormHNDetail(int staffID)
        {
            InitializeComponent();
            textBoxStaffID.Text = staffID.ToString();
            SetAutoComplete();
        }
        //This contructor for Patient Management future
        public FormHNDetail(int staffID, int patientID)
        {
            InitializeComponent();
            textBoxStaffID.Text = staffID.ToString();
            textBoxPatientID.Text = patientID.ToString();
            dateCreate.Value = DateTime.Today;
            dateCreate.Enabled = false;
        }
        //This constructor for update in Heath Note Management
        public FormHNDetail(HealthMonitoringNote hnDetail, String userAction)
        {
            InitializeComponent();
            this.UserAction = userAction;

            textBoxHNID.Text = hnDetail.HNID.ToString();
            textBoxPatientID.Text = hnDetail.PatientID.ToString();
            textBoxStaffID.Text = hnDetail.StaffID.ToString();
            dateCreate.Value = hnDetail.Date;
            textBoxPatientState.Text = hnDetail.PatientState;
            textBoxBloodPressure.Text = hnDetail.BloodPressure;
            textBoxWeight.Text = hnDetail.Weight;
        }

        private void SetAutoComplete()
        {
            DataTable dtPatientID = Patient.GetListPatient();
            for (int i = 0; i < dtPatientID.Rows.Count; i++)
            {
                textBoxPatientID.AutoCompleteCustomSource.Add(dtPatientID.Rows[i][0].ToString());
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click_1(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxWeight.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin cân nặng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (string.IsNullOrEmpty(textBoxBloodPressure.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin huyết áp", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
            if (Patient.IsPatientExist(int.Parse(textBoxPatientID.Text)))
            {
                try
                {
                    if (UserAction == "edit")
                    {
                        HealthMonitoringNote newHN = new HealthMonitoringNote();
                        newHN.HNID = int.Parse(textBoxHNID.Text);
                        newHN.PatientID = int.Parse(textBoxPatientID.Text);
                        newHN.StaffID = int.Parse(textBoxStaffID.Text);
                        newHN.PatientState = textBoxPatientState.Text;
                        newHN.Weight = textBoxWeight.Text;
                        newHN.BloodPressure = textBoxBloodPressure.Text;
                        newHN.Date = dateCreate.Value;
                        DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin phiếu theo dõi sức khỏe", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (HealthMonitoringNote.UpdateHN(newHN) > 0)
                            {
                                bunifuSnackbar1.Show(this, "Cập nhật thông tin phiếu theo dõi sức khỏe thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }

                    }
                    else
                    {
                        HealthMonitoringNote newHN = new HealthMonitoringNote();
                        newHN.HNID = 0;
                        newHN.PatientID = int.Parse(textBoxPatientID.Text);
                        newHN.StaffID = int.Parse(textBoxStaffID.Text);
                        newHN.PatientState = textBoxPatientState.Text;
                        newHN.Weight = textBoxWeight.Text;
                        newHN.BloodPressure = textBoxBloodPressure.Text;
                        newHN.Date = dateCreate.Value;
                        if (HealthMonitoringNote.InsertHN(newHN) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Thêm phiếu theo dõi sức khỏe thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }
                }
                catch
                {
                    bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }

                this.Close();
            }
            else
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

        }

        private void textBoxBloodPressure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
    }
}
