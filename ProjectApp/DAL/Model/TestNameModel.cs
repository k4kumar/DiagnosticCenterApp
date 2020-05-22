using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.DAL.Model
{
    [Serializable]
    public class TestNameModel
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public decimal Fee { get; set; }
        public int TypeId { get; set; }
        public string EntryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalTest { get; set; }
        public string toDate { get; set; }
        public string fromDate { get; set; }
    }
}