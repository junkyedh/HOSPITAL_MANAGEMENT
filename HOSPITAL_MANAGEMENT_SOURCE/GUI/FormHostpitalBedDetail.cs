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
    public partial class FormHostpitalBedDetail : Form
    {
        public HospitalBed HBDetail { get; set; }
        public FormHostpitalBedDetail()
        {
            InitializeComponent();
        }
        /*public FormHostpitalBedDetail(HospitalBed hbDetail)   ////Chỗ này thử đổi sang  để 
        {                                                       ////để phù hợp với usercontrol 
            InitializeComponent();
            HBDetail = hbDetail;
            SetHospitalBedDetail(hbDetail);
        }*/
        public FormHostpitalBedDetail(HospitalBed hbDetail)
        {
            InitializeComponent();
            HBDetail = hbDetail;
            SetHospitalBedDetail(hbDetail);
        }
        private void SetHospitalBedDetail(HospitalBed hbDetail)
        {
            textBoxHospitalBedID.Text = hbDetail.BedID.ToString();
            textBoxPatientID.Text = hbDetail.Patient.ToString();
            if (hbDetail.State == 0)
                comboBoxState.SelectedIndex = 0;
            else
                comboBoxState.SelectedIndex = 1;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPatientID.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tin mã bệnh nhân", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }

            HBDetail.Patient = Convert.ToInt32(textBoxPatientID.Text);
            String str = comboBoxState.Items[comboBoxState.SelectedIndex].ToString();
            HBDetail.State = 1;
            if (Patient.IsPatientExist(HBDetail.Patient))
            {
                try
                {
                    if (!HospitalBed.CheckPatient(HBDetail.Patient))
                    {
                        if (HospitalBed.UpdateHospitalBed(HBDetail) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Nhận giường thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                            return;
                        }
                        this.Close();
                    }
                    else
                    {
                        bunifuSnackbar1.Show(this, "Bệnh nhân đã nhận giường", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                        return;
                    }
                }
                catch
                {
                    bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                    return;
                }
            }
            else
            {
                bunifuSnackbar1.Show(this, "Bệnh nhân không tồn tại", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }

        }

        private void textBoxPatientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
