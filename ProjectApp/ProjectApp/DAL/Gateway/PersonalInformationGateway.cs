using ProjectApp.DAL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectApp.DAL.Gateway
{
    public class PersonalInformationGateway:Gateway
    {
        public int SavePatientInfo(PersonalInformationModel person)
        {
            Query = "SELECT COUNT(BillNo) AS Count FROM PatientInfo";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            int countRows = 0;

            while (Reader.Read())
            {
                countRows = Convert.ToInt32(Reader["Count"]);
            }

            Reader.Close();
            Connection.Close();

            if (countRows > 0)
            {
                Query =
                    " declare @BillNo int  set @BillNo= 1 + ( select max(PatientInfo.BillNo) from PatientInfo) INSERT INTO PatientInfo VALUES( @BillNo, @patientName, @contact, @dob, @totalDue)";
            }

            else
            {
                Query = "INSERT INTO PatientInfo VALUES( '443300001', @patientName, @contact, @dob, @totalDue)";
            }
            

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("patientName", SqlDbType.VarChar);
            Command.Parameters["patientName"].Value = person.PatientName;

            Command.Parameters.Add("contact", SqlDbType.VarChar);
            Command.Parameters["contact"].Value = person.MobileNo;

            Command.Parameters.Add("dob", SqlDbType.DateTime);
            Command.Parameters["dob"].Value = person.BirthDate;

            Command.Parameters.Add("totalDue", SqlDbType.Decimal);
            Command.Parameters["totalDue"].Value = person.TotalBill;


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsMobileExists(string mobileNumber)
        {

            Query = "SELECT * FROM PatientInfo WHERE Contact = '" + mobileNumber + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.HasRows)
            {
                hasRows = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public int SaveTestData(TestNameModel test)
        {
            PersonalInformationModel aInformationModel = new PersonalInformationModel();


            aInformationModel.Id = GetPatientTestId();
            test.Id = GetTestId(test);

            Query = "INSERT INTO PatientTest VALUES (@patientId, @testId, @entryDate)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("patientId", SqlDbType.Int);
            Command.Parameters["patientId"].Value = aInformationModel.Id;


            Command.Parameters.Add("testId", SqlDbType.Int);
            Command.Parameters["testId"].Value = test.Id;


            Command.Parameters.Add("entryDate", SqlDbType.Date);
            Command.Parameters["entryDate"].Value = test.EntryDate;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public int GetPatientTestId()
        {
         
            Query = "SELECT MAX(Id) AS maxId FROM PatientInfo";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            int patientId=0;

            while (Reader.Read())
            {
                patientId = Convert.ToInt32(Reader["maxId"]);
            }

            Reader.Close();
            Connection.Close();

            return patientId;
        }

        public int GetTestId(TestNameModel test)
        {
            Query = "SELECT Id AS Testid FROM TestNameInfo WHERE TestName = @testName";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("testName", SqlDbType.VarChar);
            Command.Parameters["testName"].Value = test.TestName;

            Connection.Open();

            Reader = Command.ExecuteReader();

            int testId = 0;

            while (Reader.Read())
            {
                testId = Convert.ToInt32(Reader["Testid"]);
            }

            Reader.Close();
            Connection.Close();

            return testId;
        }
    }
}