using ProjectApp.BLL;
using ProjectApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectApp.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        Testmanager aTestManager = new Testmanager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<TestNameModel> types = aTestManager.GetAllTypes();

                testSelectDropDownList.DataSource = types;
                testSelectDropDownList.DataTextField = "TestName";
                testSelectDropDownList.DataValueField = "Id";
                testSelectDropDownList.DataBind();

                totalTextBox.Text = "0.00";
                testSelectDropDownList.Items.Insert(0, new ListItem("--- Please Select ---", ""));
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            TestNameModel name = new TestNameModel();

            List<TestNameModel> test = new List<TestNameModel>();

            
                if (ViewState["Test"] != null)
                {
                    test = (List<TestNameModel>)ViewState["Test"];
                    name.TestName = testSelectDropDownList.SelectedItem.Text;
                    name.Fee = Convert.ToDecimal(feeTextBox.Text);
                    test.Add(name);
                    testSelectGridView.DataSource = test;
                    testSelectGridView.DataBind();

                    totalTextBox.Text = (Convert.ToDecimal(feeTextBox.Text) + Convert.ToDecimal(totalTextBox.Text)).ToString();
                }

                else
                {
                    name.TestName = testSelectDropDownList.SelectedItem.Text;
                    name.Fee = Convert.ToDecimal(feeTextBox.Text);
                    test.Add(name);
                    testSelectGridView.DataSource = test;
                    testSelectGridView.DataBind();

                    totalTextBox.Text = (Convert.ToDecimal(feeTextBox.Text) + Convert.ToDecimal(totalTextBox.Text)).ToString();
                }

            ViewState["Test"] = test;


            string added = "added";

            ViewState["message"] = added;
        }

        protected void testSelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = aTestManager.GetAllTestbyFee(Convert.ToInt32(testSelectDropDownList.SelectedValue));

            feeTextBox.Text = test[0].Fee.ToString();
        }



        protected void testSelectGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

       
        protected void saveButton_Click(object sender, EventArgs e)
        {
            PatientInformationManager aManager = new PatientInformationManager();

            PersonalInformationModel person = new PersonalInformationModel();

            TestNameModel test = new TestNameModel();

            person.PatientName = patientNameTextBox.Text;
            person.BirthDate = datepicker.Value;
            person.MobileNo = mobileNoTextBox.Text;
            person.TotalBill = Convert.ToDecimal(totalTextBox.Text);
            person.PatientEntryDate = DateTime.Today.ToString("yyyy-MM-dd");
            
            messageShowlabel.Text = aManager.SavePatientInfo(person);

            List<TestNameModel> aTestNameModels = new List<TestNameModel>();

            testSelectGridView.DataSource = aTestNameModels;
            testSelectGridView.DataBind();

            List<TestNameModel> types = aTestManager.GetAllTypes();

            testSelectDropDownList.DataSource = types;
            testSelectDropDownList.DataTextField = "TestName";
            testSelectDropDownList.DataValueField = "Id";
            testSelectDropDownList.DataBind();


            totalTextBox.Text = "0.00";
            testSelectDropDownList.Items.Insert(0, new ListItem("--- Please Select ---", ""));

            test.EntryDate = DateTime.Today.ToString("yyyy-MM-dd");


            foreach (GridViewRow row in testSelectGridView.Rows)
            {
                test.TestName = ((Label)row.FindControl("nameLabel")).Text;
                test.Fee = Convert.ToDecimal(((Label)row.FindControl("feeLabel")).Text);
                aManager.SaveTestData(test);
            }

            patientNameTextBox.Text = "";
            datepicker.Value = "";
            mobileNoTextBox.Text = "";
            totalTextBox.Text = "";
            feeTextBox.Text = "";
          
        }
    }
}


