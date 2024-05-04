using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class Staff
    {
        public const int GENDER_MALE = 0;
        public const int GENDER_FEMALE = 1;
        public static DataTable staffTable;
        //private static bool isDataChanged = false;

        public int StaffID { get; set; }
        public int RoleID { get; set; }
        public int MajorID { get; set; }
        public int DepartmentID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public decimal ICN { get; set; }
        public string Address { get; set; }
        public int State { get; set; }

        public Staff() { }

        public Staff(int patientID, int majorID, int departmentID, int roleID, string password, string firstName, string lastName, string email,
            DateTime birthDay, int gender, decimal iCN, string address, int state)
        {
            StaffID = patientID;
            MajorID = majorID;
            DepartmentID = departmentID;
            RoleID = roleID;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDay = birthDay;
            Gender = gender;
            ICN = iCN;
            Address = address;
            State = state;
        }

        public static int InsertStaff(Staff staff)
        {
            string sqlInsert = @"INSERT INTO STAFF
                                (DEPARTMENTID, MAJORID, ROLEID, PASSWORD, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, ADDRESS, STATE, EMAIL)
                                VALUES
                                (@DepartmentID, @MajorID, @RoleID, @Password, @FirstName, @LastName, @BirthDay, @Gender, @ICN
                                    , @Address, @State, @Mail)";

            SqlParameter[] sqlParameters = {   new SqlParameter("@DepartmentID", staff.DepartmentID),
                                           new SqlParameter("@MajorID", staff.MajorID),
                                           new SqlParameter("@RoleID", staff.RoleID),
                                           new SqlParameter("@Password",staff.Password),
                                           new SqlParameter("@FirstName", staff.FirstName),
                                           new SqlParameter("@LastName", staff.LastName),
                                           new SqlParameter("@BirthDay", staff.BirthDay),
                                           new SqlParameter("@Gender", staff.Gender),
                                           new SqlParameter("@ICN", staff.ICN),
                                           new SqlParameter("@Address", staff.Address),
                                           new SqlParameter("@State", staff.State),
                                           new SqlParameter("@Mail", staff.Email)};


            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }

        public static int UpdateStaff(Staff staff)
        {
            string sqlUpdate = @"UPDATE STAFF
                                SET DEPARTMENTID = @DepartmentID, MAJORID = @MajorID, ROLEID = @RoleID, PASSWORD = @Password
                                                 , FIRSTNAME = @FirstName, LASTNAME = @LastName, BIRTHDAY = @BirthDay, GENDER = @Gender
                                                 , ICN = @ICN, ADDRESS = @Address, STATE = @State, EMAIL = @Mail
                                WHERE (STAFFID = @StaffID)";

            SqlParameter[] sqlParameters = { new SqlParameter("StaffID", staff.StaffID),
                                           new SqlParameter("@DepartmentID", staff.DepartmentID),
                                           new SqlParameter("@MajorID", staff.MajorID),
                                           new SqlParameter("@RoleID", staff.RoleID),
                                           new SqlParameter("@Password", staff.Password),
                                           new SqlParameter("@FirstName", staff.FirstName),
                                           new SqlParameter("@LastName", staff.LastName),
                                           new SqlParameter("@BirthDay", staff.BirthDay),
                                           new SqlParameter("@Gender", staff.Gender),
                                           new SqlParameter("@ICN", staff.ICN),
                                           new SqlParameter("@Address", staff.Address),
                                           new SqlParameter("@State", staff.State),
                                           new SqlParameter("@Mail", staff.Email)};

            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }

        public static int DeleteStaff(int staffID)
        {
            string sqlDelete = @"DELETE FROM STAFF
                                WHERE (STAFFID = @StaffID)";

            SqlParameter[] sqlParameters = { new SqlParameter("@StaffID", staffID) };

            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }


        //Lấy danh sách bằng cách joint nhiều bảng với nhau
        public static DataTable GetListStaff()
        {
            string sqlSelect = @"SELECT STAFF.STAFFID, DEPARTMENT.DEPARTMENTNAME, MAJOR.MAJORNAME, ROLE.ROLENAME, STAFF.PASSWORD
                                    , STAFF.FIRSTNAME, STAFF.LASTNAME, STAFF.BIRTHDAY, STAFF.GENDER, STAFF.ICN, STAFF.ADDRESS, STAFF.STATE, STAFF.EMAIL
                                FROM STAFF INNER JOIN
                                    DEPARTMENT ON STAFF.DEPARTMENTID = DEPARTMENT.DEPARTMENTID INNER JOIN
                                    MAJOR ON STAFF.MAJORID = MAJOR.MAJORID INNER JOIN
                                    ROLE ON STAFF.ROLEID = ROLE.ROLEID";

            staffTable = SqlResult.ExecuteQuery(sqlSelect);

            return staffTable;
        }

        //Chỉ lấy danh sách sách dựa trên ID của staff
        public static Staff GetStaff(int staffID)
        {
            Staff newStaff = new Staff();
            DataTable staffDataTable;
            string sqlSelect = @"SELECT STAFFID, DEPARTMENTID, MAJORID, ROLEID, PASSWORD, FIRSTNAME, LASTNAME, BIRTHDAY,
                                         GENDER, ICN, ADDRESS, STATE, EMAIL
                                 FROM STAFF
                                 WHERE (STAFFID = @StaffID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@StaffID", staffID) };

            staffDataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            if (staffDataTable.Rows.Count > 0)
            {

                //Thay vì chúng ta sử dụng số để tránh nhầm lẫn thì mảng 2 chiều Rows[dòng][Tên cột]
                newStaff.StaffID = Convert.ToInt32(staffDataTable.Rows[0]["STAFFID"].ToString());
                newStaff.DepartmentID = Convert.ToInt32(staffDataTable.Rows[0]["DEPARTMENTID"].ToString());
                newStaff.MajorID = Convert.ToInt32(staffDataTable.Rows[0]["MAJORID"].ToString());
                newStaff.RoleID = Convert.ToInt32(staffDataTable.Rows[0]["ROLEID"].ToString());
                newStaff.Password = (string)staffDataTable.Rows[0]["PASSWORD"];
                newStaff.FirstName = (string)staffDataTable.Rows[0]["FIRSTNAME"];
                newStaff.LastName = (string)staffDataTable.Rows[0]["LASTNAME"];
                newStaff.BirthDay = (DateTime)staffDataTable.Rows[0]["BIRTHDAY"];
                newStaff.Gender = (int)staffDataTable.Rows[0]["GENDER"];
                newStaff.ICN = (decimal)staffDataTable.Rows[0]["ICN"];
                newStaff.Address = (string)staffDataTable.Rows[0]["ADDRESS"];
                newStaff.State = (int)staffDataTable.Rows[0]["STATE"];
                newStaff.Email = (string)staffDataTable.Rows[0]["EMAIL"];
            }

            return newStaff;
        }
        public Boolean LogIn()
        {
            return true;
        }
        public Boolean ChangePassword()
        {
            return true;
        }
        public Boolean ChangeInformation()
        {
            return true;
        }
    }
}
