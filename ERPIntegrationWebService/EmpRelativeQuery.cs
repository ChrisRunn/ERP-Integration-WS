using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class EmpRelativeQuery
    {
        private string relFirstName;
        private string relativeCode;
        private string empFirstName;
        private string empLastName;

        public EmpRelativeQuery() { }

        public string RelFirstName
        {
            get { return relFirstName; }
            set { relFirstName = value; }
        }

        public string EmpFirstName
        {
            get { return empFirstName; }
            set { empFirstName = value; }
        }


        public string EmpLastName
        {
            get { return empLastName; }
            set { empLastName = value; }
        }
        
        public string RelativeCode
        {
            get { return relativeCode; }
            set { relativeCode = value; }
        }
   

   
    }
}