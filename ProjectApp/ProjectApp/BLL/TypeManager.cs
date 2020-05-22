using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;


namespace ProjectApp.BLL
{
    public class TypeManager
    {
        TypeGateway aGateway = new TypeGateway();
        public string Save(TypeNameModel type)
        {

            bool existsTypeName = aGateway.IsTestTypeExists(type.TypeName);

            if (existsTypeName)
            {
                return "Type Name exists already";
            }

            else
            {
                int rowAffected = aGateway.Save(type);

                if (rowAffected > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Saved failed";
                }
            }
        }

        public List<TypeNameModel> GetAllTypes()
        {
            return aGateway.GetAllTypes();
        }
    }
}