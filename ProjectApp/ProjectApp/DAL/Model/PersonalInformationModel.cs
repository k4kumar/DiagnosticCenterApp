using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.DAL.Model
{
    [Serializable]
    public class PersonalInformationModel
    {
  
        public int Id { get; set; }

        public double BillNumber { get; set; }

        public string PatientName { get; set; }

        public string BirthDate { get; set; }

        public string MobileNo { get; set; }

        public decimal TotalBill { get; set; }

        public string PatientEntryDate { get; set; }


    }
}