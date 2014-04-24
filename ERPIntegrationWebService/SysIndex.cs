using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class SysIndex
    {

        private string id;
        private string status;

        public SysIndex() { }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}