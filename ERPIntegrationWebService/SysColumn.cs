using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class SysColumn
    {
        private string name;
        private string xtype;
        private string id;

        public SysColumn() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Xtype
        {
            get { return xtype; }
            set { xtype = value; }
        }
        
        
    }
}