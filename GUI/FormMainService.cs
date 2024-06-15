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
    public partial class FormMainService : UserControl
    {
        public FormMainService()
        {
            InitializeComponent();
            refreshDataViewService();
        }
        public void tabItemService_Click()
        {
            refreshDataViewService();
        }
        private void refreshDataViewService()
        {
            try
            {
                // Get service's datatable
                DataTable serviceTable = Service.GetListService();

                // Add Vietnamese column's name
                serviceTable.Columns.Add("Mã dịch vụ", typeof(string), "[SERVICEID]");
                serviceTable.Columns.Add("Tên dịch vụ", typeof(string), "[SERVICENAME]");
                serviceTable.Columns.Add("Đơn giá", typeof(string), "[PRICE]");
                // Set data source to dataview for searching
                bunifuDataGridViewMaterial.DataSource = serviceTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 3; i++)
                {
                    bunifuDataGridViewMaterial.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxMaterialSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < serviceTable.Rows.Count; i++)
                {
                    String strserviceName = serviceTable.Rows[i][1].ToString();
                    bunifuTextBoxMaterialSearch.AutoCompleteCustomSource.Add(strserviceName);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        private void searchService()
        {
            // Not search it search string is empty
            if (bunifuTextBoxMaterialSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewMaterial.DataSource).RowFilter = "[Mã dịch vụ] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'"
                                                                + "OR [Tên dịch vụ] LIKE '*" + bunifuTextBoxMaterialSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewMaterial.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxMaterialSearch_TextChange_1(object sender, EventArgs e)
        {
            searchService();
        }

        private void bunifubuttonMaterialDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxMaterialSearch.Text = "";
            searchService();
        }

        private void bunifuTextBoxMaterialSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchService();
            }
        }

        private void bunifuButtonMaterialDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                int serviceID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa dịch vụ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Service.DeleteService(serviceID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa dịch thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Dịch vụ đã hoặc đang được sử dụng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);


                    }
                }

                refreshDataViewService();
            }

        }

        private void bunifuButtonMaterialEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                int serviceID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
                FormService FormService = new FormService(Service.GetService(serviceID), "edit");
                FormService.ShowDialog();

                refreshDataViewService();
            }
        }

        private void bunifuDataGridViewMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewMaterial.SelectedRows.Count > 0)
            {
                int serviceID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
                FormService FormService = new FormService(Service.GetService(serviceID), "edit");
                FormService.ShowDialog();

                refreshDataViewService();
            }
        }

        private void bunifuButtonMaterialAdd_Click(object sender, EventArgs e)
        {
            int serviceID = Convert.ToInt16(bunifuDataGridViewMaterial.SelectedRows[0].Cells[0].Value);
            FormService FormService = new FormService();
            FormService.ShowDialog();

            refreshDataViewService();
        }

        private void FormMainService_Load(object sender, EventArgs e)
        {

        }
    }
}
