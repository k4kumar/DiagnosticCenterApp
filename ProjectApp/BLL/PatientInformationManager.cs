using ProjectApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Gateway;

namespace ProjectApp.BLL
{
    public class PatientInformationManager
    {
        private bool MobileExists { get; set; }

        PersonalInformationGateway aGateway = new PersonalInformationGateway();
        public string SavePatientInfo(PersonalInformationModel person)
        {
          
            bool hasRows = aGateway.IsMobileExists(person.MobileNo);

            if (!hasRows)
            {
                int row = aGateway.SavePatientInfo(person);

                if (row > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Failed";
                }
            }

            else
            {
                MobileExists = true;
                return "Mobile Number exists already";
            }
        }

        public double GetBillNumber()
        {
            if (!MobileExists)
            {
                return aGateway.GetBillNumber();   
            }
            
            return 0;
        }


        public string SaveTestData(TestNameModel test)
        {
            if (!MobileExists)
            {
                int row = aGateway.SaveTestData(test);

                if (row > 0)
                {
                    return "Saved Succefully";
                }
                else
                {
                    return "Failed";
                }
            }

            return "Mobile number exists already";
        }
    }
}