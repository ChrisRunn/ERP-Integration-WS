﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPIntegrationWebService
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private string employeeNo;

        public Employee() { }

        public string EmployeeNo
        {
            get { return employeeNo; }
            set { employeeNo = value; }
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