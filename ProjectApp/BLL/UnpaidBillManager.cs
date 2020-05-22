using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;

namespace ProjectApp.BLL
{
    public class UnpaidBillManager
    {
        

        public List<UnpaidBillModel> GenerateUnpaidBill(string fromDate, string toDate)
        {
            UnpaidBillGateway aUnpaidBillGateway=new UnpaidBillGateway();

            return aUnpaidBillGateway.GenerateUnpaidBill(fromDate,toDate);
        }
    }
}