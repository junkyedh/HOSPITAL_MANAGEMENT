﻿using System;
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
    public partial class FormMainHospitalization : UserControl
    {
        public FormMainHospitalization()
        {
            InitializeComponent();
        }
        public void tabItemHospitalization_Click()
        {
            refreshDataViewHC();
        }
        private void refreshDataViewHC()
        {
            try
            {
                // Get Hospitalization's datatable
                DataTable hcTable = HospitalizationCertificate.GetListHC();

                // Add Vietnamese column's name
                hcTable.Columns.Add("Mã giấy nhập viện", typeof(string), "[HCID]");
                hcTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                hcTable.Columns.Add("Tên bệnh nhân", typeof(string), "[PATIENT NAME]");
                hcTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                hcTable.Columns.Add("Tên nhân viên", typeof(string), "[STAFF NAME]");
                hcTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                hcTable.Columns.Add("Lý do", typeof(string), "[REASON]");
                hcTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Chưa xác nhận', 'Đã xác nhận')");
                // Set data source to dataview for searching
                bunifuDataGridViewHC.DataSource = hcTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 8; i++)
                {
                    bunifuDataGridViewHC.Columns[i].Visible = false;
                }

            }
            catch
            {
                bunifuSnackbar1.Show(Form.ActiveForm, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }

        private void bunifubunifuTextBoxHCSearch_TextChange(object sender, EventArgs e)
        {
            searchHC();
        }
        private void searchHC()
        {
            // Not search it search string is empty
            if (bunifuTextBoxHCSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewHC.DataSource).RowFilter = "[Mã giấy nhập viện] LIKE '*" + bunifuTextBoxHCSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxHCSearch.Text.Trim() + "*'"
                                                                + "OR [Mã nhân viên] LIKE '*" + bunifuTextBoxHCSearch.Text.Trim() + "*'"
                                                                + "OR [Trạng thái] LIKE '*" + bunifuTextBoxHCSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewHC.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxHCSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchHC();
            }
        }

        private void bunifubuttonHCDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxHCSearch.Text = "";
            searchHC();
        }

        private void bunifuButtonHCConfirm_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHC.SelectedRows.Count > 0)
            {
                int hcID = Convert.ToInt32(bunifuDataGridViewHC.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewHC.SelectedRows[0].Cells[5].Value);

                if (state != 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận giấy nhận viện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        HospitalizationCertificateDTO confirmHC = HospitalizationCertificate.GetHC(hcID);
                        PatientDTO updatePatient = Patient.GetPatient(confirmHC.PatientID);
                        updatePatient.State = 1;
                        confirmHC.State = 1;
                        if (HospitalizationCertificate.UpdateHC(confirmHC) > 0 && Patient.UpdatePatient(updatePatient) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xác nhận giấy nhập viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }

                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Giấy nhập viện đã được xác nhận", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
                refreshDataViewHC();
            }
        }

        private void bunifuButtonHCDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHC.SelectedRows.Count > 0)
            {
                int hcID = Convert.ToInt32(bunifuDataGridViewHC.SelectedRows[0].Cells[0].Value);
                int state = Convert.ToInt16(bunifuDataGridViewHC.SelectedRows[0].Cells[5].Value);

                if (state != 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận xóa giấy nhập viện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (HospitalizationCertificate.DeleteHC(hcID) > 0)
                        {
                            bunifuSnackbar1.Show(Form.ActiveForm, "Xóa giấy nhập viện thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                        }
                    }

                }
                else
                {
                    bunifuSnackbar1.Show(Form.ActiveForm, "Không thể xóa giấy nhập viện đã được xác nhận", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
                refreshDataViewHC();
            }
        }

        private void bunifuDataGridViewHC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewHC.SelectedRows.Count > 0)
            {
                int hcID = Convert.ToInt32(bunifuDataGridViewHC.SelectedRows[0].Cells[0].Value);
                HospitalizationCertificateDTO updateHC = HospitalizationCertificate.GetHC(hcID);
                FormHCDetail formHCD = new FormHCDetail(updateHC, "edit");
                formHCD.ShowDialog();

                refreshDataViewHC();
            }
        }

        private void bunifuButtonHCEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHC.SelectedRows.Count > 0)
            {
                int hcID = Convert.ToInt32(bunifuDataGridViewHC.SelectedRows[0].Cells[0].Value);
                HospitalizationCertificateDTO updateHC = HospitalizationCertificate.GetHC(hcID);
                FormHCDetail formHCD = new FormHCDetail(updateHC, "edit");
                formHCD.ShowDialog();

                refreshDataViewHC();
            }
        }
    }
}
