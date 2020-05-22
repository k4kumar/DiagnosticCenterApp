using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.DAL.Model;
using ProjectApp.BLL;

namespace ProjectApp.UI
{
    public partial class TestWiseReport : System.Web.UI.Page
    {
        ReportManager aReportManager = new ReportManager();
        TestNameModel test = new TestNameModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void PopulateGridview()
        {
            List<TestNameModel> types = aReportManager.GetTestWiseReport(test.fromDate,test.toDate);
            testWiseReportGridView.DataSource = types;
            testWiseReportGridView.DataBind();
        }
        protected void showButton_Click(object sender, EventArgs e)
        {

            
            test.fromDate =formDatePicker.Text;
          
            test.toDate = toDatePicker.Text;
           
            PopulateGridview();

            decimal totalAmount = 0; ;

             foreach (GridViewRow row in testWiseReportGridView.Rows)
             {
                 string total = ((Label)row.FindControl("totalLabel")).Text;
                 totalAmount += Convert.ToDecimal(total);
                 
             }

             totalAmountTextBox.Text = totalAmount.ToString();
        }
    }
}