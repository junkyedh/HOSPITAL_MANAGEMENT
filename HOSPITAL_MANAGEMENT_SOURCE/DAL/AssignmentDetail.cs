using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HOSPITAL_MANAGEMENT_SOURCE.DTO;

namespace HOSPITAL_MANAGEMENT_SOURCE.DAL
{
    internal class AssignmentDetail
    {

        public int AssignID { get; set; }
        public int StaffID { get; set; }

        public AssignmentDetail() { }
        public AssignmentDetail(int assignID, int staffID)
        {
            this.AssignID = assignID;
            this.StaffID = staffID;
        }
        // Mapping configuration
        public static void ConfigureMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AssignmentDetailDTO, AssignmentDetailDTO>(); // Từ một đối tượng Assignment sang một đối tượng Assignment khác dựa trên AssignID.
                cfg.CreateMap<IDataReader, AssignmentDetailDTO>() // Từ một đối tượng IDataReader (được trả về từ các phương thức SQL) sang một đối tượng Assignment.
                    .ForMember(dest => dest.AssignID, opt => opt.MapFrom(src => src["ASSIGNID"]))
                    .ForMember(dest => dest.StaffID, opt => opt.MapFrom(src => src["STAFID"]));

            });
        }

        // Sử dụng AutoMapper để chuyển đổi từ DTO sang Entity
        public static AssignmentDetail ConvertDTOToEntity(AssignmentDetailDTO assignmentDetailDTO)
        {
            var assignmentDetail = Mapper.Map<AssignmentDetailDTO, AssignmentDetail>(assignmentDetailDTO);
            return assignmentDetail;
        }

        public static int InsertAssignmentDetails(AssignmentDetail newAD)
        {
            String sqlInsert = @"INSERT INTO ASSIGNMENTDETAIL(ASSIGNID, STAFFID)
                                VALUES        (@ASSIGNID,@STAFFID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", newAD.AssignID),
                                            new SqlParameter("@STAFFID", newAD.StaffID)};
            return SqlResult.ExecuteNonQuery(sqlInsert, sqlParameters);
        }
        public static int DeleteAssignmentDetails(AssignmentDetail deleteAD)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENTDETAIL
                                WHERE        (ASSIGNID=@ASSIGNID AND STAFFID=@STAFFID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", deleteAD.AssignID),
                                                 new SqlParameter("@STAFFID", deleteAD.StaffID)};
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static int DeleteAssignmentDetails(int assignmentID)
        {
            string sqlDelete = @"DELETE FROM ASSIGNMENTDETAIL
                                WHERE        (ASSIGNID=@ASSIGNID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignmentID) };
            return SqlResult.ExecuteNonQuery(sqlDelete, sqlParameters);
        }
        public static List<AssignmentDetailDTO> GetListAssignmentDetails(int assignmentID)
        {
            List<AssignmentDetailDTO> list = new List<AssignmentDetailDTO>();
            string sqlSelect = @"SELECT        ASSIGNMENTDETAIL.ASSIGNID, ASSIGNMENTDETAIL.STAFFID, STAFF.LASTNAME, STAFF.FIRSTNAME
                                FROM            ASSIGNMENTDETAIL INNER JOIN STAFF ON ASSIGNMENTDETAIL.STAFFID = STAFF.STAFFID
                                WHERE        (ASSIGNMENTDETAIL.ASSIGNID=@ASSIGNID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@ASSIGNID", assignmentID) };
            DataTable dtAD = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);
            dtAD.Columns[0].ColumnName = "Mã phân công";
            dtAD.Columns[1].ColumnName = "Mã nhân viên";
            dtAD.Columns[2].ColumnName = "Họ nhân viên";
            dtAD.Columns[3].ColumnName = "Tên nhân viên";
            // Use AutoMapper to convert DataTable to List<AssignmentDetailDTO>
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataRow, AssignmentDetailDTO>()
                    .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src["Họ nhân viên"] + " " + src["Tên nhân viên"]));
            });
            var mapper = config.CreateMapper();
            list = mapper.Map<DataTable, List<AssignmentDetailDTO>>(dtAD);

            return list;
        }
    }
}
