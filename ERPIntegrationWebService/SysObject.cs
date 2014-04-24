using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class SysObject
    {//hej
        private string id;
        private string name;
        private string xtype;

        
        public SysObject(){}

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
 

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}