using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;
using AutoMapper;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    internal class Assignment
    {
        // Các thuộc tính
        public int AssignID { get; set; }
        public int PatientID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DischargedDate { get; set; }
        public DateTime HospitalizateDate { get; set; }
        public string PatientName { get; set; } // Thêm thông tin chi tiết

        // Hàm khởi tạo
        public Assignment() { }
        public Assignment(int assignID, int patientID, DateTime date, DateTime dischargedDate, DateTime hospitalizateDate, string patientName)
        {
            this.AssignID = assignID;
            this.PatientID = patientID;
            this.Date = date;
            this.DischargedDate = dischargedDate;
            this.HospitalizateDate = hospitalizateDate;
            this.PatientName = patientName;
        }

        // Mapping configuration
        [Obsolete]
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AssignmentDTO, AssignmentDTO>(); // Từ một đối tượng Assignment sang một đối tượng Assignment khác dựa trên AssignID.
                cfg.CreateMap<IDataReader, AssignmentDTO>() // Từ một đối tượng IDataReader (được trả về từ các phương thức SQL) sang một đối tượng Assignment.
                    .ForMember(dest => dest.AssignID, opt => opt.MapFrom(src => src["ASSIGNID"]))
                    .ForMember(dest => dest.PatientID, opt => opt.MapFrom(src => src["PATIENTID"]))
                    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src["DATE"]))
                    .ForMember(dest => dest.DischargedDate, opt => opt.MapFrom(src => src["DISCHARGEDDATE"]))
                    .ForMember(dest => dest.HospitalizateDate, opt => opt.MapFrom(src => src["HOPITALIZATEDATE"]))
                    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src["PATIENT NAME"]));

            });
        }            
        
        // Sử dụng AutoMapper để chuyển đổi từ DTO sang Entity
        public static Assignment ConvertDTOToEntity(AssignmentDTO assignmentDTO)
        {
            var assignment = Mapper.Map<AssignmentDTO, Assignment>(assignmentDTO);
            return assignment;
        }
        //Phương thức thêm
        public static int InsertAssignment(Assignment newAssignmet)
        {
            String sqlInsert = @"INSERT INTO    ASSIGNMENT (PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE)
                               ` VALUES         (@PATIENTID, @DATE,@DISCHARGEDDATE,@HOPITALIZATEDATE)";
            SqlParameter[] sqlParameters = {
                                            new SqlParameter("@PATIENTID", newAssignmet.PatientID),
                                            new SqlParameter("@DATE", newAssignmet.Date),
                                            new SqlParameter("@DISCHARGEDDATE", newAssignmet.DischargedDate),
                                            new SqlParameter("@HOPITALIZATEDATE", newAssignmet.HospitalizateDate)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }

        //Phương thức cập nhật
        public static int UpdateAssignment(Assignment updateAssignment)
        {
            string sqlUpdate = @"UPDATE       ASSIGNMENT
                                SET           DATE =@DATE, DISCHARGEDDATE =@DISCHARGEDDATE
                                WHERE         ASSIGNID =@ASSIGNID  ";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", updateAssignment.AssignID ),
                                            new SqlParameter("@DATE", updateAssignment.Date),
                                            new SqlParameter("@DISCHARGEDDATE", updateAssignment.DischargedDate)};
            return SqlResult.ExecuteNonQuery(sqlUpdate, sqlParameters);
        }

        //Phương thức xoá
        public static int DeleteAssignment(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENT
                                WHERE        (ASSIGNID=@ASSIGNID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignmentID) };
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        //Phương thức 
        public static List<Assignment> GetListAssignment()
        {
            List<Assignment> assignments = new List<Assignment>();
            string sqlSelect = @"SELECT        ASSIGNID, a.PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE, p.LASTNAME +' '+p.FIRSTNAME as 'PATIENT NAME'
                        FROM            ASSIGNMENT a join PATIENT p on a.PATIENTID = p.PATIENTID";
            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect);
            foreach (DataRow row in dataTable.Rows)
            {
                Assignment assignment = Mapper.Map<IDataReader, Assignment>(dataTable.CreateDataReader());
                assignments.Add(assignment);
            }
            return assignments; //trả về một danh sách các đối tượng Assignment.
        }

        public static Assignment GetAssignment(int assignID)
        {
            Assignment assign = new Assignment();
            string sqlSelect = @"SELECT        ASSIGNID, PATIENTID, DATE, DISCHARGEDDATE, HOPITALIZATEDATE
                                FROM           ASSIGNMENT
                                WHERE          ASSIGNID=@ASSIGNID";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignID) };
            DataTable dataTable = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);

            if (dataTable.Rows.Count > 0)
            {
                //sử dụng đối tượng IDataReader để đọc dữ liệu từ câu truy vấn SQL
                //dùng phương thức Mapper.Map để chuyển đổi dữ liệu từ đối tượng IDataReader sang đối tượng Assignment.

                assign.AssignID = Convert.ToInt32(dataTable.Rows[0][0]);
                assign.PatientID = Convert.ToInt32(dataTable.Rows[0][1]);
                assign.Date = (DateTime)dataTable.Rows[0][2];
                assign.DischargedDate = (DateTime)dataTable.Rows[0][3];
                assign.HospitalizateDate = (DateTime)dataTable.Rows[0][4];
                assign.PatientName = dataTable.Rows[0]["PATIENT NAME"].ToString();
            }
            return assign;
        }

        public static int GetCurrentIdentity()
        {
            string sqlSelect = @"SELECT IDENT_CURRENT('ASSIGNMENT')  as currIdent";
            object ob = SqlResult.ExecuteScalar(sqlSelect);
            return Convert.ToInt32(ob);
        }

        public static Boolean IsPatientHadAssignment(int patientID)
        {
            DataTable dtA = new DataTable();
            string sqlSelect = @"SELECT        ASSIGNID, DATE, HOPITALIZATEDATE, DISCHARGEDDATE, PATIENTID
                                FROM            ASSIGNMENT
                                WHERE        PATIENTID=@PATIENTID";
            SqlParameter[] sqlParameters = { new SqlParameter("@PATIENTID", patientID) };
            dtA = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            if (dtA.Rows.Count > 0)
                return true;
            return false;
        }
    }
}