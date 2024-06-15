using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormMedicineDetail : Form
    {
        private Medicine MedicineDetail { get; set; }
        public string UserAction { get; set; }
        public FormMedicineDetail()
        {
            InitializeComponent();
            bunifuTextBoxMedicineID.Enabled = false;

        }

        public FormMedicineDetail(Medicine medicineDetail, string usertAction)
        {
            InitializeComponent();
            bunifuTextBoxMedicineID.Enabled = false;
            this.MedicineDetail = medicineDetail;
            this.UserAction = usertAction;
            if (this.UserAction == "edit")
            {
                SetMedicineDetail(MedicineDetail);

            }
        }
        public void SetMedicineDetail(Medicine medicineDetail)
        {
            bunifuTextBoxMedicineID.Text = medicineDetail.MedicineID.ToString();
            bunifuTextBoxMedicineName.Text = medicineDetail.MedicineName;
            bunifuTextBoxMedicineQuantity.Text = medicineDetail.Quantity.ToString();
            bunifuTextBoxMedicinePrice.Text = medicineDetail.Price.ToString();
        }

        private void bunifuLabel24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBoxDepartmentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBoxMedicineName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên thuốc", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(bunifuTextBoxMedicinePrice.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu đơn giá", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(bunifuTextBoxMedicineQuantity.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu số lượng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            try
            {
                if (this.UserAction == "edit")
                {
                    bunifuTextBoxMedicineID.Enabled = false;
                    MedicineDetail.MedicineName = bunifuTextBoxMedicineName.Text;
                    MedicineDetail.Price = Convert.ToDecimal(bunifuTextBoxMedicinePrice.Text);
                    MedicineDetail.Quantity = Convert.ToInt32(bunifuTextBoxMedicineQuantity.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin thuốc", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Medicine.UpdateMedicine(MedicineDetail) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Cập nhập thông tin thuốc thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                            return;
                        }
                    }
                }
                else
                {
                    int newMedicineId = Medicine.GetNextMedicineID();
                    Medicine newMedicine = new Medicine(newMedicineId, bunifuTextBoxMedicineName.Text.ToString(), Convert.ToInt32(bunifuTextBoxMedicineQuantity.Text), Convert.ToDecimal(bunifuTextBoxMedicinePrice.Text));
                    if (Medicine.InsertMedicine(newMedicine) > 0)
                    {
                        bunifuSnackbar1.Show(this, "Thêm thuốc thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this, $"Lỗi dữ liệu {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }

            this.Close();
        }

        private void bunifuTextBoxDepartmentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
