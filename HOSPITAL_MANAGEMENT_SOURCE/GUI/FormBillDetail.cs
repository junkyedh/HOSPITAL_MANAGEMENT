using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using System.Globalization;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormBillDetail : Form
    {
        public Bill BillDetail { get; set; }       // O day sua thanh  
        public Staff StaffDetail { get; set; }
        public Patient PatientDetail { get; set; }
        public string UserAction { get; set; }
        public int PrescriptionID { get; set; }
        public int HICID { get; set; }

        private DataTable BillMedicineTable { get; set; }
        private DataTable BillServiceTable { get; set; }
        private DataTable BillMaterialTable { get; set; }
        public FormBillDetail()
        {
            InitializeComponent();
        }

        public FormBillDetail(string userAction, Bill bill)
        {
            InitializeComponent();

            // Set useraction and bill            
            this.BillDetail = bill;
            this.UserAction = userAction;
            this.StaffDetail = Staff.GetStaff(BillDetail.StaffID);
            this.PatientDetail = Patient.GetPatient(BillDetail.PatientID);

            //reFreshForm();
        }

        private void bunifuButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDataGridViewBillDetail.Rows.Count <= 0)
                {
                    bunifuSnackbar1.Show(this, "Thiếu thông tin hoá đơn", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error,
                        1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    return;
                }

                if (MessageBox.Show("Lưu hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                            == DialogResult.Yes)
                {
                    Bill.InsertBill(BillDetail);
                    //insertBillDetail();
                    this.Close();
                }
            }
            catch (SqlException exception)
            {
                bunifuSnackbar1.Show(this, exception.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                    1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
        }

        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTextBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void insertBillDetail()
        {
            switch (BillDetail.BillTypeID)
            {
                case Bill.MEDICINEBILL:

                    MedicineBillDetail newMedicineBillDetail = new MedicineBillDetail();

                    foreach (DataRow record in ((DataTable)bunifuDataGridViewBillDetail.DataSource).Rows)
                    {
                        newMedicineBillDetail.BillID = BillDetail.BillID;
                        newMedicineBillDetail.MedicineID = Convert.ToInt32(record["MEDICINEID"]);
                        newMedicineBillDetail.Quantity = Convert.ToInt32(record["Số lượng"]);
                        newMedicineBillDetail.Price = Convert.ToDecimal(record["Giá"]);

                        MedicineBillDetail.InsertMedicineBillDetail(newMedicineBillDetail);
                    }
                    break;

                case Bill.SERVICEBILL:

                    ServiceBillDetail newServiceBillDetail = new ServiceBillDetail();

                    foreach (DataRow record in ((DataTable)bunifuDataGridViewBillDetail.DataSource).Rows)
                    {
                        newServiceBillDetail.BillID = BillDetail.BillID;
                        newServiceBillDetail.ServiceID = Convert.ToInt32(record["SERVICEID"]);
                        newServiceBillDetail.Quantity = Convert.ToInt32(record["Số lượng"]);
                        newServiceBillDetail.Price = Convert.ToDecimal(record["Giá"]);

                        ServiceBillDetail.InsertServiceBillDetail(newServiceBillDetail);
                    }
                    break;
                case Bill.MATERIALBILL:

                    RentMaterialBillDetail newRentMaterialBillDetail = new RentMaterialBillDetail();

                    foreach (DataRow record in ((DataTable)bunifuDataGridViewBillDetail.DataSource).Rows)
                    {
                        newRentMaterialBillDetail.BillID = BillDetail.BillID;
                        newRentMaterialBillDetail.MaterialID = Convert.ToInt32(record["MATERIALID"]);
                        newRentMaterialBillDetail.Quantity = Convert.ToInt32(record["Số lượng"]);
                        newRentMaterialBillDetail.Price = Convert.ToDecimal(record["Giá"]);

                        RentMaterialBillDetail.InsertRentMaterialBillDetail(newRentMaterialBillDetail);
                    }
                    break;
            }
        }

        private void bunifuButtonPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDataGridViewBillDetail.Rows.Count <= 0)
                {
                    bunifuSnackbar1.Show(this, "Thêm chi tiết hóa đơn", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                        1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }

                // Ask user to accpet payment
                if (MessageBox.Show("Xác nhận thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                            == DialogResult.Yes)
                {


                    if ("insert".Equals(UserAction))
                    {
                        if (HICID != 0)
                        {
                            BillDetail.TotalPrice = BillDetail.TotalPrice / 4;
                        }
                        BillDetail.State = Bill.PAY;
                        Bill.InsertBill(BillDetail);

                        //insertBillDetail();
                    }
                    else if ("edit".Equals(UserAction))
                    {
                        if (HICID != 0)
                        {
                            BillDetail.TotalPrice = BillDetail.TotalPrice / 4;
                        }
                        BillDetail.State = Bill.PAY;
                        Bill.UpdateBill(BillDetail);
                    }

                    Bill billReport;

                    if ("insert".Equals(UserAction))
                    {
                        billReport = Bill.GetBill(Bill.GetCurrentBillID());
                    }
                    else
                    {
                        billReport = BillDetail;
                    }

                    //FormReport reportForm = new FormReport();

                    /*switch (billReport.BillTypeID)
                    {
                        case Bill.MEDICINEBILL:
                            reportForm.ReportType = "MEDICINEBILL";
                            reportForm.ObjectID = billReport.BillID;
                            break;
                        case Bill.SERVICEBILL:
                            reportForm.ReportType = "SERVICEBILL";
                            reportForm.ObjectID = billReport.BillID;
                            break;
                        case Bill.MATERIALBILL:
                            reportForm.ReportType = "MATERIALBILL";
                            reportForm.ObjectID = billReport.BillID;
                            break;
                        default:
                            MessageBox.Show("Vui lòng chọn hóa đơn để in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    reportForm.Show();
*/
                    this.Close();
                }
            }
            catch (SqlException exception)
            {
                bunifuSnackbar1.Show(this, exception.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning,
                    1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        private void bunifuButtonAdd_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButtonDelete_Click(object sender, EventArgs e)
        {
            decimal totalPrice = new Decimal();

            if (bunifuDataGridViewBillDetail.SelectedRows.Count > 0)
            {
                bunifuDataGridViewBillDetail.Rows.Remove(bunifuDataGridViewBillDetail.SelectedRows[0]);

                switch (BillDetail.BillTypeID)
                {
                    case Bill.MEDICINEBILL:
                        foreach (DataRow row in BillMedicineTable.Rows)
                        {
                            totalPrice += (decimal)row["Giá"];
                        }
                        break;
                    case Bill.SERVICEBILL:
                        foreach (DataRow row in BillServiceTable.Rows)
                        {
                            totalPrice += (decimal)row["Giá"];
                        }
                        break;
                    case Bill.MATERIALBILL:
                        foreach (DataRow row in BillMaterialTable.Rows)
                        {
                            totalPrice += (decimal)row["Giá"];
                        }
                        break;
                }
                if (HICID != 0)
                {
                    totalPrice = totalPrice / 4;
                }
                bunifuLabelTotalBillPrice.Text = totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));
            }
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabelBillState_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuTextBoxBillID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
