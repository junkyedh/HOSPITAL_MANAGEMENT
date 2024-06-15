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
    public partial class FormMainRole : UserControl
    {
        public FormMainRole()
        {
            InitializeComponent();
        }
        public void PhanQuyen_Click()
        {
            refreshDataViewRole();
            refreshDataViewRoleDetail();
        }
        private void refreshDataViewRole()
        {
            try
            {
                DataTable roleTable = Role.GetListRole();

                roleTable.Columns.Add("Mã phân quyền", typeof(string), "[ROLEID]");
                roleTable.Columns.Add("Tên phân quyền", typeof(string), "[ROLENAME]");

                bunifuDataGridViewRole.DataSource = roleTable.DefaultView;

                for (int i = 0; i < 2; i++)
                {
                    bunifuDataGridViewRole.Columns[i].Visible = false;
                }

                bunifuTextBoxRoleSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < roleTable.Rows.Count; i++)
                {
                    string strRoleName = roleTable.Rows[i][1].ToString();
                    bunifuTextBoxRoleSearch.AutoCompleteCustomSource.Add(strRoleName);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
        }
        private void refreshDataViewRoleDetail()
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                try
                {
                    int roleID = Convert.ToInt16(bunifuDataGridViewRole.Rows[0].Cells[0].Value);
                    DataTable roleDetailTable = RoleDetail.GetListStaffFunction(roleID);
                    // Set data source to dataview for searching
                    bunifuDataGridViewRoleDetail.DataSource = roleDetailTable;
                }
                catch
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                }
            }
        }

        private void searchRole()
        {
            if (bunifuTextBoxRoleSearch.Text != "")
            {
                ((DataView)bunifuDataGridViewRole.DataSource).RowFilter =
                    "[Tên phân quyền] LIKE '*" + bunifuTextBoxRoleSearch.Text.Trim() + "*'" +
                    "OR [Mã phân quyền] LIKE '*" + bunifuTextBoxRoleSearch.Text.Trim() + "*'";

                refreshDataViewRole();
            }
            else
            {
                ((DataView)bunifuDataGridViewRole.DataSource).RowFilter = "";
            }
        }

        private void bunifubuttonRoleDeleteSearch_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận phân quyền", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (RoleDetail.DeleteRoleDetail(roleID) > 0 && Role.DeleteRole(roleID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa phân quyền thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                }

                refreshDataViewRole();
                refreshDataViewRoleDetail();
            }
        }
        private void bunifuButtonRoleDelete_Click(object sender, EventArgs e)
        {

        }
        private void bunifuButtonRoleEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                //int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                //FormRoleDetail formRoleDetail = new FormRoleDetail(Role.GetRole(roleID), "edit");
                //formRoleDetail.ShowDialog();

                //refreshDataViewRole();
                //refreshDataViewRoleDetail();
            }
        }

        private void bunifuButtonRoleAdd_Click(object sender, EventArgs e)
        {
            FormRoleDetail formRoleDetail = new FormRoleDetail();
            formRoleDetail.ShowDialog();

            refreshDataViewRole();
            refreshDataViewRoleDetail();
        }

        private void bunifuDataGridViewRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                DataTable roleDetailTable = RoleDetail.GetListStaffFunction(roleID);

                bunifuDataGridViewRoleDetail.DataSource = roleDetailTable;
            }
        }
    }
}
