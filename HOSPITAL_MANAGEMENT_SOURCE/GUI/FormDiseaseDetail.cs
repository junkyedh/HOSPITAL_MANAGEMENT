using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormDiseaseDetail : Form
    {
        //public Disease DiseaseDetail { get; set; }
        //public String UserAction { get; set; }
        //public FormDiseaseDetail()
        //{
        //    InitializeComponent();
        //}
        //public FormDiseaseDetail(Disease diseaseDetail, String usertAction)
        //{
        //    InitializeComponent();
        //    this.DiseaseDetail = diseaseDetail;
        //    this.UserAction = usertAction;
        //    if (this.UserAction == "edit")
        //        SetDiseaseDetail(diseaseDetail);
        //}
        //public void SetDiseaseDetail(Disease diseaseDetail)
        //{
        //    textBoxDiseaseID.Text = diseaseDetail.DiseaseID.ToString();
        //    textBoxDiseaseName.Text = diseaseDetail.DiseaseName;
        //    textBoxDiseaseSymptom.Text = diseaseDetail.Symptom;
        //}

        //private void buttonClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void buttonOk_Click(object sender, EventArgs e)
        //{

        //    if (string.IsNullOrEmpty(textBoxDiseaseName.Text))
        //    {
        //        bunifuSnackbar1.Show(this, "Thiếu tên bệnh", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
        //        return;
        //    }

        //    if (string.IsNullOrEmpty(textBoxDiseaseSymptom.Text))
        //    {
        //        bunifuSnackbar1.Show(this, "Thiếu thông tin triệu chứng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
        //        return;
        //    }
        //    try
        //    {
        //        if (this.UserAction == "edit")
        //        {
        //            DiseaseDetail.DiseaseName = textBoxDiseaseName.Text;
        //            DiseaseDetail.Symptom = textBoxDiseaseSymptom.Text;
        //            DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //            if (dialogResult == DialogResult.Yes)
        //            {
        //                if (Disease.UpdateDisease(DiseaseDetail) > 0)
        //                {
        //                    bunifuSnackbar1.Show(this, "Cập nhập thông tin bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Disease newDisease = new Disease(0, textBoxDiseaseName.Text, textBoxDiseaseSymptom.Text);
        //            if (Disease.InsertDisease(newDisease) > 0)
        //            {
        //                bunifuSnackbar1.Show(this, "Thêm bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
        //                return;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
        //        return;
        //    }

        //    this.Close();

        //}

        //private void textBoxDiseaseName_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
        //                  (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
        //                  e.KeyChar == 8 || // Backspace
        //                  e.KeyChar == 32 || // Space
        //                  e.KeyChar == 16 || // Shift
        //                  e.KeyChar == 46 || // Delete
        //                  (e.KeyChar >= 'À' && e.KeyChar <= 'ỹ') || // Vietnamese characters and accented vowels
        //                  (e.KeyChar >= 'à' && e.KeyChar <= 'ỹ'));
        //}

        //private void textBoxDiseaseSymptom_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
        //                  (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
        //                  e.KeyChar == 8 || // Backspace
        //                  e.KeyChar == 32 || // Space
        //                  e.KeyChar == 16 || // Shift
        //                  e.KeyChar == 46 || // Delete
        //                  (e.KeyChar >= 'À' && e.KeyChar <= 'ỹ') || // Vietnamese characters and accented vowels
        //                  (e.KeyChar >= 'à' && e.KeyChar <= 'ỹ'));
        //}
    }
}
