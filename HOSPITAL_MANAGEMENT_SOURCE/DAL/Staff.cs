using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using System;
using System.Data;
using Npgsql;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    public class Staff
    {
        public const int GENDER_MALE = 0;
        public const int GENDER_FEMALE = 1;
        public static DataTable staffTable;

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
        public string SDT { get; set; }
        public Staff() { }

        public Staff(int staffID, int majorID, int departmentID, int roleID, string password, string firstName, string lastName, string email,
            DateTime birthDay, int gender, decimal iCN, string address, int state, string sdt)
        {
            StaffID = staffID;
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
            SDT = sdt;
        }

        public static int InsertStaff(Staff staff)
        {
            string sqlInsert = @"INSERT INTO ""STAFF""
                                (DEPARTMENTID, MAJORID, ROLEID, PASSWORD, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, ICN, ADDRESS, STATE, EMAIL, SDT)
                                VALUES
                                (@DepartmentID, @MajorID, @RoleID, @Password, @FirstName, @LastName, @BirthDay, @Gender, @ICN
                                    , @Address, @State, @Mail, @SDT)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("@DepartmentID", staff.DepartmentID),
                new NpgsqlParameter("@MajorID", staff.MajorID),
                new NpgsqlParameter("@RoleID", staff.RoleID),
                new NpgsqlParameter("@Password",staff.Password),
                new NpgsqlParameter("@FirstName", staff.FirstName),
                new NpgsqlParameter("@LastName", staff.LastName),
                new NpgsqlParameter("@BirthDay", staff.BirthDay),
                new NpgsqlParameter("@Gender", staff.Gender),
                new NpgsqlParameter("@ICN", staff.ICN),
                new NpgsqlParameter("@Address", staff.Address),
                new NpgsqlParameter("@State", staff.State),
                new NpgsqlParameter("@Mail", staff.Email),
                new NpgsqlParameter("@SDT", staff.SDT)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlInsert, npgsqlParameters);
        }

        public static int UpdateStaff(Staff staff)
        {
            string sqlUpdate = @"UPDATE ""STAFF""
                                SET DEPARTMENTID = @DepartmentID, MAJORID = @MajorID, ROLEID = @RoleID, PASSWORD = @Password
                                                 , FIRSTNAME = @FirstName, LASTNAME = @LastName, BIRTHDAY = @BirthDay, GENDER = @Gender
                                                 , ICN = @ICN, ADDRESS = @Address, STATE = @State, EMAIL = @Mail, SDT = @SDT
                                WHERE (STAFFID = @StaffID)";

            NpgsqlParameter[] npgsqlParameters = {
                new NpgsqlParameter("StaffID", staff.StaffID),
                new NpgsqlParameter("@DepartmentID", staff.DepartmentID),
                new NpgsqlParameter("@MajorID", staff.MajorID),
                new NpgsqlParameter("@RoleID", staff.RoleID),
                new NpgsqlParameter("@Password", staff.Password),
                new NpgsqlParameter("@FirstName", staff.FirstName),
                new NpgsqlParameter("@LastName", staff.LastName),
                new NpgsqlParameter("@BirthDay", staff.BirthDay),
                new NpgsqlParameter("@Gender", staff.Gender),
                new NpgsqlParameter("@ICN", staff.ICN),
                new NpgsqlParameter("@Address", staff.Address),
                new NpgsqlParameter("@State", staff.State),
                new NpgsqlParameter("@Mail", staff.Email),
                new NpgsqlParameter("@SDT", staff.SDT)
            };

            return NpgSqlResult.ExecuteNonQuery(sqlUpdate, npgsqlParameters);
        }

        public static int DeleteStaff(int staffID)
        {
            string sqlDelete = @"DELETE FROM ""STAFF""
                                WHERE (STAFFID = @StaffID)";

            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@StaffID", staffID) };

            return NpgSqlResult.ExecuteNonQuery(sqlDelete, npgsqlParameters);
        }

        public static DataTable GetListStaff()
        {
            string sqlSelect = @"SELECT STAFF.STAFFID, DEPARTMENT.DEPARTMENTNAME, MAJOR.MAJORNAME, ROLE.ROLENAME, STAFF.PASSWORD
                                    , STAFF.FIRSTNAME, STAFF.LASTNAME, STAFF.BIRTHDAY, STAFF.GENDER, STAFF.ICN, STAFF.ADDRESS, STAFF.STATE, STAFF.EMAIL, STAFF.SDT
                                FROM ""STAFF"" INNER JOIN
                                    ""DEPARTMENT"" ON STAFF.DEPARTMENTID = DEPARTMENT.DEPARTMENTID INNER JOIN
                                    ""MAJOR"" ON STAFF.MAJORID = MAJOR.MAJORID INNER JOIN
                                    ""ROLE"" ON STAFF.ROLEID = ROLE.ROLEID";

            staffTable = NpgSqlResult.ExecuteQuery(sqlSelect);

            return staffTable;
        }
        public static Staff GetStaff(int staffID)
        {
            Staff newStaff = new Staff();
            DataTable staffDataTable;
            string sqlSelect = @"SELECT STAFFID, DEPARTMENTID, MAJORID, ROLEID, PASSWORD, FIRSTNAME, LASTNAME, BIRTHDAY,
                                        GENDER, ICN, ADDRESS, STATE, EMAIL, SDT
                                FROM ""STAFF""
                                WHERE (STAFFID = @StaffID)";
            NpgsqlParameter[] npgsqlParameters = { new NpgsqlParameter("@StaffID", staffID) };

            staffDataTable = NpgSqlResult.ExecuteQuery(sqlSelect, npgsqlParameters);

            if (staffDataTable.Rows.Count > 0)
            {
                newStaff.StaffID = Convert.ToInt32(staffDataTable.Rows[0]["STAFFID"].ToString());
                newStaff.DepartmentID = Convert.ToInt32(staffDataTable.Rows[0]["DEPARTMENTID"].ToString());
                newStaff.MajorID = Convert.ToInt32(staffDataTable.Rows[0]["MAJORID"].ToString());
                newStaff.RoleID = Convert.ToInt32(staffDataTable.Rows[0]["ROLEID"].ToString());
                newStaff.Password = (string)staffDataTable.Rows[0]["PASSWORD"];
                newStaff.FirstName = (string)staffDataTable.Rows[0]["FIRSTNAME"];
                newStaff.LastName = (string)staffDataTable.Rows[0]["LASTNAME"];
                newStaff.BirthDay = (DateTime)staffDataTable.Rows[0]["BIRTHDAY"];
                newStaff.Gender = (int)staffDataTable.Rows[0]["GENDER"];
                newStaff.ICN = staffDataTable.Rows[0]["ICN"] != DBNull.Value ? Convert.ToDecimal(staffDataTable.Rows[0]["ICN"]) : 0;
                newStaff.Address = (string)staffDataTable.Rows[0]["ADDRESS"];
                newStaff.State = (int)staffDataTable.Rows[0]["STATE"];
                newStaff.Email = (string)staffDataTable.Rows[0]["EMAIL"];
                newStaff.SDT = (string)staffDataTable.Rows[0]["SDT"];
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