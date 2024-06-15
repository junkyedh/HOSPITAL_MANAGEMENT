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
    public partial class FormTestDetail : Form
    {
        public TestCertificate testDetail { get; set; }
        public string UserAction { get; set; }
        private static List<TestType> listTestType = new List<TestType>();
        private static List<TestDetail> listTD = new List<TestDetail>();
        public FormTestDetail()
        {
            InitializeComponent();
        }
        //This constructor for insert feature
        public FormTestDetail(int staffID, int patientID)
        {
            InitializeComponent();
            SetTDForInsert(staffID, patientID);
        }
        ////This constructor for update feature
        public FormTestDetail(TestCertificate tDetail, String userAction)
        {
            InitializeComponent();
            this.testDetail = tDetail;
            this.UserAction = userAction;
            SetTDForUpdate(tDetail);
        }
        private void SetTDForUpdate(TestCertificate tDetail)
        {
            textBoxTCID.Text = tDetail.TCID.ToString();
            bunifuTextBox8.Text = tDetail.PatientID.ToString();
            textBoxStaffID.Text = tDetail.StaffID.ToString();
            dateCreate.Value = tDetail.Date;
            comboBoxState.SelectedIndex = tDetail.State;

            DataTable dtTestType = TestType.GetListTestType();
            for (int i = 0; i < dtTestType.Rows.Count; i++)
            {
                TestType newTestType = new TestType();
                newTestType.TestTypeID = Convert.ToInt16(dtTestType.Rows[i][0]);
                newTestType.TestName = dtTestType.Rows[i][1].ToString();
                listTestType.Add(newTestType);
                comboBoxTestType.Items.Add(newTestType.TestName);
            }
            comboBoxTestType.SelectedIndex = 0;

            DataTable dtTestDetail = TestDetail.GetListTestDetail(tDetail.TCID);
            for (int i = 0; i < dtTestDetail.Rows.Count; i++)
            {
                TestDetail newTD = new TestDetail();
                newTD.TCID = Convert.ToInt32(dtTestDetail.Rows[i][0]);
                newTD.TestTypeID = Convert.ToInt16(dtTestDetail.Rows[i][1]);
                newTD.Result = dtTestDetail.Rows[i][2].ToString();
                listTD.Add(newTD);
                listSelectedTestType.Items.Add(dtTestDetail.Rows[i][3].ToString());
            }
            if (listSelectedTestType.Items.Count > 0)
                listSelectedTestType.SelectedIndex = 0;
        }
        private void SetTDForInsert(int staffID, int patientID)
        {
            bunifuTextBox8.Text = patientID.ToString();
            textBoxStaffID.Text = staffID.ToString();
            dateCreate.Value = DateTime.Today;
            dateCreate.Enabled = false;
            textBoxResult.Text = "Chưa xét nghiệm";
            textBoxResult.ReadOnly = true;
            comboBoxState.SelectedIndex = 0;
            comboBoxState.Enabled = false;

            DataTable dtTestType = TestType.GetListTestType();
            for (int i = 0; i < dtTestType.Rows.Count; i++)
            {
                TestType newTestType = new TestType();
                newTestType.TestTypeID = Convert.ToInt16(dtTestType.Rows[i][0]);
                newTestType.TestName = dtTestType.Rows[i][1].ToString();
                listTestType.Add(newTestType);
                comboBoxTestType.Items.Add(newTestType.TestName);
            }
            comboBoxTestType.SelectedIndex = 0;
        }
        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxTestType.SelectedIndex;
            if (CheckTestType(listTestType[selectedIndex].TestTypeID))
            {
                MessageBox.Show("Loại xét nghiệm này đã có trong phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                TestDetail newTestDetail = new TestDetail();
                newTestDetail.TCID = 0;
                newTestDetail.TestTypeID = listTestType[selectedIndex].TestTypeID;
                newTestDetail.Result = "Chưa xét nghiệm";
                listTD.Add(newTestDetail);
                listSelectedTestType.Items.Add(listTestType[selectedIndex].TestName);
                listSelectedTestType.SelectedIndex = listSelectedTestType.Items.Count - 1;
            }
        }
        private Boolean CheckTestType(int testTypeID)
        {
            for (int i = 0; i < listTD.Count; i++)
            {
                if (listTD[i].TestTypeID == testTypeID)
                    return true;
            }
            return false;
        }
        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            int selectedIndex = listSelectedTestType.SelectedIndex;
            if (selectedIndex >= 0)
            {
                listSelectedTestType.Items.RemoveAt(selectedIndex);
                listTD.RemoveAt(selectedIndex);
                textBoxResult.Text = "";
                listSelectedTestType.SelectedIndex = listSelectedTestType.Items.Count - 1;
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            /*if (!superValidator1.Validate())
                return;*/
            try
            {
                if (listSelectedTestType.Items.Count > 0)
                {
                    TestCertificate newTC = new TestCertificate();
                    newTC.PatientID = Convert.ToInt32(bunifuTextBox8.Text);
                    newTC.StaffID = Convert.ToInt32(textBoxStaffID.Text);
                    newTC.Date = dateCreate.Value;
                    newTC.State = comboBoxState.SelectedIndex;
                    if (this.UserAction == "edit")
                    {
                        newTC.TCID = Convert.ToInt32(textBoxTCID.Text);
                        DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin phiếu xét nghiệm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.OK)
                        {
                            if (TestCertificate.UpdateTC(newTC) > 0)
                            {
                                TestDetail.DeleteTestDetail(newTC.TCID);
                                for (int i = 0; i < listTD.Count; i++)
                                {
                                    listTD[i].TCID = newTC.TCID;
                                    TestDetail.InsertTestDetail(listTD[i]);
                                }
                                listTD.Clear();
                                bunifuSnackbar1.Show(this, "Cập nhập thông tin phiếu xét nghiệm thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                    }
                    else
                    {
                        newTC.TCID = 0;
                        if (TestCertificate.InsertTC(newTC) > 0)
                        {
                            int tcID = TestCertificate.GetCurrentIdentity();
                            for (int i = 0; i < listTD.Count; i++)
                            {
                                listTD[i].TCID = tcID;
                                TestDetail.InsertTestDetail(listTD[i]);
                            }
                            listTD.Clear();
                            bunifuSnackbar1.Show(this, "Thêm phiếu xét nghiệm thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                            return;
                        }

                    }
                    this.Close();
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Yêu cầu nhập loại xét nghiệm", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            catch (Exception ex)
            {
                bunifuSnackbar1.Show(this, $"Lỗi dữ liệu {ex.Message}", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listSelectedTestType.SelectedIndex;
            if (selectedIndex >= 0)
                textBoxResult.Text = listTD[selectedIndex].Result;
        }

        private void textBoxResult_Leave(object sender, EventArgs e)
        {
            int selectedIndex = listSelectedTestType.SelectedIndex;
            if (selectedIndex >= 0)
            {
                listTD[selectedIndex].Result = textBoxResult.Text;
            }
        }

        private void textBoxResult_TextChange(object sender, EventArgs e)
        {
            int selectedIndex = listSelectedTestType.SelectedIndex;
            if (selectedIndex > 0)
            {
                listTD[selectedIndex].Result = textBoxResult.Text;
            }
        }


    }

}

