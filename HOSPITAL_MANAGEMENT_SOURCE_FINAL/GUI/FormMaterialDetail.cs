//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
//{
//    public partial class FormMaterialDetail : Form
//    {
//        public FormMaterialDetail()
//        {
//            InitializeComponent();
//        }

//        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
//        {

//        }

//        private void bunifuButtonClose_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void bunifuButtonOK_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}

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
    public partial class FormMaterialDetail : Form
    {

        public Material MaterialDetail { get; set; }
        public String UserAction { get; set; }
        public FormMaterialDetail()
        {
            InitializeComponent();
        }

        public FormMaterialDetail(Material materialDetail, String usertAction)
        {
            InitializeComponent();
            this.MaterialDetail = materialDetail;
            this.UserAction = usertAction;
            if (this.UserAction == "edit")
                SetMaterialDetail(MaterialDetail);
        }
        public void SetMaterialDetail(Material materialDetail)
        {
            bunifuTextBoxMaterialID.Text = materialDetail.MaterialID.ToString();
            bunifuTextBoxMaterialName.Text = materialDetail.MaterialName;
            bunifuTextBoxMaterialQuantity.Text = materialDetail.Quantity.ToString();
            bunifuTextBoxMaterialPrice.Text = materialDetail.Price.ToString();
        }

        private void bunifuLabel24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBoxDepartmentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(bunifuTextBoxMaterialName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên thuốc", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(bunifuTextBoxMaterialPrice.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu đơn giá", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            if (string.IsNullOrEmpty(bunifuTextBoxMaterialQuantity.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu số lượng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                return;
            }
            try
            {
                if (this.UserAction == "edit")
                {
                    MaterialDetail.MaterialName = bunifuTextBoxMaterialName.Text;
                    MaterialDetail.Price = Convert.ToInt32(bunifuTextBoxMaterialPrice.Text);
                    MaterialDetail.Quantity = Convert.ToInt32(bunifuTextBoxMaterialQuantity.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Material.UpdateMaterial(MaterialDetail) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Cập nhập thông tin bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                            return;
                        }
                    }
                }
                else
                {
                    Material newMaterial = new Material(0, bunifuTextBoxMaterialName.Text, Convert.ToInt32(bunifuTextBoxMaterialQuantity.Text), Convert.ToDecimal(bunifuTextBoxMaterialPrice.Text));
                    if (Material.InsertMaterial(newMaterial) > 0)
                    {
                        bunifuSnackbar1.Show(this, "Thêm thuốc thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                        return;
                    }
                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
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

