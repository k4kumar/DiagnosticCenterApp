using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectApp.DAL.Model
{
    [Serializable]
    public class TestModelVM
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public Decimal Fee { get; set; }
        public string TypeName { get; set; }

    }
}