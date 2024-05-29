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
    public partial class FormDCDetail : Form
    {
        public DischargeCertificate DCDetail { get; set; }
        public String UserAction { get; set; }
        public FormDCDetail()
        {
            InitializeComponent();
        }
        //This constructor for insert feature
        public FormDCDetail(int staffID, int patientID)
        {
            InitializeComponent();
            SetDCForInsert(staffID, patientID);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuTextBoxDCID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
