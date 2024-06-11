using hospital_management_source.gui;
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
    public partial class FormMainUser : Form
    {
        private Staff loginStaff { get; set; }
        public Point mouseLocation;
        private Bunifu.UI.WinForms.BunifuShadowPanel lastClickedPanel;
        public FormMainUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Original();

            LoadData();
        }
        public FormMainUser(Staff staff)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Original();
            LoadData();

            loginStaff = staff;
        }
        
        private void bunifuShadowPanel2_ControlAdded(object sender, ControlEventArgs e)
        {

        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Original();
            Button1View();
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Original();
            Button2View();
        }
        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Original();
            Button3View();
        }
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Original();
            Button4View();
        }
        private void Original()
        {
            // Ensure all panels are hidden initially
            bunifuPanel1.Visible = false;
            bunifuPanel2.Visible = false;
            bunifuPanel3.Visible = false;
            bunifuPanel4.Visible = false;

            // Set initial positions for buttons
            bunifuButton1.Location = new Point(21, 169);
            bunifuButton2.Location = new Point(21, 220);
            bunifuButton3.Location = new Point(21, 271);
            bunifuButton4.Location = new Point(21, 322);
            bunifuButton5.Location = new Point(21, 373);
            bunifuButton6.Location = new Point(21, 424);
        }
        private void Button1View()
        {
            bunifuButton2.Location = new Point(21, 424);
            bunifuButton3.Location = new Point(21, 475);
            bunifuButton4.Location = new Point(21, 526);
            bunifuButton5.Location = new Point(21, 577);
            bunifuButton6.Location = new Point(21, 628);
            bunifuPanel1.Location = new Point(60, 220); // 45, 220
            bunifuPanel1.Visible = true;
            bunifuPanel1.Size = new Size(177, 199);
            bunifuPanel1.Invalidate();
            return;
        }
        private void Button2View()
        {
            bunifuButton3.Location = new Point(21, 475);
            bunifuButton4.Location = new Point(21, 526);
            bunifuButton5.Location = new Point(21, 577);
            bunifuButton6.Location = new Point(21, 628);
            bunifuPanel3.Location = new Point(60, 271);
            bunifuPanel3.Visible = true;
            bunifuPanel3.Invalidate();
            bunifuPanel3.Size = new Size(180, 201);
            return;
        }
        private void Button3View()
        {
            bunifuButton4.Location = new Point(22, 526);
            bunifuButton5.Location = new Point(22, 577);
            bunifuButton6.Location = new Point(23, 628);
            bunifuPanel4.Location = new Point(60, 322);
            bunifuPanel4.Visible = true;
            bunifuPanel4.Invalidate();
            bunifuPanel4.Size = new Size(273, 202);
            return;
        }
        private void Button4View()
        {
            bunifuButton5.Location = new Point(23, 530);
            bunifuButton6.Location = new Point(23, 585);
            bunifuPanel2.Location = new Point(60, 373);
            bunifuPanel2.Visible = true;
            bunifuPanel2.Invalidate();
            bunifuPanel2.Size = new Size(177, 154);
            return;
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            Original();
            Button3View();
        }

        

        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            FormMainEC formMainEC = new FormMainEC();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainEC);
            formMainEC.Dock = DockStyle.Fill;
        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            FormMainTest formMainTest = new FormMainTest();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainTest);
            formMainTest.Dock = DockStyle.Fill;
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            FormMainSurgeryDetail formMainSurgeryDetail = new FormMainSurgeryDetail();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainSurgeryDetail);
            formMainSurgeryDetail.Dock = DockStyle.Fill;
        }
      
        private void bunifuButton11_Click_1(object sender, EventArgs e)
        {
            FormMainPrescription formMainPrescription = new FormMainPrescription();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainPrescription);
            formMainPrescription.Dock = DockStyle.Fill;
        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            FormMainDisease formMainDisease = new FormMainDisease();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainDisease);
            formMainDisease.Dock = DockStyle.Fill;
        }

        private void bunifuButton17_Click(object sender, EventArgs e)
        {
            FormMainHF formMainHF = new FormMainHF();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainHF);
            formMainHF.Dock = DockStyle.Fill;
        }

        private void bunifuButton16_Click(object sender, EventArgs e)
        {
            FormMainMedicine formMainMedicine = new FormMainMedicine();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainMedicine);
            formMainMedicine.Dock = DockStyle.Fill;
        }

        private void bunifuButton15_Click(object sender, EventArgs e)
        {
            Formmainmonitor formMainMonitor = new Formmainmonitor();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainMonitor);
            formMainMonitor.Dock = DockStyle.Fill;
        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            FormMainBill formMainBill = new FormMainBill();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainBill);
            formMainBill.Dock = DockStyle.Fill;
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            FormMainService formMainService = new FormMainService();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainService);
            formMainService.Dock = DockStyle.Fill;
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            FormMainMaterial formMainMaterial = new FormMainMaterial();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainMaterial);
            formMainMaterial.Dock = DockStyle.Fill;
        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            FormMainBed formMainBed = new FormMainBed();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainBed);
            formMainBed.Dock = DockStyle.Fill;
        }

        private void bunifuButton19_Click(object sender, EventArgs e)
        {
            FormMainHospitalization_HC formMainHospitalization_HC = new FormMainHospitalization_HC();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainHospitalization_HC);
            formMainHospitalization_HC.Dock = DockStyle.Fill;
        }

        private void bunifuButton20_Click(object sender, EventArgs e)
        {
            FormMainHospitalization_DC formMainHospitalization_DC = new FormMainHospitalization_DC();
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Controls.Add(formMainHospitalization_DC);
            formMainHospitalization_DC.Dock = DockStyle.Fill;
        }

        private void bunifuButton29_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            FormLogin_SignUp loginSignup = new FormLogin_SignUp();
            loginSignup.ShowDialog();
            this.Close();

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel1.Controls.Clear();
            bunifuShadowPanel1.Show();
            bunifuGradientPanel2.Visible = true;
            bunifuShadowPanel1.Controls.Add(bunifuGradientPanel2);
        }





        private void LoadData()
        {
            TestSplineArea();
            TestDoughnut();
        }
        private void TestSplineArea()
        {
            Random rand = new Random();
            chart1.DataSource = null; // Xóa dữ liệu cũ

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Số lượng", typeof(double));

            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            for (int i = 0; i < daysInMonth; i++)
            {
                DateTime date = startDate.AddDays(i); // Ngày trong tháng hiện tại
                int patientVisits = rand.Next(50, 200); // Số lượt khám bệnh ngẫu nhiên
                dataTable.Rows.Add(date, patientVisits);
            }

            chart1.DataSource = dataTable;
            chart1.Series[0].XValueMember = "Ngày";
            chart1.Series[0].YValueMembers = "Số lượng";
            chart1.DataBind();
        }
        private void TestDoughnut()
        {
            Random rand = new Random();
            chart2.DataSource = null; // Xóa dữ liệu cũ

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Sản phẩm", typeof(string));
            dataTable.Columns.Add("Số lượng bán ra", typeof(int));

            string[] products = { "Vitamin C", "Paracetamol", "Amoxicillin", "Metformin", "Loperamide", "Aspirin" };

            // Tạo dữ liệu ngẫu nhiên cho TopProductsList
            for (int i = 0; i < products.Length; i++)
            {
                int unitsSold = rand.Next(50, 200); // Số lượng sản phẩm bán ra ngẫu nhiên
                dataTable.Rows.Add(products[i], unitsSold);
            }

            chart2.DataSource = dataTable;
            chart2.Series[0].XValueMember = "Sản phẩm";
            chart2.Series[0].YValueMembers = "Số lượng bán ra";
            chart2.DataBind();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Visible = false;
            bunifuShadowPanel1.Hide();
            bunifuShadowPanel1.Controls.Clear();
            FormMainStaff formMainStaff = new FormMainStaff();
            bunifuShadowPanel1.Controls.Add(formMainStaff);
            formMainStaff.Dock = bunifuShadowPanel1.Dock;
            bunifuShadowPanel1.Show();
            formMainStaff.NhanVien_Click();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Visible = false;
            bunifuShadowPanel1.Hide();
            bunifuShadowPanel1.Controls.Clear();
            FormMainAssigment mainAssigment = new FormMainAssigment();
            bunifuShadowPanel1.Controls.Add(mainAssigment);
            mainAssigment.Dock = bunifuShadowPanel1.Dock;
            bunifuShadowPanel1.Show();
            mainAssigment.PhanCong_Click();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Visible = false;
            bunifuShadowPanel1.Hide();
            bunifuShadowPanel1.Controls.Clear();
            FormMainDeptMajor maindeptmajor = new FormMainDeptMajor();
            bunifuShadowPanel1.Controls.Add(maindeptmajor);
            maindeptmajor.Dock = bunifuShadowPanel1.Dock;
            bunifuShadowPanel1.Show();
            maindeptmajor.KhoaCN_Click();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            bunifuGradientPanel2.Visible = false;
            bunifuShadowPanel1.Hide();
            bunifuShadowPanel1.Controls.Clear();
            FormMainRole mainRole = new FormMainRole();
            bunifuShadowPanel1.Controls.Add(mainRole);
            mainRole.Dock = bunifuShadowPanel1.Dock;
            bunifuShadowPanel1.Show();
            mainRole.PhanQuyen_Click();
        }
    }
}