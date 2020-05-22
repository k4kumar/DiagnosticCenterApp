using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ProjectApp.DAL.Model
{
    public class UnpaidBillModel
    {
        public int BillNo { get; set; }
		
        public string Contact { get; set; }
		
        public string PatientName { get; set; }
		
        public double BillAmount { get; set; }


    }
}