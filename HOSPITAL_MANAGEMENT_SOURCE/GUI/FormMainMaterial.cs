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
    public partial class FormMainMaterial : UserControl
    {
        public FormMainMaterial()
        {
            InitializeComponent();
        }
        // Refresh datagridview when click material tab
        public void tabItemMaterial_Click()
        {
            refreshDataViewMaterial();
        }

        private void bunifuTextBoxMaterialSearch_TextChange(object sender, EventArgs e)
        {
            searchMaterial();
        }

        private void bunifuTextBoxMaterialSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchMaterial();
            }
        }

        private void bunifubuttonMaterialDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxMaterialSearch.Text = "";
            searchMaterial();
        }

        private void bunifuButtonMaterialDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                int materialID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa vật tư", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Material.DeleteMaterial(materialID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa vật tư thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Vật tư đã hoặc đang được sử dụng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }

                refreshDataViewMaterial();
            }
        }

        private void bunifuButtonMaterialEdit_Click(object sender, EventArgs e)    //cho nay doi thanh xong cai material 
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                int materialID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
                /*FormMaterialDetail formMaterialDetail = new FormMaterialDetail(Material.GetMaterial(materialID), "edit");
                formMaterialDetail.ShowDialog();*/

                refreshDataViewMaterial();
            }
        }

        private void bunifuDataGridViewMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                int materialID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
               /* FormMaterialDetail formMaterialDetail = new FormMaterialDetail(Material.GetMaterial(materialID), "edit");
                formMaterialDetail.ShowDialog();*/

                refreshDataViewMaterial();
            }
        }

        private void bunifuButtonMaterialAdd_Click(object sender, EventArgs e)
        {
            FormMaterialDetail formMaterialDetail = new FormMaterialDetail();
            formMaterialDetail.ShowDialog();

            refreshDataViewMaterial();
        }
        //Refresh datagridview in material tab
        private void refreshDataViewMaterial()
        {
            try
            {
                // Get material's datatable
                DataTable materialTable = Material.GetListMaterial();

                // Add Vietnamese column's name
                materialTable.Columns.Add("Mã vật tư", typeof(string), "[MATERIALID]");
                materialTable.Columns.Add("Tên vật tư", typeof(string), "[MATERIALNAME]");
                materialTable.Columns.Add("Số lượng", typeof(string), "[QUANTITY]");
                materialTable.Columns.Add("Đơn giá", typeof(string), "[PRICE]");
                // Set data source to dataview for searching
                bunifuDataGridViewMaterial.DataSource = materialTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 4; i++)
                {
                    bunifuDataGridViewMaterial.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxMaterialSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < materialTable.Rows.Count; i++)
                {
                    String strmaterialName = materialTable.Rows[i][1].ToString();
                    bunifuTextBoxMaterialSearch.AutoCompleteCustomSource.Add(strmaterialName);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        //Search in datagridview
        private void searchMaterial()
        {
            // Not search it search string is empty
            if (bunifuTextBoxMaterialSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewMaterial.DataSource).RowFilter = "[Mã vật tư] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'"
                                                                + "OR [Tên vật tư] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewMaterial.DataSource).RowFilter = "";
            }
        }
    }
}

