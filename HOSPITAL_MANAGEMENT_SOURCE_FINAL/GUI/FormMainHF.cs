using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System.Windows.Forms;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormMainHF : UserControl
    {
        public FormMainHF()
        {
            InitializeComponent();
            refreshDataViewHeathFile();
        }
        public void tabItemHealthFile_Click()
        {
            refreshDataViewHeathFile();
        }
        private void refreshDataViewHeathFile()
        {
            try
            {
                // Get heath file's datatable
                DataTable heathFileTable = HealthFile.GetListHeathFile();

                // Add Vietnamese column's name
                heathFileTable.Columns.Add("Mã bệnh án", typeof(string), "[HEATHFILEID]");
                /*                heathFileTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                */
                heathFileTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENTID]");
                heathFileTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                heathFileTable.Columns.Add("Tình trạng bệnh nhân", typeof(string), "[PATIENTSTATE]");
                heathFileTable.Columns.Add("Tiền sự bệnh lý", typeof(string), "[PREHISTORY]");
                heathFileTable.Columns.Add("Bệnh mắc phải", typeof(string), "[DISEASE]");
                heathFileTable.Columns.Add("Hướng điều trị", typeof(string), "[TREATMENT]");
                // Set data source to dataview for searching
                bunifuDataGridViewHF.DataSource = heathFileTable;

                // Hide English columns'name
                for (int i = 0; i < 8; i++)
                {
                    bunifuDataGridViewHF.Columns[i].Visible = false;
                }

            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }

        private void bunifuTextBoxHFSearch_TextChange_1(object sender, EventArgs e)
        {
            searchHeathFile();
        }
        private void searchHeathFile()
        {
            // Not search it search string is empty
            if (bunifuTextBoxHFSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewHF.DataSource).RowFilter = "[Mã bệnh án] LIKE '*" + bunifuTextBoxHFSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxHFSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewHF.DataSource).RowFilter = "";
            }
        }

        private void bunifuButtonHFEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHF.SelectedRows.Count > 0)
            {
                int heathFileID = Convert.ToInt32(bunifuDataGridViewHF.SelectedRows[0].Cells[0].Value);
                FormHFDetail formHFDetail = new FormHFDetail(HealthFile.GetHeathFile(heathFileID), "edit");
                formHFDetail.ShowDialog();

                refreshDataViewHeathFile();
            }
        }

        private void bunifuButtonHFDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHF.SelectedRows.Count > 0)
            {
                int heathFileID = Convert.ToInt32(bunifuDataGridViewHF.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa bệnh án", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (HealthFile.DeleteHeathFile(heathFileID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa bệnh án thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Không thể xóa bệnh án này", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }

                refreshDataViewHeathFile();
            }
        }

        private void bunifubuttonHFDeleteSearch_Click_1(object sender, EventArgs e)
        {
            bunifuTextBoxHFSearch.Text = "";
            searchHeathFile();
        }

        private void bunifuTextBoxHFSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchHeathFile();
            }
        }

        private void bunifuDataGridViewHF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewHF.SelectedRows.Count > 0)
            {
                int heathFileID = Convert.ToInt32(bunifuDataGridViewHF.SelectedRows[0].Cells[0].Value);
                FormHFDetail formHFDetail = new FormHFDetail(HealthFile.GetHeathFile(heathFileID), "edit");
                formHFDetail.ShowDialog();

                refreshDataViewHeathFile();
            }
        }
    }
}
