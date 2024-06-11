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
    public partial class FormMainPrescription : UserControl
    {
        Staff loginStaff = new Staff();
        public FormMainPrescription()
        {
            InitializeComponent();
            refreshDataViewPrescription();
        }
        public FormMainPrescription(Staff LoginStaff)
        {
            InitializeComponent();
            this.loginStaff = LoginStaff;

        }
        public void tabItemPrescpition_Click()
        {
            refreshDataViewPrescription();
            refreshDataViewPrescriptionDetail();
        }

        private void bunifuDataGridViewPrescription_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewPrescription.SelectedRows.Count > 0)
            {
                // Get PrescriptionDetail's datatable
                int prescriptionID = Convert.ToInt32(bunifuDataGridViewPrescription.SelectedRows[0].Cells[0].Value);
                DataTable prescriptionDetailTable = PrescriptionDetail.GetListPrescriptionDetail(prescriptionID);

                prescriptionDetailTable.Columns.Add("Mã toa thuốc", typeof(string), "[PRESCRIPTIONID]");
                prescriptionDetailTable.Columns.Add("Mã thuốc", typeof(string), "[MEDICINEID]");
                //prescriptionTable.Columns.Add("Tên nhân viên", typeof(string), "[STAFF NAME]");
                prescriptionDetailTable.Columns.Add("Sốb lượng", typeof(string), "[QUANTITY]");

                //prescriptionTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                prescriptionDetailTable.Columns.Add("Hướng dẫn sử dụng", typeof(string), "[INSTRUCTION]");
                // Set data source to dataview for searching


                bunifuDataGridViewPrescriptionDetail.DataSource = prescriptionDetailTable;
                // Hide English columns'name
                for (int i = 0; i < 4; i++)
                {
                    bunifuDataGridViewPrescriptionDetail.Columns[i].Visible = false;
                }

                // Set data source to dataview for searching
                
            }
        }

        private void bunifuTextBoxPrescriptionSearch_TextChange_1(object sender, EventArgs e)
        {
            searchPrescription();
        }

        private void bunifuTextBoxPrescriptionSearch_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchPrescription();
            }
        }

        private void bunifubuttonMaterialDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxPrescriptionSearch.Text = "";
            searchPrescription();
        }

        private void bunifuDataGridViewPrescription_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewPrescription.SelectedRows.Count > 0)
            {
                int prescriptionID = Convert.ToInt32(bunifuDataGridViewPrescription.SelectedRows[0].Cells[0].Value);
                FormPrescriptionDetail formPD = new FormPrescriptionDetail(Prescription.GetPrescription(prescriptionID), "edit");
                formPD.ShowDialog();

                refreshDataViewPrescription();
                refreshDataViewPrescriptionDetail();
            }
        }

        private void bunifuButtonPrescriptionEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPrescription.SelectedRows.Count > 0)
            {
                int prescriptionID = Convert.ToInt32(bunifuDataGridViewPrescription.SelectedRows[0].Cells[0].Value);
                FormPrescriptionDetail formPD = new FormPrescriptionDetail(Prescription.GetPrescription(prescriptionID), "edit");
                formPD.ShowDialog();

                refreshDataViewPrescription();
                refreshDataViewPrescriptionDetail();
            }
        }

        private void bunifuButtonPrescriptionDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPrescription.SelectedRows.Count > 0)
            {
                int prescriptionID = Convert.ToInt32(bunifuDataGridViewPrescription.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa toa thuốc", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (PrescriptionDetail.DeletePrescriptionDetail(prescriptionID) > 0 && Prescription.DeletePrescription(prescriptionID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa toa thuốc thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }

                    }
                    catch
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }
                }

                refreshDataViewPrescription();
                refreshDataViewPrescriptionDetail();
            }
        }
        //Refresh datagridview in prescription tab
        private void refreshDataViewPrescription()
        {
            try
            {
                // Get prescription's datatable
                DataTable prescriptionTable = Prescription.GetListPrescription();

                // Add Vietnamese column's name
                prescriptionTable.Columns.Add("Mã toa thuốc", typeof(string), "[PRESCRIPTIONID]");
                prescriptionTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                //prescriptionTable.Columns.Add("Tên nhân viên", typeof(string), "[STAFF NAME]");
                prescriptionTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");

                //prescriptionTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                prescriptionTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                // Set data source to dataview for searching
                bunifuDataGridViewPrescription.DataSource = prescriptionTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 4; i++)
                {
                    bunifuDataGridViewPrescription.Columns[i].Visible = false;
                }
            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }
        private void refreshDataViewPrescriptionDetail()
        {
            if (bunifuDataGridViewPrescription.SelectedRows.Count > 0)
            {
                try
                {
                    // Get PrescriptionDetail's datatable
                    int prescriptionID = Convert.ToInt32(bunifuDataGridViewPrescription.Rows[0].Cells[0].Value);
                    DataTable prescriptionDetailTable = PrescriptionDetail.GetListPrescriptionDetail(prescriptionID);

                    // Set data source to dataview for searching
                    bunifuDataGridViewPrescriptionDetail.DataSource = prescriptionDetailTable.DefaultView;
                }
                catch
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
            }
        }
        private void searchPrescription()
        {
            // Not search it search string is empty
            if (bunifuTextBoxPrescriptionSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewPrescription.DataSource).RowFilter = "[Mã toa thuốc] LIKE '*" + bunifuTextBoxPrescriptionSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxPrescriptionSearch.Text.Trim() + "*'"
                                                                + "OR [Mã nhân viên] LIKE '*" + bunifuTextBoxPrescriptionSearch.Text.Trim() + "*'";
                refreshDataViewPrescriptionDetail();
            }
            else
            {
                ((DataView)bunifuDataGridViewPrescription.DataSource).RowFilter = "";
            }
        }

        private void bunifuButtonPrescriptionSell_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPrescription.SelectedRows.Count > 0)
            {
                int prescriptionID = Convert.ToInt32(bunifuDataGridViewPrescription.SelectedRows[0].Cells[0].Value);
                int patientID = Convert.ToInt32(Prescription.GetPatientIDInPrescription(prescriptionID).Rows[0][0]);
                int staffID = Convert.ToInt32(bunifuDataGridViewPrescription.SelectedRows[0].Cells[1].Value);

                Bill newBill = new Bill(Bill.MEDICINEBILL, patientID, staffID);
                FormBillDetail billDetailForm = new FormBillDetail("insert", newBill, prescriptionID);
                billDetailForm.ShowDialog();
            }
        }

        private void FormMainPrescription_Load(object sender, EventArgs e)
        {

        }

        private void prescriptionTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void FormMainPrescription_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
