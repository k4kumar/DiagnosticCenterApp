using ProjectApp.BLL;
using ProjectApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using ListItem = System.Web.UI.WebControls.ListItem;

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

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //base.VerifyRenderingInServerForm(control);
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

        }

        protected void testSelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = aTestManager.GetAllTestbyFee(Convert.ToInt32(testSelectDropDownList.SelectedValue));

            feeTextBox.Text = test[0].Fee.ToString();
        }



        protected void testSelectGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        PatientInformationManager aManager = new PatientInformationManager();

        PersonalInformationModel person = new PersonalInformationModel();

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestNameModel test = new TestNameModel();

            person.PatientName = patientNameTextBox.Text;
            person.BirthDate = datepicker.Value;
            person.MobileNo = mobileNoTextBox.Text;
            person.TotalBill = Convert.ToDecimal(totalTextBox.Text);
            person.PatientEntryDate = DateTime.Today.ToString("yyyy-MM-dd");
            
            messageShowlabel.Text = aManager.SavePatientInfo(person);

            
            List<TestNameModel> types = aTestManager.GetAllTypes();

            testSelectDropDownList.DataSource = types;
            testSelectDropDownList.DataTextField = "TestName";
            testSelectDropDownList.DataValueField = "Id";
            testSelectDropDownList.DataBind();

            testSelectDropDownList.Items.Insert(0, new ListItem("--- Please Select ---", ""));

            test.EntryDate = DateTime.Today.ToString("yyyy-MM-dd");

            foreach (GridViewRow row in testSelectGridView.Rows)
            {
                test.TestName = ((Label)row.FindControl("nameLabel")).Text;
                test.Fee = Convert.ToDecimal(((Label)row.FindControl("feeLabel")).Text);
                aManager.SaveTestData(test);

            }
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            person.BillNumber = aManager.GetBillNumber();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Patients' Test Request Entry - " + person.BillNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);



            Paragraph heading = new Paragraph("People's Care Diagnostic Center\n\n");
            heading.Alignment = Element.ALIGN_CENTER;


            Paragraph header = new Paragraph(" Patients' Entry Info\n\n\n");
            header.Alignment = Element.ALIGN_CENTER;

            person.PatientName = patientNameTextBox.Text;
            person.BirthDate = datepicker.Value;
            person.MobileNo = mobileNoTextBox.Text;
            person.TotalBill = Convert.ToDecimal(totalTextBox.Text);

            messageShowlabel.Text = "PDF Generated";


            Paragraph billNumber = new Paragraph("Bill No.:  " + person.BillNumber + "\n\n");
            Paragraph patientName = new Paragraph("Patient's Name : " + person.PatientName + "\n\n");
            Paragraph birthDate = new Paragraph("Birth Date : " + person.BirthDate + "\n\n");
            Paragraph contactNumber = new Paragraph("Contact Number : " + person.MobileNo + "\n\n");
            Paragraph totalBill = new Paragraph("\n\n\nTotal Bill : " + person.TotalBill + "\n\n");

            billNumber.Alignment = Element.ALIGN_LEFT;
            patientName.Alignment = Element.ALIGN_LEFT;
            birthDate.Alignment = Element.ALIGN_LEFT;
            contactNumber.Alignment = Element.ALIGN_LEFT;
            totalBill.Alignment = Element.ALIGN_LEFT;


            testSelectGridView.RenderControl(hw);
            testSelectGridView.HeaderRow.Style.Add("width", "50%");
            testSelectGridView.HeaderRow.Style.Add("font-size", "20pt");
            testSelectGridView.Style.Add("font-family", "Arial,Helvetica,sans-serif");
            testSelectGridView.Style.Add("font-size", "14pt");
            testSelectGridView.CellPadding = 5;

            

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            


            pdfDoc.Open();

            pdfDoc.Add(heading);
            pdfDoc.Add(header);
            pdfDoc.Add(billNumber);
            pdfDoc.Add(patientName);
            pdfDoc.Add(birthDate);
            pdfDoc.Add(contactNumber);

            



            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            pdfDoc.Add(totalBill);

            string today = DateTime.Today.ToString("yyyy-MM-dd");

            Paragraph note = new Paragraph("\n\nRequest Entry Date : " + today);
            note.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(note);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

            testSelectGridView.AllowPaging = false;
            testSelectGridView.DataBind();

        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            patientNameTextBox.Text = "";
            datepicker.Value = "";
            mobileNoTextBox.Text = "";
            totalTextBox.Text = "0.00";
            feeTextBox.Text = "0";
            messageShowlabel.Text = "";

            List<TestNameModel> testNameModels = new List<TestNameModel>();

            testSelectGridView.DataSource = testNameModels;
            testSelectGridView.DataBind();

            ViewState["Test"] = testNameModels;
        }
    }
}


