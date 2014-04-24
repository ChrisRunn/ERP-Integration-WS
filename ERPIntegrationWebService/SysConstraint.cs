using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;//hej

namespace ERPIntegrationWebService
{
    public class SysConstraint
    {
        private string constid;
        private string id;

        public SysConstraint() { }

        public string Constid
        {
            get { return constid; }
            set { constid = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}