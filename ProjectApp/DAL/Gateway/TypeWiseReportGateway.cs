using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ProjectApp.DAL.Gateway
{
    public class TypeWiseReportGateway:Gateway
    {
        public List<TypeNameModel> GetTypeWiseReport(string fromDate, string toDate)
        {
            Query = @"SELECT TypeName,COUNT(TestNameInfo.TypeId) AS TotalTest, COUNT(TestNameInfo.TypeId) *Fee AS TotalAmount
                    FROM TestType 
                    LEFT JOIN TestNameInfo ON TestType.Id=TestNameInfo.TypeId 
                    LEFT JOIN PatientTest ON TestNameInfo.Id=PatientTest.TestId 
                    Where DueDate Between '"+fromDate+"' AND '"+toDate+"' GROUP BY Typename, Fee UNION ALL "+
                    "SELECT TypeName,COUNT(TestNameInfo.TypeId)*0 AS TotalTest, COUNT(TestNameInfo.TypeId) *Fee*0 AS TotalAmount " + 
                    "FROM TestType LEFT JOIN TestNameInfo ON TestType.Id=TestNameInfo.TypeId LEFT JOIN PatientTest ON TestNameInfo.Id=PatientTest.TestId "+
                    "where (PatientTest.DueDate is null OR PatientTest.DueDate NOT BETWEEN '" + fromDate + "' AND '" + toDate + "') " + 
                    "AND TypeName NOT IN (SELECT TypeName FROM TestType LEFT JOIN TestNameInfo ON TestType.Id=TestNameInfo.TypeId " +
                    "LEFT JOIN PatientTest ON TestNameInfo.Id=PatientTest.TestId WHERE PatientTest.DueDate NOT BETWEEN '" + fromDate + "' AND '" + toDate + "') " +
                    "GROUP BY Typename, Fee";
            

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            List<TypeNameModel> types = new List<TypeNameModel>();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                TypeNameModel test = new TypeNameModel();
                test.TypeName = Reader["TypeName"].ToString();
                test.NumberOfTests = Convert.ToInt32(Reader["TotalTest"]);

                if (Reader["TotalAmount"] == DBNull.Value)
                {
                    test.TotalAmount = 0;
                }

                else
                {
                    test.TotalAmount = Convert.ToDouble(Reader["TotalAmount"]);
                }

                types.Add(test);
            }

            Reader.Close();
            Connection.Close();

            return types;
        }


    }
}