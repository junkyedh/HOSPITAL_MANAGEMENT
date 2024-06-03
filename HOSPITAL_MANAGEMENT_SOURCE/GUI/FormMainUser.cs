﻿using HOSPITAL_MANAGEMENT_SOURCE.DAL;
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

            //// Khúc này để test cái biểu đồ nha
            //LoadData();
        }
        
        public FormMainUser(Staff staff)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Original();
          
            loginStaff = staff;
            bunifuSnackbar1.Show(this, "Đăng nhập thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            GetStaffInformation();
        }
        private void GetStaffInformation()
        {

        }
        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
        private void bunifuDataGridViewMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void bunifuPictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
           
        }
        private void bunifuButton10_Click(object sender, EventArgs e)
        {

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

        private void bunifuButton29_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            FormLogin_SignUp loginSignup = new FormLogin_SignUp();
            loginSignup.ShowDialog();
        }
        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            //bunifuGradientPanel1.Visible = true;
            //bunifuGradientPanel1.Show();    
        }

        //// Nếu mà muốn chạy thử biểu đồ thì bỏ comment cái dưới á
        //private void LoadData()
        //{
        //    TestSplineArea();
        //    TestDoughnut();
        //}
        //private void TestSplineArea()
        //{
        //    Random rand = new Random();
        //    chart1.DataSource = null; // Xóa dữ liệu cũ

        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Date", typeof(DateTime));
        //    dataTable.Columns.Add("TotalAmount", typeof(double));

        //    // Tạo dữ liệu ngẫu nhiên cho GrossRevenueList
        //    for (int i = 0; i < 5; i++)
        //    {
        //        DateTime date = DateTime.Today.AddDays(-i); // Ngày ngẫu nhiên trong quá khứ
        //        double totalAmount = rand.Next(1000, 5000); // Số tiền ngẫu nhiên
        //        dataTable.Rows.Add(date, totalAmount);
        //    }

        //    chart1.DataSource = dataTable;
        //    chart1.Series[0].XValueMember = "Date";
        //    chart1.Series[0].YValueMembers = "TotalAmount";
        //    chart1.DataBind();
        //}
        //private void TestDoughnut()
        //{
        //    Random rand = new Random();
        //    chart2.DataSource = null; // Xóa dữ liệu cũ

        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Product", typeof(string));
        //    dataTable.Columns.Add("UnitsSold", typeof(int));

        //    string[] products = { "Coffee", "Tea", "Juice", "Smoothie", "Soda" };

        //    // Tạo dữ liệu ngẫu nhiên cho TopProductsList
        //    for (int i = 0; i < products.Length; i++)
        //    {
        //        int unitsSold = rand.Next(50, 200); // Số lượng sản phẩm bán ra ngẫu nhiên
        //        dataTable.Rows.Add(products[i], unitsSold);
        //    }

        //    chart2.DataSource = dataTable;
        //    chart2.Series[0].XValueMember = "Product";
        //    chart2.Series[0].YValueMembers = "UnitsSold";
        //    chart2.DataBind();
        //}
    }
}