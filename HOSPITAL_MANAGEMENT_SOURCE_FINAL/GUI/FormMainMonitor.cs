using HOSPITAL_MANAGEMENT_SOURCE.GUI;
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

namespace hospital_management_source.gui
{
    public partial class Formmainmonitor : UserControl
    {

        public Formmainmonitor()
        {
            InitializeComponent();
            refreshDataViewHeathNote();
        }
        public void tabItemMonitor_Click()
        {
            refreshDataViewHeathNote();
        }
        //Refresh datagridview in monitor tab
        private void refreshDataViewHeathNote()
        {
            try
            {
                // Get heath note's datatable
                DataTable heathNoteTable = HealthMonitoringNote.GetListHN();

                // Add Vietnamese column's name
                heathNoteTable.Columns.Add("Mã phiếu theo dõi", typeof(string), "[HNID]");
                heathNoteTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                //heathNoteTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                heathNoteTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                //heathNoteTable.Columns.Add("Tên nhân viên", typeof(string), "[STAFF NAME]");
                heathNoteTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                heathNoteTable.Columns.Add("Cân nặng", typeof(string), "[WEIGHT]");
                heathNoteTable.Columns.Add("Huyết áp", typeof(string), "[BLOODPRESSURE]");
                heathNoteTable.Columns.Add("Tình trạng bệnh nhân", typeof(string), "[PATIENTSTATE]");
                // Set data source to dataview for searching
                bunifuDataGridViewHealthNote.DataSource = heathNoteTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 9; i++)
                {
                    bunifuDataGridViewHealthNote.Columns[i].Visible = false;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        //Search in datagridview
        private void searchHeathNote()
        {
            // Not search it search string is empty
            if (bunifuTextBoxHealthNoteSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewHealthNote.DataSource).RowFilter = "[Mã bệnh nhân] LIKE '*" + bunifuTextBoxHealthNoteSearch.Text.Trim() + "*'"
                                                                + "OR [Mã phiếu theo dõi] LIKE '*" + bunifuTextBoxHealthNoteSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewHealthNote.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxHealthNoteSearch_TextChange(object sender, EventArgs e)
        {
            searchHeathNote();
        }

        private void bunifuTextBoxHealthNoteSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchHeathNote();
            }
        }

        private void bunifubuttonHealthNoteDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxHealthNoteSearch.Text = "";
            searchHeathNote();
        }

        private void bunifuButtonHealthNoteDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHealthNote.SelectedRows.Count > 0)
            {
                int heathNoteID = Convert.ToInt32(bunifuDataGridViewHealthNote.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phiếu theo dõi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (HealthMonitoringNote.DeleteHN(heathNoteID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa phiếu theo dõi thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Không xóa phiếu theo dõi này", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);


                    }
                }

                refreshDataViewHeathNote();
            }
        }

        private void bunifuButtonHealthNoteEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHealthNote.SelectedRows.Count > 0)
            {
                int heathNoteID = Convert.ToInt32(bunifuDataGridViewHealthNote.SelectedRows[0].Cells[0].Value);
                FormHNDetail formHNDetail = new FormHNDetail(HealthMonitoringNote.GetHN(heathNoteID), "edit");
                formHNDetail.ShowDialog();

                refreshDataViewHeathNote();
            }
        }

        private void bunifuDataGridViewHN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewHealthNote.SelectedRows.Count > 0)
            {
                int heathNoteID = Convert.ToInt32(bunifuDataGridViewHealthNote.SelectedRows[0].Cells[0].Value);
                FormHNDetail formHNDetail = new FormHNDetail(HealthMonitoringNote.GetHN(heathNoteID), "edit");
                formHNDetail.ShowDialog();

                refreshDataViewHeathNote();
            }
        }

        private void FormMainMonitor_Load(object sender, EventArgs e)
        {

        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HOSPITAL_MANAGEMENT_SOURCE.DAL;
//using System.Windows.Forms;

//namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
//{
//    public partial class FormMainMonitor : UserControl
//    {
//        public FormMainMonitor()
//        {
//            InitializeComponent();
//            refreshDataViewMonitor();
//        }
//        public void tabItemMonitor_Click()
//        {
//            refreshDataViewMonitor();
//        }
//        private void refreshDataViewMonitor()
//        {
//            try
//            {
//                // Get Monitor's datatable
//                DataTable monitorTable = Monitor.GetListMonitor();

//                // Add Vietnamese column's name
//                monitorTable.Columns.Add("Mã bệnh", typeof(string), "[monitorID]");
//                monitorTable.Columns.Add("Tên bệnh", typeof(string), "[monitorNAME]");
//                monitorTable.Columns.Add("Triệu chứng", typeof(string), "[SYMPTOM]");
//                // Set data source to dataview for searching
//                bunifuDataGridViewMonitor.DataSource = MonitorTable;

//                // Hide English columns'name
//                for (int i = 0; i < 3; i++)
//                {
//                    bunifuDataGridViewMonitor.Columns[i].Visible = false;
//                }

//                //Add auto complete datasource to textbox
//                bunifuTextBoxMonitorSearch.AutoCompleteCustomSource.Clear();
//                for (int i = 0; i < monitorTable.Rows.Count; i++)
//                {
//                    String strMonitorName = monitorTable.Rows[i][1].ToString();
//                    bunifuTextBoxMonitorSearch.AutoCompleteCustomSource.Add(strMonitorName);
//                }
//            }
//            catch
//            {
//                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

//            }
//        }
//        //Search in datagridview
//        private void searchMonitor()
//        {
//            // Not search it search string is empty
//            if (bunifuTextBoxMonitorSearch.Text != "")
//            {
//                // Search with RowFilter
//                ((DataView)bunifuDataGridViewMonitor.DataSource).RowFilter = "[Mã bệnh] LIKE '*" + bunifuTextBoxMonitorSearch.Text.Trim() + "*'"
//                                                                + "OR [Tên bệnh] LIKE '*" + bunifuTextBoxMonitorSearch.Text.Trim() + "*'";
//            }
//            else
//            {
//                ((DataView)bunifuDataGridViewMonitor.DataSource).RowFilter = "";
//            }
//        }

//        private void bunifuTextBoxMonitorSearch_TextChange(object sender, EventArgs e)
//        {
//            searchMonitor();
//        }

//        private void bunifuTextBoxMonitorSearch_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                searchMonitor();
//            }
//        }

//        private void bunifubuttonMonitorDeleteSearch_Click(object sender, EventArgs e)
//        {
//            bunifuTextBoxMonitorSearch.Text = "";
//            searchMonitor();
//        }

//        private void bunifuButtonMonitorDelete_Click(object sender, EventArgs e)
//        {
//            if (bunifuDataGridViewMonitor.SelectedRows.Count > 0)
//            {
//                int MonitorID = Convert.ToInt16(bunifuDataGridViewMonitor.SelectedRows[0].Cells[0].Value);
//                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//                if (dialogResult == DialogResult.Yes)
//                {
//                    try
//                    {
//                        if (Monitor.DeleteMonitor(monitorID) > 0)
//                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

//                    }
//                    catch
//                    {
//                        bunifuSnackbar1.Show(Form.ActiveForm, "Bệnh đã hoặc đang có người mắc phải", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

//                    }
//                }

//                refreshDataViewMonitor();
//            }
//        }

//        private void bunifuDataGridViewMonitor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (bunifuDataGridViewMonitor.SelectedRows.Count > 0)
//            {
//                int monitorID = Convert.ToInt16(bunifuDataGridViewMonitor.SelectedRows[0].Cells[0].Value);
//                FormMonitorDetail formMonitorDetail = new FormMonitorDetail(Monitor.GetMonitor(monitorID), "edit");
//                formMonitorDetail.ShowDialog();

//                refreshDataViewMonitor();
//            }
//        }

//        private void bunifuButtonMonitorEdit_Click(object sender, EventArgs e)
//        {
//            if (bunifuDataGridViewMonitor.SelectedRows.Count > 0)
//            {
//                int MonitorID = Convert.ToInt16(bunifuDataGridViewMonitor.SelectedRows[0].Cells[0].Value);
//                FormMonitorDetail formMonitorDetail = new FormMonitorDetail(Monitor.GetMonitor(monitorID), "edit");
//                formMonitorDetail.ShowDialog();

//                refreshDataViewMonitor();
//            }
//        }

//        private void bunifuButtonMonitorAdd_Click(object sender, EventArgs e)
//        {
//            FormMonitorDetail formMonitorDetail = new FormMonitorDetail();
//            formMonitorDetail.ShowDialog();

//            refreshDataViewMonitor();
//        }
//    }
//}

