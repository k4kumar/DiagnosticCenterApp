using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Model;

namespace ProjectApp.DAL.Gateway
{
    public class UnpaidBillGateway:Gateway
    {
        public List<UnpaidBillModel> GenerateUnpaidBill(string fromDate, string toDate)
        {
            List<UnpaidBillModel> aUnpaidBillModelList=new List<UnpaidBillModel>();

            Query = "SELECT BillNo, Contact, PatientName, TotalDue FROM UnpaidBills WHERE DueDate BETWEEN '" + fromDate + "' AND '" + toDate + "' ";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                UnpaidBillModel aUnpaidBillModel=new UnpaidBillModel();
                aUnpaidBillModel.BillNo =(int) Reader["BillNo"];
                aUnpaidBillModel.Contact = Reader["Contact"].ToString();
                aUnpaidBillModel.PatientName = Reader["PatientName"].ToString();
                aUnpaidBillModel.BillAmount = Convert.ToDouble(Reader["TotalDue"]);
                aUnpaidBillModelList.Add(aUnpaidBillModel);
            }
            Reader.Close();
            Connection.Close();
            return aUnpaidBillModelList;
        } 
    }
}