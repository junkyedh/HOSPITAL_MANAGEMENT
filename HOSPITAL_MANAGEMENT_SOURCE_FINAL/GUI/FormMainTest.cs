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
    public partial class FormMainTest : UserControl
    {
        public FormMainTest()
        {
            InitializeComponent();
            refreshDataViewTest();
        }
        public void tabItemTest_Click()
        {
            refreshDataViewTest();
            refreshDataViewTestDetail();
        }
        private void refreshDataViewTest()
        {
            try
            {
                // Get test's datatable
                DataTable testTable = TestCertificate.GetListTC();

                // Add Vietnamese column's name
                testTable.Columns.Add("Mã phiếu xét nghiệm", typeof(string), "[TCID]");
                /*testTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");*/
                testTable.Columns.Add("Tên nhân viên", typeof(string), "[STAFF_NAME]");
                /*                testTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                */
                testTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT_NAME]");
                testTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                testTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Chưa xét nghiệm', 'Đã xét nghiệm')");

                // Set data source to dataview for searching
                bunifuDataGridView1.DataSource = testTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 7; i++)
                {
                    bunifuDataGridView1.Columns[i].Visible = false;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        private void refreshDataViewTestDetail()
        {
            if (bunifuDataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get Test's datatable
                    int testID = Convert.ToInt32(bunifuDataGridView1.Rows[0].Cells[0].Value);
                    DataTable testDetailTable = TestDetail.GetListTestDetail(testID);
                    // Set data source to dataview for searching
                    bunifuDataGridViewMaterial.DataSource = testDetailTable.DefaultView;
                }
                catch
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
            }
        }
        private void searchTest()
        {
            // Not search it search string is empty
            if (bunifuTextBoxMaterialSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridView1.DataSource).RowFilter = "[Mã phiếu xét nghiệm] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'"
                                                                + "OR [Tên bệnh nhân] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'"
                                                                 + "OR [Tên nhân viên] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'"
                                                                  + "OR [Trạng thái] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'";
                refreshDataViewTestDetail();
            }
            else
            {
                ((DataView)bunifuDataGridView1.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxMaterialSearch_TextChange_1(object sender, EventArgs e)
        {
            searchTest();
        }

        private void bunifuTextBoxMaterialSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchTest();
            }
        }

        private void bunifubuttonMaterialDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxMaterialSearch.Text = "";
            searchTest();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count > 0)
            {
                int testID = Convert.ToInt32(bunifuDataGridView1.SelectedRows[0].Cells[0].Value);
                DataTable dtTD = TestDetail.GetListTestDetail(testID);

                bunifuDataGridViewMaterial.DataSource = dtTD.DefaultView;
            }
        }

        private void bunifuButtonMaterialDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count > 0)
            {
                int testID = Convert.ToInt32(bunifuDataGridView1.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phiếu xét nghiệm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (TestDetail.DeleteTestDetail(testID) > 0 && TestCertificate.DeleteTC(testID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa phiếu xét nghiệm thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Không thể xóa phiếu xét nghiệm", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }
                refreshDataViewTest();
                refreshDataViewTestDetail();
            }
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count > 0)
            {
                int testID = Convert.ToInt32(bunifuDataGridView1.SelectedRows[0].Cells[0].Value);
                TestCertificate updateTD = TestCertificate.GetTC(testID);
                FormTestDetail formTD = new FormTestDetail(updateTD, "edit");
                formTD.ShowDialog();

                refreshDataViewTest();
                refreshDataViewTestDetail();
            }
        }

        private void bunifuButtonMaterialEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count > 0)
            {
                int testID = Convert.ToInt32(bunifuDataGridView1.SelectedRows[0].Cells[0].Value);
                TestCertificate updateTD = TestCertificate.GetTC(testID);
                FormTestDetail formTD = new FormTestDetail(updateTD, "edit");
                formTD.ShowDialog();

                refreshDataViewTest();
                refreshDataViewTestDetail();
            }
        }

        private void FormMainTest_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBoxMaterialSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
