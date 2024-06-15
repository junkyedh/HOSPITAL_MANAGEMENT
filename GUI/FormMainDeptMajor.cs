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
    public partial class FormMainDeptMajor : UserControl
    {
        public FormMainDeptMajor()
        {
            InitializeComponent();
        }
        public void KhoaCN_Click()
        {
            refreshDataViewDepartment();
            refreshDataViewMajor();
        }
        private void refreshDataViewDepartment()
        {
            try
            {
                // Get department's datatable
                DataTable departmentTable = DAL.Department.GetListDepartment();

                // Add Vietnamese column's name
                departmentTable.Columns.Add("Mã phòng ban", typeof(string), "[DEPARTMENTID]");
                departmentTable.Columns.Add("Tên phòng ban", typeof(string), "[DEPARTMENTNAME]");
                // Set data source to dataview for searching
                bunifuDataGridViewDeparment.DataSource = departmentTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 2; i++)
                {
                    bunifuDataGridViewDeparment.Columns[i].Visible = false;
                }

            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(Form.ActiveForm, $"Lỗi dữ liệu: {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
        }
        private void refreshDataViewMajor()
        {
            try
            {
                // Get department's datatable
                DataTable majorTable = DAL.Major.GetListMajor();

                // Add Vietnamese column's name
                majorTable.Columns.Add("Mã chuyên ngành", typeof(string), "[MAJORID]");
                majorTable.Columns.Add("Tên chuyên ngành", typeof(string), "[MAJORNAME]");
                // Set data source to dataview for searching
                bunifuDataGridViewMajor.DataSource = majorTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 2; i++)
                {
                    bunifuDataGridViewMajor.Columns[i].Visible = false;
                }

            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(Form.ActiveForm, $"Lỗi dữ liệu {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
        }


        private void bunifuButtonDepartmentDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDeparment.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt16(bunifuDataGridViewDeparment.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phòng ban", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (DAL.Department.DeleteDepartment(departmentID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa phòng ban thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Phòng khoa đang có người công tác", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                }

                refreshDataViewDepartment();
            }
        }
        private void bunifuButtonDepartmentEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDeparment.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt16(bunifuDataGridViewDeparment.SelectedRows[0].Cells[0].Value);
                FormDepartmentDetail departmentDetail = new FormDepartmentDetail(DAL.Department.GetDepartment(departmentID), "edit");
                departmentDetail.ShowDialog();

                refreshDataViewDepartment();
            }
        }
        private void bunifuButtonDepartmentAdd_Click(object sender, EventArgs e)
        {
            FormDepartmentDetail formDepartmentDetail = new FormDepartmentDetail();
            formDepartmentDetail.ShowDialog();

            refreshDataViewDepartment();
        }

        private void bunifuButtonMajorDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMajor.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt16(bunifuDataGridViewMajor.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa chuyên ngành", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (DAL.Major.DeleteMajor(majorID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa chuyên ngành thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        }
                    }
                    catch (Exception ex)
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Chuyên ngành đang có người công tác", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    }
                }

                refreshDataViewMajor();
            }
        }

        private void bunifuButtonMajorEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMajor.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt16(bunifuDataGridViewMajor.SelectedRows[0].Cells[0].Value);
                Major updateMajor = DAL.Major.GetMajor(majorID);
                FormMajorDetail formMD = new FormMajorDetail(updateMajor, "edit");
                formMD.ShowDialog();

                refreshDataViewMajor();
            }
        }

        private void bunifuButtonMajorAdd_Click(object sender, EventArgs e)
        {
            FormMajorDetail majorDetail = new FormMajorDetail();
            majorDetail.ShowDialog();

            refreshDataViewMajor();
        }
    }
}
