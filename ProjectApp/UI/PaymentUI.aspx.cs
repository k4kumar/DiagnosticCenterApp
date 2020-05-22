using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.BLL;
using ProjectApp.DAL.Model;

namespace ProjectApp.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           billNoTextBox.Attributes.Add("onkeyup", "ClearMobile();");
           billNoTextBox.Attributes.Add("onfocus", "LoadBill();");
           mobileNoTextBox.Attributes.Add("onkeyup", "ClearBill();");
           mobileNoTextBox.Attributes.Add("onfocus", "LoadMobile();");
 
        }

        PaymentManager aPaymentManager = new PaymentManager();

        protected void searchButton_Click(object sender, EventArgs e)
        {
            PersonalInformationModel aPerson = new PersonalInformationModel();

            string hiddenMessage = hideSomething.Value;

            if (hiddenMessage == "Bill")
            {
                aPerson.BillNumber = Convert.ToDouble(billNoTextBox.Text);

                aPerson = aPaymentManager.SearchByBillNumber(aPerson.BillNumber);

                amountTextBox.Text = aPerson.TotalBill.ToString();
                dueDateTextBox.Text = aPerson.PatientEntryDate;
                hideObject.Value = aPerson.BillNumber.ToString();

            }

            else
            {
                aPerson.MobileNo = mobileNoTextBox.Text;

                aPerson = aPaymentManager.SearchByMobile(aPerson.MobileNo);

                amountTextBox.Text = aPerson.TotalBill.ToString();
                dueDateTextBox.Text = aPerson.PatientEntryDate;
                hideObject.Value = aPerson.MobileNo;

            }


            if (aPerson.TotalBill == 0)
            {
                payButton.Enabled = false;
            }

            else
            {
                payButton.Enabled = true;
            }

            messageLabel.Text = "";

        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            PersonalInformationModel aPerson = new PersonalInformationModel();

            string payMessage = hideSomething.Value;

            if (payMessage == "Bill")
            {
                aPerson.BillNumber = Convert.ToDouble(hideObject.Value);

                messageLabel.Text = aPaymentManager.PayByBillNumber(aPerson.BillNumber);

            }

            else
            {
                aPerson.MobileNo = hideObject.Value;

                messageLabel.Text = aPaymentManager.PayByMobile(aPerson.MobileNo);
            }
        }
    }
}