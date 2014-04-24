using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class SysTable
    {
        private string name;

        public SysTable() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}