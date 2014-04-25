using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class EmpSick
    {
        private string description;
        private string casueOfAbsenceCode;
        private string firstName;
        private string lastName;

        public EmpSick() { }


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

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}