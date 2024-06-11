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
    public partial class FormMainStaff : UserControl
    {
        public FormMainStaff()
        {
            InitializeComponent();
        }
        public void NhanVien_Click()
        {
            refreshDataViewStaff();
        }
        private void refreshDataViewStaff()
        {
            try
            {
                DataTable staffTable = DAL.Staff.GetListStaff();

                staffTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                staffTable.Columns.Add("Họ tên", typeof(string), "[LASTNAME] + ' ' + [FIRSTNAME]");
                staffTable.Columns.Add("Quyền", typeof(string), "[ROLENAME]");
                staffTable.Columns.Add("Khoa", typeof(string), "[DEPARTMENTNAME]");
                staffTable.Columns.Add("Chuyên ngành", typeof(string), "[MAJORNAME]");
                staffTable.Columns.Add("CMND", typeof(string), "[ICN]");
                staffTable.Columns.Add("Giới tính", typeof(string), "IIF([GENDER] = 0, 'Nam', 'Nữ')");
                staffTable.Columns.Add("Ngày sinh", typeof(DateTime), "[BIRTHDAY]");
                //staffTable.Columns.Add("Email", typeof(string), "[EMAIL]");
                staffTable.Columns.Add("Địa chỉ", typeof(string), "[ADDRESS]");
                staffTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Đã thôi việc', 'Đang làm việc')");
                staffTable.Columns.Add("Số điện thoại", typeof(string), "[SDT]");

                //bunifuDataGridViewMaterial.Columns.Width = 240; // Chiều rộng cố định, bạn có thể thay đổi giá trị này
                //bunifuDataGridViewMaterial.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                bunifuDataGridViewMaterial.DataSource = staffTable.DefaultView;

                bunifuDataGridViewMaterial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuDataGridViewMaterial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                bunifuDataGridViewMaterial.ScrollBars = ScrollBars.Both;

                for (int i = 0; i < 14; ++i)
                {
                    bunifuDataGridViewMaterial.Columns[i].Visible = false;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
        }

        private void bunifuButtonMaterialDelete_Click(object sender, EventArgs e)
        {
            int staffID;
            try
            {
                if (MessageBox.Show("Xác nhận xóa nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
                    {
                        if (Int32.TryParse(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value.ToString(), out staffID))
                        {
                            DAL.Staff.DeleteStaff(staffID);
                        }
                    }
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }

            refreshDataViewStaff();
        }
        private void bunifuButtonMaterialEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                Console.WriteLine("Thay đổi thông tin nhân viên");
                Staff staffDetail = Staff.GetStaff(Convert.ToInt32(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value.ToString()));
                FormStaffDetail staffDetailForm = new FormStaffDetail("edit", staffDetail);
                staffDetailForm.ShowDialog();

                refreshDataViewStaff();
            }
        }
        private void bunifuButtonMaterialAdd_Click(object sender, EventArgs e)
        {
            FormStaffDetail staffDetailForm = new FormStaffDetail("add", new Staff());
            staffDetailForm.ShowDialog();

            refreshDataViewStaff();
        }


        private void bunifubuttonMaterialDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxMaterialSearch.Text = "";
            searchStaff();
        }


        private void searchStaff()
        {
            // Not search if search string is empty
            if (!"".Equals(bunifuTextBoxMaterialSearch.Text))
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewMaterial.DataSource).RowFilter =
                    "[Họ tên] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'" +
                    "OR [Mã nhân viên] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'" +
                    "OR [CMND] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'" +
                    "OR [Khoa] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'" +
                    "OR [Chuyên ngành] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewMaterial.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxMaterialSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchStaff();
            }
        }

        private void bunifuTextBoxMaterialSearch_TextChange(object sender, EventArgs e)
        {
            searchStaff();
        }
    }
}
