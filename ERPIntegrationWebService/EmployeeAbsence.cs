using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class EmployeeAbsence
    {
        private string description;
        private string casueOfAbsenceCode;

        public EmployeeAbsence() { }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string CasueOfAbsenceCode
        {
            get { return casueOfAbsenceCode; }
            set { casueOfAbsenceCode = value; }
        }

    }
}