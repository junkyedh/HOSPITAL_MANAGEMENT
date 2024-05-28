using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormAssignDetail : Form
    {
        public Assignment AssignDetail { get; set; }
        public String UserAction { get; set; }
        private static List<Staff> listStaff = new List<Staff>();
        private static List<AssignmentDetail> listAD = new List<AssignmentDetail>();
        public FormAssignDetail()
        {
            InitializeComponent();
        }

        public FormAssignDetail(int patientID)
        {
            InitializeComponent();
            SetADForInsert(patientID);
        }

        private void SetADForUpdate(Assignment assignDetail)
        {
            textBoxAssignID.Text = assignDetail.AssignID.ToString();
            textBoxPatientID.Text = assignDetail.PatientID.ToString();
            dateCreate.Value = assignDetail.Date;
            dateDischarge.Value = assignDetail.DischargedDate;
            dateHospitalize.Value = assignDetail.HospitalizateDate;

            dateHospitalize.Enabled = false;

            DataTable dtStaff = Staff.GetListStaff();
            for (int i = 0; i < dtStaff.Rows.Count; i++)
            {
                String staffName = dtStaff.Rows[i][6].ToString() + " " + dtStaff.Rows[i][5].ToString();
                Staff newStaff = Staff.GetStaff(Convert.ToInt32(dtStaff.Rows[i][0]));
                listStaff.Add(newStaff);
                listBoxSystemStaff.Items.Add(staffName);
            }
            listBoxSystemStaff.SelectedIndex = 0;

            DataTable dtAD = AssignmentDetail.GetListAssignmentDetails(assignDetail.AssignID);
            for (int i = 0; i < dtAD.Rows.Count; i++)
            {
                String staffName = dtAD.Rows[i][2].ToString() + " " + dtAD.Rows[i][3].ToString();
                AssignmentDetail newAD = new AssignmentDetail();
                newAD.AssignID = Convert.ToInt32(dtAD.Rows[i][0]);
                newAD.StaffID = Convert.ToInt32(dtAD.Rows[i][1]);
                listAD.Add(newAD);
                listBoxCurrentStaff.Items.Add(staffName);
            }
            if (listBoxCurrentStaff.Items.Count > 0)
                listBoxCurrentStaff.SelectedIndex = 0;
        }
        private void SetADForInsert(int patientID)
        {
            HospitalizationCertificate newHC = HospitalizationCertificate.GetHC(Convert.ToDecimal(patientID));
            textBoxPatientID.Text = patientID.ToString();
            dateDischarge.Value = DateTime.Today;
            dateCreate.Value = DateTime.Today;
            dateHospitalize.Value = newHC.Date;
            dateHospitalize.Enabled = false;
            dateCreate.Enabled = false;

            DataTable dtStaff = Staff.GetListStaff();
            for (int i = 0; i < dtStaff.Rows.Count; i++)
            {
                String staffName = dtStaff.Rows[i][6].ToString() + " " + dtStaff.Rows[i][5].ToString();
                Staff newStaff = Staff.GetStaff(Convert.ToInt32(dtStaff.Rows[i][0]));
                listStaff.Add(newStaff);
                listBoxSystemStaff.Items.Add(staffName);
            }
            listBoxSystemStaff.SelectedIndex = 0;
        }



        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (listBoxCurrentStaff.Items.Count > 0)
            {
                if (dateDischarge.Value > dateHospitalize.Value)
                {
                    try
                    {
                        Assignment newAssign = new Assignment();
                        newAssign.PatientID = Convert.ToInt32(textBoxPatientID.Text);
                        newAssign.DischargedDate = dateDischarge.Value;
                        newAssign.HospitalizateDate = dateHospitalize.Value;
                        newAssign.Date = dateCreate.Value;
                        if (this.UserAction == "edit")
                        {
                            newAssign.AssignID = Convert.ToInt32(textBoxAssignID.Text);
                            DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bản phân công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Assignment.UpdateAssignment(newAssign) > 0)
                                {
                                    AssignmentDetail.DeleteAssignmentDetails(newAssign.AssignID);
                                    for (int i = 0; i < listAD.Count; i++)
                                    {
                                        AssignmentDetail newAD = listAD[i];
                                        newAD.AssignID = newAssign.AssignID;
                                        AssignmentDetail.InsertAssignmentDetails(newAD);
                                    }
                                    listAD.Clear();
                                    bunifuSnackbar1.Show(this, "Cập nhập thông tin bảng phân công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            newAssign.AssignID = 0;
                            if (Assignment.InsertAssignment(newAssign) > 0)
                            {
                                int curAssignID = Assignment.GetCurrentIdentity();
                                for (int i = 0; i < listAD.Count; i++)
                                {
                                    listAD[i].AssignID = curAssignID;
                                    AssignmentDetail.InsertAssignmentDetails(listAD[i]);
                                }
                                bunifuSnackbar1.Show(this, "Thêm bảng phân công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                                return;
                            }
                        }
                    }
                    catch
                    {
                        bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        return;
                    }
                    listAD.Clear();
                    this.Close();
                }
                else
                {
                    bunifuSnackbar1.Show(this, "Ngày xuất viện phải sau ngày nhập viện", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                    return;
                }
            }
            else
            {
                bunifuSnackbar1.Show(this, "Chưa có nhân viên nào tham gia phân công chăm sóc bệnh nhân", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                return;
            }
        }

        private Boolean CheckStaffInAssign(int staffID)
        {
            for (int i = 0; i < listAD.Count; i++)
            {
                if (staffID == listAD[i].StaffID)
                    return true;
            }
            return false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRemoveFunction_Click(object sender, EventArgs e)
        {
            if (listBoxCurrentStaff.SelectedIndex != -1)
            {
                int selectedStaff = listBoxCurrentStaff.SelectedIndex;
                listAD.RemoveAt(selectedStaff);
                listBoxCurrentStaff.Items.RemoveAt(selectedStaff);
                listBoxCurrentStaff.SelectedIndex = listBoxCurrentStaff.Items.Count - 1;
            }
        }

        private void buttonInsertFunction_Click(object sender, EventArgs e)
        {
            int selectedStaff = listBoxSystemStaff.SelectedIndex;
            if (CheckStaffInAssign(listStaff[selectedStaff].StaffID))
            {
                bunifuSnackbar1.Show(this, "Nhân viên đã có trong danh sách phân công chăm sóc bệnh nhân", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, "Thông báo", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            }
            else
            {
                AssignmentDetail newAD = new AssignmentDetail(0, listStaff[selectedStaff].StaffID);
                listAD.Add(newAD);
                listBoxCurrentStaff.Items.Add(listBoxSystemStaff.Items[selectedStaff].ToString());
                listBoxCurrentStaff.SelectedIndex = 0;
            }
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelRoleID_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPatientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateCreate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAssignID_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }
    }
}
