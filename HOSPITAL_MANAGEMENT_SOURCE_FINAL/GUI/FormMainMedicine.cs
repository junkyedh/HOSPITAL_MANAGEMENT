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
    public partial class FormMainMedicine : UserControl
    {
        public FormMainMedicine()
        {
            InitializeComponent();
            refreshDataViewMedicine();
        }
        public void tabItemMedicine_Click()
        {
            refreshDataViewMedicine();
        }
        private void refreshDataViewMedicine()
        {
            try
            {
                // Get Medicine's datatable
                DataTable MedicineTable = Medicine.GetListMedicine();

                // Add Vietnamese column's name
                MedicineTable.Columns.Add("Mã thuốc", typeof(string), "[MEDICINEID]");
                MedicineTable.Columns.Add("Tên thuốc", typeof(string), "[MEDICINENAME]");
                MedicineTable.Columns.Add("Số lượng", typeof(string), "[QUANTITY]");
                MedicineTable.Columns.Add("Giá thành", typeof(string), "[PRICE]");
                // Set data source to dataview for searching
                bunifuDataGridViewMedicine.DataSource = MedicineTable;

                // Hide English columns'name
                for (int i = 0; i < 4; i++)
                {
                    bunifuDataGridViewMedicine.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxMedicineSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < MedicineTable.Rows.Count; i++)
                {
                    String strMedicineName = MedicineTable.Rows[i][1].ToString();
                    bunifuTextBoxMedicineSearch.AutoCompleteCustomSource.Add(strMedicineName);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        //Search in datagridview
        private void searchMedicine()
        {
            // Not search it search string is empty
            if (bunifuTextBoxMedicineSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewMedicine.DataSource).RowFilter = "[Mã thuốc] LIKE '*" + bunifuTextBoxMedicineSearch.Text.Trim() + "*'"
                                                                + "OR [Tên thuốc] LIKE '*" + bunifuTextBoxMedicineSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewMedicine.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxMedicineSearch_TextChange_1(object sender, EventArgs e)
        {
            searchMedicine();
        }

        private void bunifuTextBoxMedicineSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchMedicine();
            }
        }

        private void bunifubuttonMedicineDeleteSearch_Click_1(object sender, EventArgs e)
        {
            bunifuTextBoxMedicineSearch.Text = "";
            searchMedicine();
        }

        private void bunifuButtonMedicineDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMedicine.SelectedRows.Count > 0)
            {
                int MedicineID = Convert.ToInt32(bunifuDataGridViewMedicine.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa thuốc", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Medicine.DeleteMedicine(MedicineID) > 0)
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa thuốc thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Bệnh đã hoặc đang có người mắc phải", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }

                refreshDataViewMedicine();
            }
        }

        private void bunifuDataGridViewMedicine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewMedicine.SelectedRows.Count > 0)
            {
                int MedicineID = Convert.ToInt16(bunifuDataGridViewMedicine.SelectedRows[0].Cells[0].Value);
                FormMedicineDetail formMedicineDetail = new FormMedicineDetail();
                formMedicineDetail.ShowDialog();

                refreshDataViewMedicine();
            }
        }

        private void bunifuButtonMedicineEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMedicine.SelectedRows.Count > 0)
            {
                int MedicineID = Convert.ToInt32(bunifuDataGridViewMedicine.SelectedRows[0].Cells[0].Value);
                FormMedicineDetail formMedicineDetail = new FormMedicineDetail(Medicine.GetMedicine(MedicineID), "edit");
                formMedicineDetail.ShowDialog();

                refreshDataViewMedicine();
            }
        }

        private void bunifuButtonMedicineAdd_Click(object sender, EventArgs e)
        {
            FormMedicineDetail formMedicineDetail = new FormMedicineDetail();
            formMedicineDetail.ShowDialog();

            refreshDataViewMedicine();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
