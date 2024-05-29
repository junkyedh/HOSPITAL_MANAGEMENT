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
    public partial class FormMainDischarged : UserControl
    {
        public FormMainDischarged()
        {
            InitializeComponent();
        }
        public void tabItemDischarged_Click()
        {
            refreshDataViewDC();
        }
        //Refresh datagridview in Discharge tab
        private void refreshDataViewDC()
        {
            try
            {
                // Get Discharge's datatable
                DataTable dcTable = DischargeCertificate.GetListDC();

                // Add Vietnamese column's name
                dcTable.Columns.Add("Mã giấy xuất viện", typeof(string), "[DCID]");
                dcTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                dcTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                dcTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                dcTable.Columns.Add("Tên nhân viên", typeof(string), "[STAFF NAME]");
                dcTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                dcTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Chưa xác nhận', 'Đã xác nhận')");
                // Set data source to dataview for searching
                bunifuDataGridViewDC.DataSource = dcTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 7; i++)
                {
                    bunifuDataGridViewDC.Columns[i].Visible = false;
                }

            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);


            }
        }
        //Search in datagridview
        private void searchDC()
        {
            // Not search it search string is empty
            if (bunifuTextBoxDCSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewDC.DataSource).RowFilter = "[Mã giấy xuất viện] LIKE '*" + bunifuTextBoxDCSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxDCSearch.Text.Trim() + "*'"
                                                                + "OR [Mã nhân viên] LIKE '*" + bunifuTextBoxDCSearch.Text.Trim() + "*'"
                                                                + "OR [Trạng thái] LIKE '*" + bunifuTextBoxDCSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewDC.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxDCSearch_TextChange(object sender, EventArgs e)
        {
            searchDC();
        }

        private void bunifuTextBoxDCSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchDC();
            }
        }

        private void bunifubuttonDCDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxDCSearch.Text = "";
            searchDC();
        }

        private void bunifuButtonDCConfirm_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDC.SelectedRows.Count > 0)
            {
                int dcID = Convert.ToInt32(bunifuDataGridViewDC.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewDC.SelectedRows[0].Cells[4].Value);

                if (state != 1)
                {
                    DischargeCertificateDTO confirmDC = DischargeCertificate.GetDC(dcID);
                    if (HospitalBed.ConfirmPatient(confirmDC.PatientID))
                    {
                        if (Bill.ConfirmPatient(confirmDC.PatientID))
                        {
                            DialogResult dialogResult = MessageBox.Show("Xác nhận giấy xuất viện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                PatientDTO updatePatient = Patient.GetPatient(confirmDC.PatientID);
                                updatePatient.State = 0;
                                confirmDC.State = 1;
                                if (DischargeCertificate.UpdateDC(confirmDC) > 0 && Patient.UpdatePatient(updatePatient) > 0)
                                {
                                    bunifuSnackbar1.Show(Form.ActiveForm, "Xác nhận giấy xuất viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                }
                            }
                        }
                        else
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Bệnh nhân chưa thanh toán hóa đơn", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }
                    else
                    {
                        bunifuSnackbar1.Show(Form.ActiveForm, "Bệnh nhân chưa trả giường", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }

                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Giấy xuất viện đã được xác nhận", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
                refreshDataViewDC();
            }
        }

        private void bunifuButtonDCDelete_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridViewDC.SelectedRows.Count > 0)
            {
                int dcID = Convert.ToInt32(bunifuDataGridViewDC.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewDC.SelectedRows[0].Cells[4].Value);

                if (state != 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận xóa giấy xuất viện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (DischargeCertificate.DeleteDC(dcID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa giấy xuất viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }

                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Không thể xóa giấy xuất viện đã được xác nhận", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
                refreshDataViewDC();
            }
        }

        private void bunifuButtonDCEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDC.SelectedRows.Count > 0)
            {
                int dcID = Convert.ToInt32(bunifuDataGridViewDC.SelectedRows[0].Cells[0].Value);
                DischargeCertificateDTO updateDC = DischargeCertificate.GetDC(dcID);
                FormDCDetail formDCD = new FormDCDetail(updateDC, "edit");
                formDCD.ShowDialog();

                refreshDataViewDC();
            }
        }

        private void bunifuDataGridViewDC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewDC.SelectedRows.Count > 0)
            {
                int dcID = Convert.ToInt32(bunifuDataGridViewDC.SelectedRows[0].Cells[0].Value);
                DischargeCertificateDTO updateDC = DischargeCertificate.GetDC(dcID);
                FormDCDetail formDCD = new FormDCDetail(updateDC, "edit");
                formDCD.ShowDialog();

                refreshDataViewDC();
            }
        }
    }
}
