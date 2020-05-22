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
    public class ReportGaetway:Gateway
    {
        public List<TestNameModel> GetTestWiseReport(string fromDate,string toDate)
        {
            Query =@"
SELECT TestName,COUNT(PatientTest.TestId) AS TotalTest,Fee,COUNT(PatientTest.TestId)*Fee AS TotalAmount
FROM TestNameInfo LEFT JOIN PatientTest ON TestNameInfo.Id=PatientTest.TestId
WHERE PatientTest.DueDate
BETWEEN '"+fromDate+"' AND '"+toDate+"'GROUP BY TestName,Fee UNION ALL SELECT DISTINCT TestName, COUNT(PatientTest.TestId)*0 AS TotalTest,Fee,COUNT(PatientTest.TestId)*Fee*0 AS TotalAmount FROM TestNameInfo LEFT JOIN PatientTest ON TestNameInfo.Id=PatientTest.TestId  WHERE (PatientTest.DueDate is null OR PatientTest.DueDate NOT BETWEEN '"+fromDate+"' AND '"+toDate+"') And TestName NOT In (SELECT TestName FROM TestNameInfo LEFT JOIN PatientTest ON TestNameInfo.Id=PatientTest.TestId WHERE PatientTest.DueDate BETWEEN'"+fromDate+"' AND '"+toDate+"') GROUP BY  TestName,Fee";

            
                Command = new SqlCommand(Query, Connection);
            
            Connection.Open();
             List<TestNameModel> tests = new List<TestNameModel>();

            Reader = Command.ExecuteReader();
            
            while (Reader.Read())
            {
                TestNameModel test = new TestNameModel();
                test.TestName = Reader["TestName"].ToString();
                test.Fee = Convert.ToDecimal(Reader["Fee"]);
                test.TotalTest=(int)Reader["TotalTest"];
                test.TotalAmount=(decimal)Reader["Totalamount"];
                
                tests.Add(test);}
            
            Reader.Close();
            Connection.Close();

            return tests;

        }
    }
}