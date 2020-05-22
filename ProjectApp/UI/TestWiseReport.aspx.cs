using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Text;
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
            List<TestNameModel> types = aReportManager.GetTestWiseReport(test.fromDate, test.toDate);
            testWiseReportGridView.DataSource = types;
            testWiseReportGridView.DataBind();
        }
        protected void showButton_Click(object sender, EventArgs e)
        {


            test.fromDate = formDatePicker.Text;

            test.toDate = toDatePicker.Text;

            fromDateHidden.Value = formDatePicker.Text;
            toDateHidden.Value = toDatePicker.Text;

            PopulateGridview();

            decimal totalAmount = 0; ;

            foreach (GridViewRow row in testWiseReportGridView.Rows)
            {
                string total = ((Label)row.FindControl("totalLabel")).Text;
                totalAmount += Convert.ToDecimal(total);

            }

            totalAmountTextBox.Text = totalAmount.ToString();
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateHidden.Value;
            string toDate = toDateHidden.Value;


            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestWise Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);


            Paragraph heading = new Paragraph("People's Care Diagnostic Center\n\n");
            heading.Alignment = Element.ALIGN_CENTER;

            Paragraph fromDatePara = new Paragraph("From Date: " + fromDate + "\n\n");
            Paragraph toDatePara = new Paragraph("To Date: " + toDate + "\n\n");
            Paragraph header = new Paragraph(" Testwise Report\n\n\n");

            fromDatePara.Alignment = Element.ALIGN_LEFT;
            toDatePara.Alignment = Element.ALIGN_LEFT;
            header.Alignment = Element.ALIGN_CENTER;



            testWiseReportGridView.RenderControl(hw);
            testWiseReportGridView.HeaderRow.Style.Add("width", "50%");
            testWiseReportGridView.HeaderRow.Style.Add("font-size", "20pt");
            testWiseReportGridView.Style.Add("font-family", "Arial,Helvetica,sans-serif");
            testWiseReportGridView.Style.Add("font-size", "14pt");
            testWiseReportGridView.CellPadding = 5;

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);


            pdfDoc.Open();

            pdfDoc.Add(heading);
            pdfDoc.Add(header);
            pdfDoc.Add(fromDatePara);
            pdfDoc.Add(toDatePara);


            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

            string today = DateTime.Today.ToString("yyyy-MM-dd");

            Paragraph note = new Paragraph("\n\n\nReport Generated on : " + today);
            note.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(note);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

            testWiseReportGridView.AllowPaging = false;
            testWiseReportGridView.DataBind();
        }
    }
}