using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Text;
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

            fromDateHidden.Value = fromDateTextBox.Text;
            toDateHidden.Value = toDateTextBox.Text;

            totalTextBox.Text = total + "";
        }

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }
        protected void pdfButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateHidden.Value;
            string toDate = toDateHidden.Value;


            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Unpaid Bill Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);



            Paragraph heading = new Paragraph("People's Care Diagnostic Center\n\n");
            heading.Alignment = Element.ALIGN_CENTER;


            Paragraph fromDatePara = new Paragraph("From Date: " + fromDate + "\n\n");
            Paragraph toDatePara = new Paragraph("To Date: " + toDate + "\n\n\n");
            Paragraph header = new Paragraph(" Testwise Report\n\n\n");

            fromDatePara.Alignment = Element.ALIGN_LEFT;
            toDatePara.Alignment = Element.ALIGN_LEFT;
            header.Alignment = Element.ALIGN_CENTER;



            unpaidBillGridView.RenderControl(hw);
            unpaidBillGridView.HeaderRow.Style.Add("width", "50%");
            unpaidBillGridView.HeaderRow.Style.Add("font-size", "20pt");
            unpaidBillGridView.Style.Add("font-family", "Arial,Helvetica,sans-serif");
            unpaidBillGridView.Style.Add("font-size", "14pt");
            unpaidBillGridView.CellPadding = 5;

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);


            pdfDoc.Open();

            pdfDoc.Add(heading);
            pdfDoc.Add(header);
            pdfDoc.Add(fromDatePara);
            pdfDoc.Add(toDatePara);


            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);

            string today =  DateTime.Today.ToString("yyyy-MM-dd");

            Paragraph note = new Paragraph("\n\n\nReport Generated on : "+today);
            note.Alignment = Element.ALIGN_LEFT;
            pdfDoc.Add(note);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

            unpaidBillGridView.AllowPaging = false;
            unpaidBillGridView.DataBind();

        }
    }
}