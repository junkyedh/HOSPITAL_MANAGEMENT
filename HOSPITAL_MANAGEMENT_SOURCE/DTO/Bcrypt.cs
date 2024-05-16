using AutoMapper;
using HOSPITAL_MANAGEMENT_SOURCE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    internal class BcryptDTO
    {
        public string Input { get; set; }
        public string Hash { get; set; }
    }

    // Mapping Profile cho AutoMapper
    public class BcryptProfile : Profile
    {
        public BcryptProfile()
        {
            CreateMap<BcryptDTO, Bcrypt>(); // Mapping từ DTO sang Model
        }
    }
}
