using ProjectApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjectApp.DAL.Gateway
{
    public class TypeGateway:Gateway
    {
        public int Save(TypeNameModel type)
        {
            
            Query = "INSERT INTO TestType VALUES(@typeName)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("typeName", SqlDbType.VarChar);
            Command.Parameters["typeName"].Value = type.TypeName;


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<TypeNameModel> GetAllTypes()
        {
            Query = "SELECT * FROM TestType ORDER BY TypeName";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            List<TypeNameModel> types = new List<TypeNameModel>();

            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                TypeNameModel type = new TypeNameModel();
                type.TypeName = Reader["TypeName"].ToString();
                type.Id =(Int32) Reader["Id"];
                types.Add(type);
            }

            Reader.Close();
            Connection.Close();

            return types;
        }

        public bool IsTestTypeExists(string typeName)
        {

            Query = "SELECT * FROM TestType WHERE TypeName = @typeName";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("typeName", SqlDbType.VarChar);
            Command.Parameters["typeName"].Value = typeName;

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