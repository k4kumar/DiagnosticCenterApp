using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.DAL.Gateway;
using ProjectApp.DAL.Model;
using ProjectApp.BLL;

namespace ProjectApp.UI
{
    public partial class TestSaveUI : System.Web.UI.Page
    {
        Testmanager aTestManager = new Testmanager();
        TypeManager aTypeManager = new TypeManager();
        TypeNameModel objModel;
        TestNameModel aTest;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<TypeNameModel> types = aTypeManager.GetAllTypes();
                testTypeDropDownList.DataSource = types;
                testTypeDropDownList.DataTextField = "TypeName";
                testTypeDropDownList.DataValueField = "Id";
                testTypeDropDownList.DataBind();
            }
          
            PopulateGridview();
        }

        private void PopulateGridview()
        {
            List<TestModelVM> types = aTestManager.GetAllTestVM();
            testNameGridView.DataSource = types;
            testNameGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestNameModel aTest = new TestNameModel();
            aTest.TestName = testNameTextBox.Text;
            aTest.Fee = Convert.ToDecimal(feeTextBox.Text);
            aTest.TypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            messageShowlabel.Text= aTestManager.SaveTest(aTest);


            List<TypeNameModel> types = aTypeManager.GetAllTypes();
            testTypeDropDownList.DataSource = types;
            testTypeDropDownList.DataTextField = "TypeName";
            testTypeDropDownList.DataValueField = "Id";
            testTypeDropDownList.DataBind();
            testTypeDropDownList.Items.Insert(0, new ListItem("--- Please Select ---", ""));

            testNameTextBox.Text = "";
            feeTextBox.Text = "";

            PopulateGridview();
        }
    }
}