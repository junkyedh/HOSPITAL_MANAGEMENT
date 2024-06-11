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
    public partial class FormMainDisease : UserControl
    {
        public FormMainDisease()
        {
            InitializeComponent();
            refreshDataViewDisease();
        }
        public void tabItemDisease_Click()
        {
            refreshDataViewDisease();
        }
        private void refreshDataViewDisease()
        {
            try
            {
                // Get disease's datatable
                DataTable diseaseTable = Disease.GetListDisease();

                // Add Vietnamese column's name
                diseaseTable.Columns.Add("Mã bệnh", typeof(string), "[DISEASEID]");
                diseaseTable.Columns.Add("Tên bệnh", typeof(string), "[DISEASENAME]");
                diseaseTable.Columns.Add("Triệu chứng", typeof(string), "[SYMPTOM]");
                // Set data source to dataview for searching
                bunifuDataGridViewDisease.DataSource = diseaseTable;

                // Hide English columns'name
                for (int i = 0; i < 3; i++)
                {
                    bunifuDataGridViewDisease.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxDiseaseSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < diseaseTable.Rows.Count; i++)
                {
                    String strDiseaseName = diseaseTable.Rows[i][1].ToString();
                    bunifuTextBoxDiseaseSearch.AutoCompleteCustomSource.Add(strDiseaseName);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        //Search in datagridview
        private void searchDisease()
        {
            // Not search it search string is empty
            if (bunifuTextBoxDiseaseSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewDisease.DataSource).RowFilter = "[Mã bệnh] LIKE '*" + bunifuTextBoxDiseaseSearch.Text.Trim() + "*'"
                                                                + "OR [Tên bệnh] LIKE '*" + bunifuTextBoxDiseaseSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewDisease.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxDiseaseSearch_TextChange_1(object sender, EventArgs e)
        {
            searchDisease();
        }

        private void bunifuTextBoxDiseaseSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchDisease();
            }
        }

        private void bunifubuttonDiseaseDeleteSearch_Click_1(object sender, EventArgs e)
        {
            bunifuTextBoxDiseaseSearch.Text = "";
            searchDisease();
        }

        private void bunifuButtonDiseaseDelete_Click_1(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDisease.SelectedRows.Count > 0)
            {
                int diseaseID = Convert.ToInt16(bunifuDataGridViewDisease.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Disease.DeleteDisease(diseaseID) > 0)
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Bệnh đã hoặc đang có người mắc phải", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }

                refreshDataViewDisease();
            }
        }

        private void bunifuDataGridViewDisease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewDisease.SelectedRows.Count > 0)
            {
                int diseaseID = Convert.ToInt16(bunifuDataGridViewDisease.SelectedRows[0].Cells[0].Value);
                FormDiseaseDetail formDiseaseDetail = new FormDiseaseDetail(Disease.GetDisease(diseaseID), "edit");
                formDiseaseDetail.ShowDialog();

                refreshDataViewDisease();
            }
        }

        private void bunifuButtonDiseaseEdit_Click_1(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDisease.SelectedRows.Count > 0)
            {
                int diseaseID = Convert.ToInt16(bunifuDataGridViewDisease.SelectedRows[0].Cells[0].Value);
                FormDiseaseDetail formDiseaseDetail = new FormDiseaseDetail(Disease.GetDisease(diseaseID), "edit");
                formDiseaseDetail.ShowDialog();

                refreshDataViewDisease();
            }
        }

        private void bunifuButtonDiseaseAdd_Click_1(object sender, EventArgs e)
        {
            FormDiseaseDetail formDiseaseDetail = new FormDiseaseDetail();
            formDiseaseDetail.ShowDialog();

            refreshDataViewDisease();
        }
    }
}
