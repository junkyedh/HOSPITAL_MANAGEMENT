﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT_SOURCE.DTO
{
    public class MedicineDTO
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public MedicineDTO() { }

        public MedicineDTO(int medicineID, string medicineName, int quantity, decimal price)
        {
            MedicineID = medicineID;
            MedicineName = medicineName;
            Quantity = quantity;
            Price = price;
        }
    }
}
