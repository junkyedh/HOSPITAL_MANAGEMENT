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
    public partial class FormHICDetail : Form
    {
        public HIC HICDetail { get; set; }
        public String UserAction { get; set; }
        public FormHICDetail()
        {
            InitializeComponent();
        }
        //This constructor for edit HIC 
        public FormHICDetail(HIC hicDetail, String userAction)
        {
            InitializeComponent();
            this.HICDetail = hicDetail;
            this.UserAction = userAction;
            SetHICDetail(hicDetail);
        }
        private void SetHICDetail(HIC hicDetail)
        {
            bunifuTextBoxHICID.Text = hicDetail.HICID.ToString();
            bunifuTextBoxPatientID.Text = hicDetail.PatientID.ToString();
            bunifuDatePickerIssue.Value = hicDetail.ExpireDate;
            bunifuDatePickerExpire.Value = hicDetail.IssueDate;
        }
        //this constructor for add HIC
        public FormHICDetail(int patientID)
        {
            InitializeComponent();
            bunifuTextBoxPatientID.Text = patientID.ToString();
        }

        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {
            /* if (!superValidator1.Validate())
                 return;*/
            if (string.IsNullOrEmpty(bunifuTextBoxHICID.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu mã bảo hiểm y tế", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;

            }
            int hicID = Convert.ToInt32(bunifuTextBoxHICID.Text);
            int patientID = Convert.ToInt32(bunifuTextBoxPatientID.Text);
            try
            {
                if (bunifuDatePickerExpire.Value > bunifuDatePickerIssue.Value)
                {
                    if (bunifuDatePickerExpire.Value > DateTime.Today)
                    {
                        HIC newHIC = new HIC();
                        newHIC.HICID = hicID;
                        newHIC.PatientID = patientID;
                        newHIC.IssueDate = bunifuDatePickerIssue.Value;
                        newHIC.ExpireDate = bunifuDatePickerExpire.Value;
                        if (UserAction == "edit")
                        {
                            DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bảo hiểm y tế", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                HIC.DeleteHIC(HIC.GetPatientHIC(newHIC.PatientID).HICID);
                                if (HIC.InsertHIC(newHIC) > 0)
                                    bunifuSnackbar1.Show(this, "Cập nhật thông tin bảo hiểm y tế thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                        else
                        {
                            if (HIC.InsertHIC(newHIC) > 0)
                                bunifuSnackbar1.Show(this, "Thêm bảo hiểm y tế thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                        this.Close();
                    }
                    else
                    {
                        bunifuSnackbar1.Show(this, "Bảo hiểm y tế này đã hết hạn sử dụng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Ngày phát hành phải nhỏ hơn ngày hết hạn", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Sổ báo hiểm y tế này đã có người sử dụng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        private void bunifuTextBoxHICID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
