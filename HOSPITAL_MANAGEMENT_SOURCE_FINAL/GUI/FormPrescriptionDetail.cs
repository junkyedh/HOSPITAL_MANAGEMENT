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
    public partial class FormPrescriptionDetail : Form
    {
        public Prescription PDetail { get; set; }
        public String UserAction { get; set; }
        private static List<Medicine> listMedicine = new List<Medicine>();
        private static List<PrescriptionDetail> listDP = new List<PrescriptionDetail>();
        public FormPrescriptionDetail()
        {
            InitializeComponent();
        }
        public FormPrescriptionDetail(Prescription pDetail)
        {
            InitializeComponent();
            this.PDetail = pDetail;
        }
        public FormPrescriptionDetail(int staffID, int patientID)
        {
            InitializeComponent();
            SetPDetailForInsert(staffID, patientID);
        }
        public FormPrescriptionDetail(Prescription pDetail, String userAction)
        {
            InitializeComponent();
            this.PDetail = pDetail;
            this.UserAction = userAction;
            SetPDetailForUpdate(pDetail);
        }
        private void SetPDetailForInsert(int staffID, int patientID)
        {
            textBoxPrescriptionID.Text = patientID.ToString();
            textBoxStaffID.Text = staffID.ToString();
            dateCreate.Value = DateTime.Today;
            dateCreate.Enabled = false;

            DataTable dtMedicine = Medicine.GetListMedicine();
            //for (int i = 0; i < dtMedicine.Rows.Count; i++)
            //{
            //    Medicine newMedicine = Medicine.GetMedicine(Convert.ToInt32(dtMedicine.Rows[i][0]));
            //    listMedicine.Add(newMedicine);
            //    comboBoxMedicine.Items.Add(newMedicine.MedicineName);
            //    comboBoxMedicine.AutoCompleteCustomSource.Add(newMedicine.MedicineName);
            //}
            //comboBoxMedicine.SelectedIndex = 0;
        }
        private void SetPDetailForUpdate(Prescription pDetail)
        {
            textBoxPrescriptionID.Text = pDetail.PrescriptionID.ToString();
            textBoxPrescriptionID.Text = pDetail.PatientID.ToString();
            textBoxStaffID.Text = pDetail.StaffID.ToString();
            dateCreate.Value = pDetail.Date;

            DataTable dtMedicine = Medicine.GetListMedicine();
            for (int i = 0; i < dtMedicine.Rows.Count; i++)
            {
                Medicine newMedicine = Medicine.GetMedicine(Convert.ToInt32(dtMedicine.Rows[i][0]));
                listMedicine.Add(newMedicine);
                //comboBoxMedicine.Items.Add(newMedicine.MedicineName);
                //comboBoxMedicine.AutoCompleteCustomSource.Add(newMedicine.MedicineName);
            }
            //comboBoxMedicine.SelectedIndex = 0;

            DataTable dtPD = PrescriptionDetail.GetListPrescriptionDetail(pDetail.PrescriptionID);
            for (int i = 0; i < dtPD.Rows.Count; i++)
            {
                PrescriptionDetail newDP = new PrescriptionDetail();
                newDP.PrescriptionID = Convert.ToInt32(dtPD.Rows[i][0]);
                newDP.MedicineID = Convert.ToInt32(dtPD.Rows[i][1]);
                newDP.Quantity = Convert.ToInt16(dtPD.Rows[i][2]);
                newDP.Instruction = dtPD.Rows[i][3].ToString();
                listDP.Add(newDP);
                Medicine newMedicine = Medicine.GetMedicine(newDP.MedicineID);
                //listSelectedMedicine.Items.Add(newMedicine.MedicineName);
            }
            //if (listSelectedMedicine.Items.Count > 0)
            //    listSelectedMedicine.SelectedIndex = 0;

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInputQuantity.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu số lượng thuốc cần kê", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            if (string.IsNullOrEmpty(textBoxInputInstruction.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu thông tên hướng dẫn", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

            if (listMedicine.Count > 0)
            {

                //int selectedIndex = comboBoxMedicine.SelectedIndex;
                //if (int.Parse(textBoxInputQuantity.Text) > listMedicine[selectedIndex].Quantity)
                //{
                //    bunifuSnackbar1.Show(this, "Số lượng thuốc không đáp ứng đủ nhu cầu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                //    1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                //    return;
                //}
                //else
                //{
                //    PrescriptionDetail newPD = new PrescriptionDetail(listMedicine[selectedIndex].MedicineID, 0,
                //    int.Parse(textBoxInputQuantity.Text), textBoxInputInstruction.Text);
                //    if (DidPrescriptionHaveMedicine(newPD.MedicineID))
                //    {
                //        for (int i = 0; i < listDP.Count; i++)
                //        {
                //            if (newPD.MedicineID == listDP[i].MedicineID)
                //            {
                //                listDP[i].Instruction = textBoxInputInstruction.Text;
                //                listDP[i].Quantity = int.Parse(textBoxInputQuantity.Text);
                //                listSelectedMedicine_SelectedIndexChanged(sender, e);
                //                textBoxInputInstruction.Text = "";
                //                textBoxInputQuantity.Text = "";
                //                break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        listDP.Add(newPD);
                //        listSelectedMedicine.Items.Add(listMedicine[selectedIndex].MedicineName);
                //        listSelectedMedicine.SelectedIndex = listSelectedMedicine.Items.Count - 1;
                //        textBoxInputInstruction.Text = "";
                //        textBoxInputQuantity.Text = "";
                //    }
                //}

            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //if (listSelectedMedicine.SelectedIndex >= 0)
            //{
            //    int selectedIndex = listSelectedMedicine.SelectedIndex;
            //    listSelectedMedicine.Items.RemoveAt(selectedIndex);
            //    listDP.RemoveAt(selectedIndex);
            //    textBoxAddInstruction.Text = "";
            //    textBoxAddQuantity.Text = "";
            //    listSelectedMedicine.SelectedIndex = listSelectedMedicine.Items.Count - 1;
            //}
        }
        private void listSelectedMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listSelectedMedicine.SelectedIndex >= 0)
            //{
            //    int selectedIndex = listSelectedMedicine.SelectedIndex;
            //    textBoxAddInstruction.Text = listDP[selectedIndex].Instruction;
            //    textBoxAddQuantity.Text = listDP[selectedIndex].Quantity.ToString();
            //}
        }
        private Boolean DidPrescriptionHaveMedicine(int medicineID)
        {
            for (int i = 0; i < listDP.Count; i++)
            {
                if (medicineID == listDP[i].MedicineID)
                    return true;
            }
            return false;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

            try
            {
                Prescription newPrescription = new Prescription();
                newPrescription.Date = dateCreate.Value;
                newPrescription.PatientID = int.Parse(textBoxPrescriptionID.Text);
                newPrescription.StaffID = int.Parse(textBoxStaffID.Text);
                if (this.UserAction == "edit")
                {
                    newPrescription.PrescriptionID = Convert.ToInt32(textBoxPrescriptionID.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin toa thuốc", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (Prescription.UpdatePrescription(newPrescription) > 0)
                        {
                            PrescriptionDetail.DeletePrescriptionDetail(newPrescription.PrescriptionID);
                            for (int i = 0; i < listDP.Count; i++)
                            {
                                PrescriptionDetail newPD = listDP[i];
                                newPD.PrescriptionID = Convert.ToInt32(textBoxPrescriptionID.Text);
                                PrescriptionDetail.InsertPrescriptionDetail(newPD);
                            }
                            listDP.Clear();
                            bunifuSnackbar1.Show(this, "Cập nhập thông tin bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }
                    }
                }
                else
                {
                    newPrescription.PrescriptionID = 0;
                    if (Prescription.InsertPrescription(newPrescription) > 0)
                    {
                        int prescriptionID = Prescription.GetPrescriptionInsertedID();
                        for (int i = 0; i < listDP.Count; i++)
                        {
                            listDP[i].PrescriptionID = prescriptionID;
                            PrescriptionDetail.InsertPrescriptionDetail(listDP[i]);
                        }
                        bunifuSnackbar1.Show(this, "Thêm toa thuốc thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        listDP.Clear();
                    }
                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
            this.Close();
        }

        private void comboBoxMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxInputInstruction.Text = "";
            textBoxInputQuantity.Text = "";
        }

        private void textBoxInputQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxAddQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormPrescriptionDetail_Load(object sender, EventArgs e)
        {

        }
        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void dateCreate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
