using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.BLL;
using ProjectApp.DAL.Model;



namespace ProjectApp.UI
{
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            UnpaidBillManager aUnpaidBillManager = new UnpaidBillManager();
            List<UnpaidBillModel> unpaidBillModels = aUnpaidBillManager.GenerateUnpaidBill(fromDate, toDate);
            
            double total = unpaidBillModels.Sum(aUnpaidBillModel => aUnpaidBillModel.BillAmount);

            unpaidBillGridView.DataSource = unpaidBillModels;
            unpaidBillGridView.DataBind();

            totalTextBox.Text = total + "";
        }

        
    }
}