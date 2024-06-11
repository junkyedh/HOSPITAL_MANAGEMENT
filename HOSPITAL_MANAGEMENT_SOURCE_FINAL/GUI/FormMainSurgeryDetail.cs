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

//namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
//{
//    public partial class FormMainSurgeryDetail : UserControl
//    {
//        public FormMainSurgeryDetail()
//        {
//            InitializeComponent();
//        }

       
//    }
//}



namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormMainSurgeryDetail : UserControl
    {
        public FormMainSurgeryDetail()
        {
            InitializeComponent();
            refreshDataViewSurgeryDetail();
        }
        public void tabItemSurgeryDetail_Click()
        {
            refreshDataViewSurgeryDetail();
        }
        private void refreshDataViewSurgeryDetail()
        {
            try
            {
                // Get SurgeryDetail's datatable
                DataTable patientSurgicaltable = Surgical.GetListSurgical();

                // Add Vietnamese column's name
                patientSurgicaltable.Columns.Add("Mã ca ", typeof(int), "[SURGICALID]");
                patientSurgicaltable.Columns.Add("Mã bệnh nhân", typeof(int), "[PATIENTID]");
                patientSurgicaltable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT_NAME]");
                patientSurgicaltable.Columns.Add("Ngày phẫu thuật", typeof(string), "[DATE]");
                patientSurgicaltable.Columns.Add("Mô tả", typeof(string), "[DESCRIPTION]");
                patientSurgicaltable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Chưa thực hiện', 'Đã thực hiện')");
                // Set data source to dataview for searching
                bunifuDataGridViewSurgery.DataSource = patientSurgicaltable;

                // Hide English columns'name
                for (int i = 0; i < 6; i++)
                {
                    bunifuDataGridViewSurgery.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxSergerySearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < patientSurgicaltable.Rows.Count; i++)
                {
                    String strSurgeryDetailName = patientSurgicaltable.Rows[i][1].ToString();
                    bunifuTextBoxSergerySearch.AutoCompleteCustomSource.Add(strSurgeryDetailName);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }

        private void bunifuDataGridViewSurgery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int SurgeryId = Convert.ToInt32(bunifuDataGridViewSurgery.SelectedRows[0].Cells[0].Value);
            DataTable staffSurgeryTable = SurgicalDetail.GetListSurgicalDetail(SurgeryId);

            staffSurgeryTable.Columns.Add("Mã ca ", typeof(int), "[SURGICALID]");
            staffSurgeryTable.Columns.Add("Mã nhân viên", typeof(int), "[STAFFID]");
            staffSurgeryTable.Columns.Add("Họ", typeof(string), "[LASTNAME]");
            staffSurgeryTable.Columns.Add("Tên", typeof(string), "[FIRSTNAME]");

            bunifuDataGridViewSurgeryStaff.DataSource = staffSurgeryTable;

            for (int i = 0; i < 4; i++)
            {
                bunifuDataGridViewSurgeryStaff.Columns[i].Visible = false;
            }
        }
        //Search in datagridview
        private void searchSurgeryDetail()
        {
            // Not search it search string is empty
            if (bunifuTextBoxSergerySearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewSurgery.DataSource).RowFilter = "[Mã bệnh] LIKE '*" + bunifuTextBoxSergerySearch.Text.Trim() + "*'"
                                                                + "OR [Tên bệnh] LIKE '*" + bunifuTextBoxSergerySearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewSurgery.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxSurgeryDetailSearch_TextChange(object sender, EventArgs e)
        {
            searchSurgeryDetail();
        }

        private void bunifuTextBoxSurgeryDetailSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchSurgeryDetail();
            }
        }

        private void bunifubuttonSurgeryDetailDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxSergerySearch.Text = "";
            searchSurgeryDetail();
        }

        private void bunifuButtonSurgeryDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewSurgery.SelectedRows.Count > 0)
            {
                int SurgeryID = Convert.ToInt32(bunifuDataGridViewSurgery.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa ca phẫu thuật", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Surgical.DeleteSurgical(SurgeryID) > 0)
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa ca phẫu thuật thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Ca phẫu thuật đang diễn ra", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }

                refreshDataViewSurgeryDetail();
            }
        }

        //private void bunifuDataGridViewSurgeryDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (bunifuDataGridViewSurgeryDetail.SelectedRows.Count > 0)
        //    {
        //        int diseaseID = Convert.ToInt16(bunifuDataGridViewSurgeryDetail.SelectedRows[0].Cells[0].Value);
        //        FormSurgeryDetailDetail formSurgeryDetailDetail = new FormSurgeryDetailDetail(SurgeryDetail.GetSurgeryDetail(diseaseID), "edit");
        //        formSurgeryDetailDetail.ShowDialog();

        //        refreshDataViewSurgeryDetail();
        //    }
        //}

        private void bunifuButtonSurgeryEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewSurgery.SelectedRows.Count > 0)
            {
                int surgeryID = Convert.ToInt32(bunifuDataGridViewSurgery.SelectedRows[0].Cells[0].Value);
                FormSurgicalDetail formSurgicalDetail = new FormSurgicalDetail(Surgical.GetSurgical(surgeryID), "edit");
                formSurgicalDetail.ShowDialog();

                refreshDataViewSurgeryDetail();
            }
        }

        private void bunifuButtonSurgeryAdd_Click(object sender, EventArgs e)
        {
            int patientID = Convert.ToInt32(bunifuDataGridViewSurgery.SelectedRows[0].Cells[1].Value);
            FormSurgicalDetail formSurgeryDetailDetail = new FormSurgicalDetail(patientID);
            formSurgeryDetailDetail.ShowDialog();

            refreshDataViewSurgeryDetail();
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuToolTip1_Popup(object sender, Bunifu.UI.WinForms.BunifuToolTip.PopupEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

