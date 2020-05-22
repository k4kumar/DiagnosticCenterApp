using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjectApp.DAL.Model;


namespace ProjectApp.DAL.Gateway
{
    public class TestGateway:Gateway
    {
        public int SaveTest(TestNameModel test)
        {

            Query = "INSERT INTO TestNameInfo(TestName,Fee,TypeId) VALUES(@testName, @testFee, @testTypeId)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("testName", SqlDbType.VarChar);
            Command.Parameters["testName"].Value = test.TestName;

            Command.Parameters.Add("testFee", SqlDbType.Decimal);
            Command.Parameters["testFee"].Value = test.Fee;

            Command.Parameters.Add("testTypeId", SqlDbType.Int);
            Command.Parameters["testTypeId"].Value = test.TypeId;


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
        public List<TestNameModel> GetAllTest()
        {
            Query = "SELECT * FROM TestNameInfo ORDER BY TestName";
        

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            List<TestNameModel> tests = new List<TestNameModel>();

            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                TestNameModel test = new TestNameModel();
                test.Id = (int)Reader["Id"];
                test.TestName = Reader["TestName"].ToString();
                test.Fee = Convert.ToDecimal(Reader["Fee"]);
                test.TypeId = (int)Reader["TypeId"];

                tests.Add(test);}
            
            Reader.Close();
            Connection.Close();

            return tests;
        }

        
        public  List<TestModelVM> GetAllTestVM()
        {
            Query = "SELECT * FROM TestWithType ORDER BY TestName ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            List<TestModelVM> tests = new List<TestModelVM>();

            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TestModelVM test = new TestModelVM();
                test.TestName = Reader["TestName"].ToString();
                test.Fee = (Decimal)Reader["Fee"];
                test.TypeName = Reader["TypeName"].ToString();

                tests.Add(test);

            }
            Reader.Close();
            Connection.Close();

            return tests;

        }

        public List<TestNameModel> GetAllTestbyFee(int id)
        {
            Query = "SELECT * FROM TestNameInfo where TestNameInfo.Id= '" + id + "' ";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            List<TestNameModel> tests = new List<TestNameModel>();

            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {


                while (Reader.Read())
                {
                    TestNameModel test = new TestNameModel();
                    test.TestName = Reader["TestName"].ToString();
                    test.Fee = Convert.ToDecimal(Reader["Fee"]);

                    tests.Add(test);
                }
            }
            
            Reader.Close();
            Connection.Close();

            return tests ;
        }

        public bool IsTestNameExists(string testName)
        {

            Query = "SELECT * FROM TestNameInfo WHERE TestName = @testName";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("testName", SqlDbType.VarChar);
            Command.Parameters["testName"].Value = testName;

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

    }
}