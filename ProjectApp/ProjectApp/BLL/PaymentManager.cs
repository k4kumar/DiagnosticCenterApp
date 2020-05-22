using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Gateway;
using ProjectApp.DAL.Model;

namespace ProjectApp.BLL
{
    public class PaymentManager
    {
        PaymentGateway aPaymentGateway = new PaymentGateway();

        public PersonalInformationModel SearchByMobile(string mobileNumber)
        {
            return aPaymentGateway.SearchByMobile(mobileNumber);
        }

        public PersonalInformationModel SearchByBillNumber(double billNumber)
        {
            return aPaymentGateway.SearchByBillNumber(billNumber);
        }

        public string PayByMobile(string mobileNumber)
        {
            int rowAffected = aPaymentGateway.PayByMobile(mobileNumber);

            if (rowAffected > 0)
            {
                return "Bill paid successfully";
            }

            else
            {
                return "An error occured";
            }
        }

        public string PayByBillNumber(double billNumber)
        {
            int rowAffected = aPaymentGateway.PayByBillNumber(billNumber);

            if (rowAffected > 0)
            {
                return "Bill paid successfully";
            }

            else
            {
                return "An error occured";
            }
        }
    }
}