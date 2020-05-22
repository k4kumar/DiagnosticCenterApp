using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Model;

namespace ProjectApp.DAL.Gateway
{
    public class PaymentGateway:Gateway
    {
        public PersonalInformationModel SearchByBillNumber(double billNumber)
        {
            PersonalInformationModel aModel = new PersonalInformationModel();

            Query = "SELECT Contact, BillNo, TotalDue, DueDate FROM PaymentView WHERE BillNo ='" + billNumber + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                aModel.MobileNo = Reader["Contact"].ToString();
                aModel.TotalBill = Convert.ToDecimal(Reader["TotalDue"]);
                aModel.PatientEntryDate = Reader["DueDate"].ToString();
                aModel.BillNumber = Convert.ToDouble(Reader["BillNo"]);
            }

            Reader.Close();
            Connection.Close();

            return aModel;
        }

        public PersonalInformationModel SearchByMobile(string mobileNumber)
        {
            PersonalInformationModel aModel = new PersonalInformationModel();

            Query = "SELECT MAX(Contact) Contact,  SUM(TotalDue) AS TotalDue,  MAX(DueDate) DueDate FROM PaymentView WHERE Contact = '"+mobileNumber+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                aModel.MobileNo = Reader["Contact"].ToString();

                if (Reader["TotalDue"] == DBNull.Value)
                {
                    aModel.TotalBill = 0;
                }
                else
                {
                    aModel.TotalBill = Convert.ToDecimal(Reader["TotalDue"]);
                }
                
                aModel.PatientEntryDate = Reader["DueDate"].ToString();

            }

            Reader.Close();
            Connection.Close();

            return aModel;
        }

        public int PayByMobile(string mobileNumber)
        {
            Query = "UPDATE PatientInfo SET TotalDue = 0 WHERE Contact = '"+mobileNumber+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public int PayByBillNumber(double billNumber)
        {
            Query = "UPDATE PatientInfo SET TotalDue = 0 WHERE BillNo = '" + billNumber + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}