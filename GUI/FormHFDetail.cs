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
    public partial class FormHFDetail : Form
    {
        public HealthFile HFDetail { get; set; }
        public String UserAction { get; set; }
        public FormHFDetail()
        {
            InitializeComponent();
            SetAutoComplete();
        }
        public FormHFDetail(int patientID)
        {
            InitializeComponent();
            SetHFDetail(patientID);
        }
        public FormHFDetail(HealthFileDTO hfDetail, String userAction)
        {
            InitializeComponent();
            this.UserAction = userAction;
            SetHFDetail(hfDetail);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //For add feature
        private void SetHFDetail(int patientID)
        {
            textBoxPatientID.Text = patientID.ToString();
            dateCreate.Enabled = false;
            dateCreate.Value = DateTime.Today;
        }
        //For edit feature
        private void SetHFDetail(HealthFileDTO hfDetail)
        {
            textBoxHFID.Text = hfDetail.HeathFileID.ToString();
            textBoxPatientID.Text = hfDetail.PatientID.ToString();
            dateCreate.Value = hfDetail.Date;
            textBoxPatientState.Text = hfDetail.PatientState;
            textBoxPrehistory.Text = hfDetail.PreHistory;
            textBoxDisease.Text = hfDetail.Disease;
            textBoxTreatment.Text = hfDetail.Treatment;
        }
        private void SetAutoComplete()
        {
            DataTable dtPatientID = Patient.GetListPatient();
            for (int i = 0; i < dtPatientID.Rows.Count; i++)
            {
                textBoxPatientID.AutoCompleteCustomSource.Add(dtPatientID.Rows[i][0].ToString());
            }
        }

        private void buttonOk_Click_1(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPatientState.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin tình trạng sức khoẻ bệnh nhân", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrehistory.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin tiền sử bệnh", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(textBoxDisease.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin bệnh mắc phải", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(textBoxTreatment.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin hướng điều trị", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (Patient.IsPatientExist(int.Parse(textBoxPatientID.Text)))
            {
                try
                {
                    if (UserAction == "edit")
                    {
                        HealthFile newHF = new HealthFile();
                        newHF.HeathFileID = int.Parse(textBoxHFID.Text);
                        newHF.PatientID = int.Parse(textBoxPatientID.Text);
                        newHF.PatientState = textBoxPatientState.Text;
                        newHF.PreHistory = textBoxPrehistory.Text;
                        newHF.Disease = textBoxDisease.Text;
                        newHF.Treatment = textBoxTreatment.Text;
                        newHF.Date = dateCreate.Value;
                        DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bệnh án", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (HealthFile.UpdateHeathFile(newHF.ToDTO()) > 0)
                            {
                                bunifuSnackbar1.Show(this, "Cập nhập thông tin bệnh án thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }

                        }

                    }
                    else
                    {
                        if (HealthFile.DidPatientHaveHF(int.Parse(textBoxPatientID.Text)))
                        {
                            bunifuSnackbar1.Show(this, "Bệnh nhân đã có bệnh án", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;

                        }
                        else
                        {
                            HealthFile newHF = new HealthFile();
                            newHF.HeathFileID = 0;
                            newHF.PatientID = int.Parse(textBoxPatientID.Text);
                            newHF.PatientState = textBoxPatientState.Text;
                            newHF.PreHistory = textBoxPrehistory.Text;
                            newHF.Disease = textBoxDisease.Text;
                            newHF.Treatment = textBoxTreatment.Text;
                            newHF.Date = dateCreate.Value;
                            if (HealthFile.InsertHeathFile(newHF.ToDTO()) > 0)
                            {
                                bunifuSnackbar1.Show(this, "Thêm bệnh án thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            else
            {
                bunifuSnackbar1.Show(this, "Bệnh nhân không tồn tại", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            this.Close();
        }
        private void textBoxPatientState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPrehistory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxDisease_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxTreatment_KeyPress(object sender, KeyPressEventArgs e)
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

