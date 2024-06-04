using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class MaterialDTO
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public MaterialDTO() { }

        public MaterialDTO(int materialID, string materialName, int quantity, decimal price)
        {
            MaterialID = materialID;
            MaterialName = materialName;
            Quantity = quantity;
            Price = price;
        }

    }
}
