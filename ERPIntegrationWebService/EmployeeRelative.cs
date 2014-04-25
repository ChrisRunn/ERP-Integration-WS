using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class EmployeeRelative
    {
        private string relativeCode;
        private string firstName;

        public EmployeeRelative() { }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string RelativeCode
        {
            get { return relativeCode; }
            set { relativeCode = value; }
        }

    }
}