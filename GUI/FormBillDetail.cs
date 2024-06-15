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
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System.Globalization;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormBillDetail : Form
    {
        public Bill BillDetail { get; set; }
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

            reFreshForm();
        }
        public FormBillDetail(string userAction, Bill bill, int prescriptionID)
        {
            InitializeComponent();

            // Set useraction and bill            
            this.BillDetail = bill;
            this.UserAction = userAction;
            this.StaffDetail = Staff.GetStaff(BillDetail.StaffID);
            this.PatientDetail = Patient.GetPatient(BillDetail.PatientID);
            this.PrescriptionID = prescriptionID;

            reFreshForm();
        }
        private void reFreshForm()
        {
            try
            {
                // Set bill information
                bunifuTextBoxPatientID.Text = PatientDetail.PatientID.ToString();
                bunifuTextBoxPatientName.Text = PatientDetail.LastName + ' ' + PatientDetail.FirstName;
                bunifuTextBoxStaffID.Text = StaffDetail.StaffID.ToString();
                bunifuTextBoxStaffName.Text = StaffDetail.LastName + ' ' + StaffDetail.FirstName;
                if (PatientDetail.State == 0)
                {
                    bunifuButtonSave.Enabled = false;
                }

                //Check HIC
                if (HIC.CheckHIC(BillDetail.PatientID))
                {
                    HIC newHIC = HIC.GetPatientHIC(BillDetail.PatientID);
                    if (HIC.CheckHICExpiration(newHIC.HICID))
                    {
                        bunifuLabelHICD.Text = "Đã hết hạn";
                        this.HICID = 0;
                    }
                    else
                    {
                        bunifuLabelHICD.Text = "Còn hạn sử dụng";
                        this.HICID = newHIC.HICID;
                    }
                }
                else
                {
                    bunifuLabelHICD.Text = "Không có";
                    this.HICID = 0;
                }

                // Set comboBoxDetail corresponding to bill's type
                switch (BillDetail.BillTypeID)
                {
                    case Bill.MEDICINEBILL:
                        bunifuLabelDetail.Text = "Tên thuốc:";

                        // Get Medicine list and set it to comboBox
                        bunifuDropdownDetail.DataSource = Medicine.GetListMedicine();
                        bunifuDropdownDetail.ValueMember = "PRICE";
                        bunifuDropdownDetail.DisplayMember = "MEDICINENAME";
                        break;
                    case Bill.SERVICEBILL:
                        bunifuLabelDetail.Text = "Dịch vụ:";

                        // Get Service list and set it to comboBox
                        bunifuDropdownDetail.DataSource = Service.GetListService();
                        bunifuDropdownDetail.ValueMember = "PRICE";
                        bunifuDropdownDetail.DisplayMember = "SERVICENAME";
                        break;
                    case Bill.MATERIALBILL:
                        bunifuLabelDetail.Text = "Đồ dùng:";

                        // Get Material list and set it to comboBox
                        bunifuDropdownDetail.DataSource = Material.GetListMaterial();
                        bunifuDropdownDetail.ValueMember = "PRICE";
                        bunifuDropdownDetail.DisplayMember = "MATERIALNAME";
                        bunifuLabelHICD.Visible = false;
                        bunifuLabelHICD.Visible = false;
                        break;
                }

                // If bill was pay then do nothing
                if (BillDetail.State == Bill.PAY)
                {
                    bunifuButtonAdd.Enabled = false;
                    bunifuButtonDelete.Enabled = false;
                    bunifuButtonPay.Enabled = false;
                    bunifuButtonSave.Enabled = false;
                    bunifuDatePickerInputBill.Enabled = false;
                    bunifuLabelTotalBillPrice.ForeColor = Color.Green;
                    bunifuLabelBillState.ForeColor = Color.Green;
                    bunifuLabelBillState.Text = "Đã thanh toán";
                }


                // Set information when user edit bill's detail
                if ("edit".Equals(UserAction))
                {
                    decimal totalPrice = BillDetail.TotalPrice;
                    // Set billID
                    bunifuTextBoxBillID.Text = BillDetail.BillID.ToString();
                    bunifuDatePickerInputBill.Value = BillDetail.Date;
                    // When update bill, user can only update bill's state
                    bunifuButtonAdd.Enabled = false;
                    bunifuButtonDelete.Enabled = false;
                    bunifuButtonSave.Enabled = false;
                    bunifuDatePickerInputBill.Enabled = false;

                    //BillDetail = Bill.GetBill(BillDetail.BillID);
                    if (HICID != 0)
                    {
                        totalPrice = totalPrice / 4;
                    }
                    bunifuLabelTotalBillPrice.Text = totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));

                    // Set dataViewBillDetail corresponding bill's type
                    switch (BillDetail.BillTypeID)
                    {
                        case Bill.MEDICINEBILL:
                            BillMedicineTable = MedicineBillDetail.GetListMedicineBillDetail(BillDetail.BillID);

                            BillMedicineTable.Columns.Add("Thuốc", typeof(string), "[MEDICINENAME]");
                            BillMedicineTable.Columns.Add("Số lượng", typeof(int), "[QUANTITY]");
                            BillMedicineTable.Columns.Add("Giá", typeof(decimal), "[PRICE]");

                            bunifuDataGridViewBillDetail.DataSource = BillMedicineTable;

                            for (int i = 0; i < 3; i++)
                            {
                                bunifuDataGridViewBillDetail.Columns[i].Visible = false;
                            }

                            break;
                        case Bill.SERVICEBILL:
                            BillServiceTable = ServiceBillDetail.GetListServiceBillDetail(BillDetail.BillID);

                            BillServiceTable.Columns.Add("Dịch vụ", typeof(string), "[SERVICENAME]");
                            BillServiceTable.Columns.Add("Số lượng", typeof(int), "[QUANTITY]");
                            BillServiceTable.Columns.Add("Giá", typeof(decimal), "[PRICE]");

                            bunifuDataGridViewBillDetail.DataSource = BillServiceTable;

                            for (int i = 0; i < 3; i++)
                            {
                                bunifuDataGridViewBillDetail.Columns[i].Visible = false;
                            }

                            break;
                        case Bill.MATERIALBILL:
                            BillMaterialTable = RentMaterialBillDetail.GetListRentMaterialBillDetail(BillDetail.BillID);

                            BillMaterialTable.Columns.Add("Đồ dùng", typeof(string), "[MATERIALNAME]");
                            BillMaterialTable.Columns.Add("Số lượng", typeof(int), "[QUANTITY]");
                            BillMaterialTable.Columns.Add("Giá", typeof(decimal), "[PRICE]");

                            bunifuDataGridViewBillDetail.DataSource = BillMaterialTable;

                            for (int i = 0; i < 3; i++)
                            {
                                bunifuDataGridViewBillDetail.Columns[i].Visible = false;
                            }

                            break;
                    }
                }
                else if ("insert".Equals(UserAction))       /// Set information when user insert bill's detail
                {
                    // Generate next billID
                    bunifuTextBoxBillID.Text = Bill.GetNextBillID().ToString();
                    bunifuDatePickerInputBill.Value = DateTime.Today;
                    bunifuLabelTotalBillPrice.Text = 0.ToString("C", CultureInfo.CreateSpecificCulture("vi"));

                    BillDetail.BillID = Bill.GetNextBillID();
                    BillDetail.Date = bunifuDatePickerInputBill.Value;
                    BillDetail.TotalPrice = 0;
                    BillDetail.State = 0;

                    switch (BillDetail.BillTypeID)
                    {
                        case Bill.MEDICINEBILL:
                            bunifuButtonAdd.Enabled = true;
                            bunifuButtonDelete.Enabled = true;
                            decimal totalPrice = new Decimal();

                            BillMedicineTable = PrescriptionDetail.GetListPrescriptionDetailWithMedicine(PrescriptionID);

                            BillMedicineTable.Columns.Add("Thuốc", typeof(string), "[MEDICINENAME]");
                            BillMedicineTable.Columns.Add("Số lượng", typeof(int), "[QUANTITY]");
                            BillMedicineTable.Columns.Add("Giá", typeof(decimal), "[PRICE]");

                            bunifuDataGridViewBillDetail.DataSource = BillMedicineTable;

                            for (int i = 0; i < 4; i++)
                            {
                                bunifuDataGridViewBillDetail.Columns[i].Visible = false;
                            }

                            foreach (DataRow row in BillMedicineTable.Rows)
                            {
                                totalPrice += (decimal)row["Giá"];
                            }

                            BillDetail.TotalPrice = totalPrice;

                            if (HICID != 0)
                            {
                                totalPrice = totalPrice / 4;
                            }

                            bunifuLabelTotalBillPrice.Text = totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));

                            break;

                        case Bill.SERVICEBILL:
                            BillServiceTable = new DataTable();

                            BillServiceTable.Columns.Add("SERVICEID", typeof(int));
                            BillServiceTable.Columns.Add("Dịch vụ", typeof(string));
                            BillServiceTable.Columns.Add("Số lượng", typeof(int));
                            BillServiceTable.Columns.Add("Giá", typeof(decimal));

                            bunifuDataGridViewBillDetail.DataSource = BillServiceTable;
                            bunifuDataGridViewBillDetail.Columns["SERVICEID"].Visible = false;
                            break;
                        case Bill.MATERIALBILL:
                            BillMaterialTable = new DataTable();

                            BillMaterialTable.Columns.Add("MATERIALID", typeof(int));
                            BillMaterialTable.Columns.Add("Đồ dùng", typeof(string));
                            BillMaterialTable.Columns.Add("Số lượng", typeof(int));
                            BillMaterialTable.Columns.Add("Giá", typeof(decimal));

                            bunifuDataGridViewBillDetail.DataSource = BillMaterialTable;
                            bunifuDataGridViewBillDetail.Columns["MATERIALID"].Visible = false;
                            break;
                    }
                }
                else
                {
                    switch (UserAction)
                    {
                        case "insertExamination":
                            decimal totalPrice = Service.GetServiceExamination().Price;
                            // Only save and pay when create examination
                            bunifuButtonAdd.Enabled = false;
                            bunifuButtonDelete.Enabled = false;

                            // Set new bill detail for examination
                            BillDetail.BillID = Bill.GetNextBillID();
                            BillDetail.Date = DateTime.Now;
                            BillDetail.TotalPrice = totalPrice;
                            BillDetail.State = 0;

                            // Create table for datagridview
                            BillServiceTable = new DataTable();

                            BillServiceTable.Columns.Add("SERVICEID", typeof(int));
                            BillServiceTable.Columns.Add("Dịch vụ", typeof(string));
                            BillServiceTable.Columns.Add("Số lượng", typeof(int));
                            BillServiceTable.Columns.Add("Giá", typeof(decimal));

                            bunifuDataGridViewBillDetail.DataSource = BillServiceTable;
                            bunifuDataGridViewBillDetail.Columns["SERVICEID"].Visible = false;

                            BillServiceTable.Rows.Add(new object[] { 100, "Khám bệnh", 1, totalPrice });

                            if (HICID != 0)
                            {
                                totalPrice = totalPrice / 4;
                                //BillDetail.TotalPrice = totalPrice;                                
                            }

                            // Set form information
                            bunifuTextBoxBillID.Text = Bill.GetNextBillID().ToString();
                            bunifuDatePickerInputBill.Value = BillDetail.Date;
                            bunifuLabelTotalBillPrice.Text = totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));

                            break;
                        case "insertTest":
                            break;
                        case "insertSurgery":
                            break;
                    }

                    UserAction = "insert";
                }
            }
            catch (SqlException exception)
            {
                bunifuSnackbar1.Show(this, exception.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }

        }
        //public FormBillDetail(string userAction, Bill bill, Staff staff, Patient patient)
        //{
        //    InitializeComponent();

        //    // Set useraction and bill
        //    this.BillDetail = bill;
        //    this.UserAction = userAction;
        //    this.StaffDetail = staff;
        //    this.PatientDetail = patient;

        //    reFreshForm();
        //}

        // Set information to form

        private void bunifuDropdownDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (BillDetail.BillTypeID)
            {
                case Bill.MEDICINEBILL:
                    decimal medicinePrice = Convert.ToDecimal(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["PRICE"]);
                    bunifuLabelPriceDetail.Text = medicinePrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));
                    break;
                case Bill.SERVICEBILL:
                    decimal servicePrice = Convert.ToDecimal(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["PRICE"]);
                    bunifuLabelPriceDetail.Text = servicePrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));
                    break;
                case Bill.MATERIALBILL:
                    decimal materialPrice = Convert.ToDecimal(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["PRICE"]);
                    bunifuLabelPriceDetail.Text = materialPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));
                    break;
            }
        }

        private void bunifuButtonAdd_Click(object sender, EventArgs e)
        {
            decimal totalPrice = new Decimal();
            bool isDulicate = false;
            // Check validate
            if (string.IsNullOrEmpty(bunifuTextBoxQuantity.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu số lượng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }

            // Add bill detail corresponding to bill's type
            switch (BillDetail.BillTypeID)
            {
                // Add medicine detail
                case Bill.MEDICINEBILL:
                    int medicineID = Convert.ToInt32(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["MEDICINEID"]);
                    string medicineName = ((DataRowView)bunifuDropdownDetail.SelectedItem).Row["MEDICINENAME"].ToString();
                    int quantityMedicine = Convert.ToInt16(bunifuTextBoxQuantity.Text);
                    decimal priceMedicine = Convert.ToDecimal(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["PRICE"]) * quantityMedicine;

                    BillMedicineTable.Rows.Add(new object[] { medicineID, medicineName, quantityMedicine, priceMedicine });
                    bunifuDataGridViewBillDetail.DataSource = BillMedicineTable;
                    break;

                // Add service detail
                case Bill.SERVICEBILL:

                    int serviceID = Convert.ToInt32(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["SERVICEID"]);
                    string serviceName = ((DataRowView)bunifuDropdownDetail.SelectedItem).Row["SERVICENAME"].ToString();
                    int quantityService = Convert.ToInt32(bunifuTextBoxQuantity.Text);
                    decimal priceService = Convert.ToDecimal(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["PRICE"]) * quantityService;

                    foreach (DataRow row in BillServiceTable.Rows)
                    {
                        if (row["SERVICEID"].ToString().Trim().Equals(
                            ((DataRowView)bunifuDropdownDetail.SelectedItem).Row["SERVICEID"].ToString().Trim()))
                        {
                            isDulicate = true;
                            row["Số lượng"] = quantityService + (int)row["Số lượng"];
                            row["Giá"] = priceService + (decimal)row["Giá"];
                        }
                    }

                    if (!isDulicate)
                    {
                        BillServiceTable.Rows.Add(new object[] { serviceID, serviceName, quantityService, priceService });
                        isDulicate = false;
                    }

                    break;

                case Bill.MATERIALBILL:
                    int materialID = Convert.ToInt32(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["MATERIALID"]);
                    string materialName = ((DataRowView)bunifuDropdownDetail.SelectedItem).Row["MATERIALNAME"].ToString();
                    int quantityMaterial = Convert.ToInt32(bunifuTextBoxQuantity.Text);
                    decimal priceMaterial = Convert.ToDecimal(((DataRowView)bunifuDropdownDetail.SelectedItem).Row["PRICE"]) * quantityMaterial;

                    foreach (DataRow row in BillMaterialTable.Rows)
                    {
                        if (row["MATERIALID"].ToString().Trim().Equals(
                            ((DataRowView)bunifuDropdownDetail.SelectedItem).Row["MATERIALID"].ToString().Trim()))
                        {
                            isDulicate = true;
                            row["Số lượng"] = quantityMaterial + (int)row["Số lượng"];
                            row["Giá"] = priceMaterial + (decimal)row["Giá"];
                        }
                    }

                    if (!isDulicate)
                    {
                        BillMaterialTable.Rows.Add(new object[] { materialID, materialName, quantityMaterial, priceMaterial });
                        isDulicate = false;
                    }

                    break;
            }

            foreach (DataRow record in ((DataTable)bunifuDataGridViewBillDetail.DataSource).Rows)
            {
                totalPrice += Convert.ToDecimal(record["Giá"]);
            }
            BillDetail.TotalPrice = totalPrice;
            if (HICID != 0 && BillDetail.BillTypeID != 102)
            {
                totalPrice = totalPrice / 4;
            }
            bunifuLabelTotalBillPrice.Text = totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi"));
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

                        insertBillDetail();
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

                    //Bill billReport;

                    //if ("insert".Equals(UserAction))
                    //{
                    //    billReport = Bill.GetBill(Bill.GetCurrentBillID());
                    //}
                    //else
                    //{
                    //    billReport = BillDetail;
                    //}

                    //FormReport reportForm = new FormReport();

                    //switch (billReport.BillTypeID)
                    //{
                    //    case Bill.MEDICINEBILL:
                    //        reportForm.ReportType = "MEDICINEBILL";
                    //        reportForm.ObjectID = billReport.BillID;
                    //        break;
                    //    case Bill.SERVICEBILL:
                    //        reportForm.ReportType = "SERVICEBILL";
                    //        reportForm.ObjectID = billReport.BillID;
                    //        break;
                    //    case Bill.MATERIALBILL:
                    //        reportForm.ReportType = "MATERIALBILL";
                    //        reportForm.ObjectID = billReport.BillID;
                    //        break;
                    //    default:
                    //        MessageBox.Show("Vui lòng chọn hóa đơn để in!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //}

                    //reportForm.Show();
                    MessageBox.Show("Thanh toán thành công!");
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
        private void insertBillDetail()
        {
            switch (BillDetail.BillTypeID)
            {
                case Bill.MEDICINEBILL:

                    MedicineBillDetail newMedicineBillDetail = new MedicineBillDetail();

                    foreach (DataRow record in ((DataTable)bunifuDataGridViewBillDetail.DataSource).Rows)
                    {
                        newMedicineBillDetail.BillID = Bill.GetCurrentBillID();
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
                    insertBillDetail();
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

        private void FormBillDetail_Load(object sender, EventArgs e)
        {

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

        private void bunifuDataGridViewBillDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}