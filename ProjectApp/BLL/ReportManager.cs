using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;
namespace ProjectApp.BLL
{
    public class ReportManager
    {
        ReportGaetway aGateway = new ReportGaetway();



        public List<TestNameModel> GetTestWiseReport(string fromDate, string toDate)
        {
            return aGateway.GetTestWiseReport(fromDate, toDate);
        }

    }
}