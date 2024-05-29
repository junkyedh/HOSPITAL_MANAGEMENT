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
    }
}