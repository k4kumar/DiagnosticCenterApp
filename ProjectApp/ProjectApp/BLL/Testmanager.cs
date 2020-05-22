using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;

namespace ProjectApp.BLL
{
    public class Testmanager
    {
        TestGateway aGateway = new TestGateway();
        public string SaveTest(TestNameModel test)
        {

            bool existsTestName = aGateway.IsTestNameExists(test.TestName);

            if (existsTestName)
            {
                return "Test Name exists already";
            }

            else
            {
                int row = aGateway.SaveTest(test);
                if (row > 0)
                {
                    return "Saved Succefully";
                }
                else
                {
                    return "Failed";
                }
            }
        }

        public List<TestNameModel> GetAllTypes()
        {
            return aGateway.GetAllTest();
        }
      

        public List<TestModelVM> GetAllTestVM()
        {
            return aGateway.GetAllTestVM();
        }
        public List<TestNameModel> GetAllTestbyFee(int id)
        {
          return  aGateway.GetAllTestbyFee( id);
        }
    }
}