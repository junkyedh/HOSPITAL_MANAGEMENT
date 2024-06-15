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
    public partial class FormMainAssigment : UserControl
    {
        public FormMainAssigment()
        {
            InitializeComponent();
        }
        public void PhanCong_Click()
        {
            refreshDataViewAssignment();
            refreshDataViewAssignmentDetail();
        }
        private void refreshDataViewAssignment()
        {
            try
            {
                // Get assignment's datatable
                DataTable assignmentTable = DAL.Assignment.GetListAssignment();

                // Add Vietnamese column's name
                assignmentTable.Columns.Add("Mã phân công", typeof(string), "[ASSIGNID]");
                assignmentTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                assignmentTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                assignmentTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                assignmentTable.Columns.Add("Ngày nhập viện", typeof(DateTime), "[HOPITALIZATEDATE]");
                assignmentTable.Columns.Add("Ngày xuất viện", typeof(DateTime), "[DISCHARGEDDATE]");

                // Set data source to dataview for searching
                bunifuDataGridViewAssignment.DataSource = assignmentTable.DefaultView;

                bunifuDataGridViewAssignment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                bunifuDataGridViewAssignment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                bunifuDataGridViewAssignment.ScrollBars = ScrollBars.Both;

                // Hide English columns'name
                for (int i = 0; i < 6; i++)
                {
                    bunifuDataGridViewAssignment.Columns[i].Visible = false;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
        }

        private void refreshDataViewAssignmentDetail()
        {
            if (bunifuDataGridViewAssignment.SelectedRows.Count > 0)
            {
                try
                {
                    int assignmentID = Convert.ToInt32(bunifuDataGridViewAssignment.Rows[0].Cells[0].Value);
                    DataTable assignmentDetailTable = DAL.AssignmentDetail.GetListAssignmentDetails(assignmentID);

                    assignmentDetailTable.Columns.Add("Mã phân công", typeof(string), "[ASSIGNID]");
                    assignmentDetailTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                    assignmentDetailTable.Columns.Add("Họ nhân viên", typeof(string), "[LASTNAME]");
                    assignmentDetailTable.Columns.Add("Tên nhân viên", typeof(string), "[FIRSTNAME]");
                    bunifuDataGridViewAssignmentDetail.DataSource = assignmentDetailTable.DefaultView;

                    bunifuDataGridViewAssignmentDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    bunifuDataGridViewAssignmentDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    bunifuDataGridViewAssignmentDetail.ScrollBars = ScrollBars.Both;

                    for (int i = 0; i < 4; ++i)
                    {
                        bunifuDataGridViewAssignmentDetail.Columns[i].Visible = false;
                    }
                }
                catch
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                }
            }
        }

        private void bunifubuttonMaterialDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxMaterialSearch.Text = "";
            searchAsssignment();
        }

        private void bunifuButtonMaterialDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewAssignment.SelectedRows.Count > 0)
            {
                int assignID = Convert.ToInt32(bunifuDataGridViewAssignment.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phân công", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (AssignmentDetail.DeleteAssignmentDetails(assignID) > 0 && Assignment.DeleteAssignment(assignID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa phân công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = $"Lỗi dữ liệu: {ex.Message}\nChi tiết: {ex.StackTrace}";
                        bunifuSnackbar1.Show(Form.ActiveForm, errorMessage, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                }
                refreshDataViewAssignment();
                refreshDataViewAssignmentDetail();
            }
        }

        private void bunifuButtonMaterialEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewAssignment.SelectedRows.Count > 0)
            {
                int assignID = Convert.ToInt32(bunifuDataGridViewAssignment.SelectedRows[0].Cells[0].Value);
                Assignment updateAssign = Assignment.GetAssignment(assignID);

                FormAssignDetail formAD = new FormAssignDetail(updateAssign, "edit");
                formAD.ShowDialog();
                refreshDataViewAssignment();
                refreshDataViewAssignmentDetail();
            }
        }

        private void bunifuTextBoxMaterialSearch_TextChange(object sender, EventArgs e)
        {
            searchAsssignment();
        }

        private void bunifuTextBoxMaterialSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchAsssignment();
            }
        }

        private void searchAsssignment()
        {
            // Not search it search string is empty
            if (bunifuTextBoxMaterialSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewAssignment.DataSource).RowFilter =
                    "[Mã phân công] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'" +
                    "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'" +
                    "OR [Tên bệnh nhân] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'";
                refreshDataViewAssignmentDetail();
            }
            else
            {
                ((DataView)bunifuDataGridViewAssignment.DataSource).RowFilter = "";
            }
        }

        private void bunifuDataGridViewAssignment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewAssignment.SelectedRows.Count > 0)
            {
                try
                {
                    int assignID = Convert.ToInt32(bunifuDataGridViewAssignment.SelectedRows[0].Cells[0].Value);
                    DataTable dtad = AssignmentDetail.GetListAssignmentDetails(assignID);

                    dtad.Columns.Add("Mã phân công", typeof(string), "[ASSIGNID]");
                    dtad.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                    dtad.Columns.Add("Họ nhân viên", typeof(string), "[LASTNAME]");
                    dtad.Columns.Add("Tên nhân viên", typeof(string), "[FIRSTNAME]");
                    bunifuDataGridViewAssignmentDetail.DataSource = dtad.DefaultView;

                    for (int i = 0; i < 4; ++i)
                    {
                        bunifuDataGridViewAssignmentDetail.Columns[i].Visible = false;
                    }
                }
                catch
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                }
            }
        }
    }
}
