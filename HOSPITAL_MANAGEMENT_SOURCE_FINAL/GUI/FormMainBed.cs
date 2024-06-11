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
    public partial class FormMainBed : UserControl
    {
        public FormMainBed()
        {
            InitializeComponent();
            refreshDataViewBed();
        }
        public void tabItemBed_Click()
        {
            refreshDataViewBed();
        }

        private void bunifuTextBoxBedSearch_TextChange_1(object sender, EventArgs e)
        {
            searchBed();
        }

        private void bunifuTextBoxBedSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchBed();
            }
        }

        private void bunifubuttonBedDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxBedSearch.Text = "";
            searchBed();
        }

        private void bunifuButtonReceiveBed_Click_1(object sender, EventArgs e)
        {
            if (bunifuDataGridViewBed.SelectedRows.Count > 0)
            {
                int bedID = Convert.ToInt16(bunifuDataGridViewBed.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewBed.SelectedRows[0].Cells[2].Value);
                if (state == 0)
                {
                    FormHostpitalBedDetail formHBDetail = new FormHostpitalBedDetail(HospitalBed.GetHospitalBed(bedID));
                    formHBDetail.ShowDialog();
                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Giường bệnh đang được sử dụng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
                refreshDataViewBed();
            }
        }

        private void bunifuButtonReturnBed_Click_1(object sender, EventArgs e)
        {
            if (bunifuDataGridViewBed.SelectedRows.Count > 0)
            {
                int bedID = Convert.ToInt16(bunifuDataGridViewBed.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewBed.SelectedRows[0].Cells[2].Value);
                if (state == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận trả giường", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        HospitalBed updateHB = HospitalBed.GetHospitalBed(bedID);
                        updateHB.Patient = 0;
                        updateHB.State = 0;
                        if (HospitalBed.UpdateHospitalBed(updateHB) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Trả giường thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Giường bệnh trống", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
                refreshDataViewBed();
            }
        }

        private void bunifuButtonBedDelete_Click_1(object sender, EventArgs e)
        {
            if (bunifuDataGridViewBed.SelectedRows.Count > 0)
            {
                int bedID = Convert.ToInt16(bunifuDataGridViewBed.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewBed.SelectedRows[0].Cells[2].Value);
                if (state == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận xóa giường", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {

                        if (HospitalBed.DeleteHospitalBed(bedID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa giường bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Giường bệnh đã hoặc đang được sử dụng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);


                }
                refreshDataViewBed();
            }
        }

        private void bunifuButtonBedEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Xác nhận thêm giường", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (HospitalBed.InsertHospitalBed() > 0)
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Thêm giường bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }

            }
            refreshDataViewBed();
        }
        //Refresh datagridview in hospital bed tab
        private void refreshDataViewBed()
        {
            try
            {
                // Get hospital bed's datatable
                DataTable bedTable = HospitalBed.GetListHospitalBed();

                // Add Vietnamese column's name
                bedTable.Columns.Add("Mã giường bệnh", typeof(string), "[BEDID]");
                /*                bedTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENT]");
                */
                bedTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                bedTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Trống', 'Có người')");

                // Set data source to dataview for searching
                bunifuDataGridViewBed.DataSource = bedTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 4; i++)
                {
                    bunifuDataGridViewBed.Columns[i].Visible = false;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        //Search in datagridview
        private void searchBed()
        {
            // Not search it search string is empty
            if (bunifuTextBoxBedSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewBed.DataSource).RowFilter = "[Mã giường bệnh] LIKE '*" + bunifuTextBoxBedSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxBedSearch.Text.Trim() + "*'"
                                                                + "OR [Trạng thái] LIKE '*" + bunifuTextBoxBedSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewBed.DataSource).RowFilter = "";
            }
        }
    }
}
