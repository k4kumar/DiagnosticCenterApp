using ProjectApp.DAL.Model;
using ProjectApp.DAL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectApp.BLL
{
    public class TypewiseReportManager
    {
        TypeWiseReportGateway aTypes = new TypeWiseReportGateway();

        public List<TypeNameModel> GetTypeWiseReport(string fromDate, string toDate)
        {

            return aTypes.GetTypeWiseReport(fromDate, toDate);

        }
    }
}