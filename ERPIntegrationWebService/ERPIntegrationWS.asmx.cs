using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace ERPIntegrationWebService
{
    /// <summary>
    /// Summary description for ERPIntegrationWS
    /// </summary>
    [WebService(Namespace = "http://brokerapplication.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ERPIntegrationWS : System.Web.Services.WebService
    {
        DAL dal = new DAL();

        #region Select, Update, Delete, Insert
        [WebMethod(Description = "Inserts new employee", EnableSession = false)]
        public void InsertEmployee(string no, string firstName, string lastName)
        {
            dal.InsertEmployee(no, firstName, lastName);
        }

        [WebMethod(Description = "Updates employee", EnableSession = false)]
        public void UpdateEmployee(string no, string firstName, string lastName)
        {
            dal.UpdateEmployee(no, firstName, lastName);
        }

        [WebMethod(Description = "Deletes employee", EnableSession = false)]
        public void DeleteEmployee(string no)
        {
            dal.DeleteEmployee(no);
        }

        [WebMethod(Description = "Shows a specific employee", EnableSession = false)]
        public List<Employee> showAllEmployees()
        {
            return dal.showAllEmployees();
        }

        #endregion Select, Update, Delete, Insert

        #region Uppgift A

        [WebMethod(Description = "Shows all employees and metadata", EnableSession = false)]
        public List<SysObject> GetEmployeeAndMetaData()
        {
            return dal.GetEmployeeAndMetaData();
        }

        [WebMethod(Description = "Shows all employees and relatives", EnableSession = false)]
        public List<EmpRelativeQuery> GetEmployeeAndRelatives()
        {
            return dal.GetEmployeeAndRelatives();
        }

        [WebMethod(Description = "Shows all sick employees", EnableSession = false)]
        public List<EmpSick> GetSickEmployee()
        {
            return dal.GetSickEmployee();
        }

        [WebMethod(Description = "Shows most sick employees", EnableSession = false)]
        public List<EmpSick> GetMostSickEmployee()
        {
            return dal.GetMostSickEmployee();
        }
        #endregion Uppgift A

        #region Uppgift B

        [WebMethod(Description = "Shows all Keys", EnableSession = false)]
        public List<SysObject> GetAllKeys()
        {
            return dal.GetAllKeys();
        }

        [WebMethod(Description = "Shows all indexes", EnableSession = false)]
        public List<SysIndex> GetAllIndexes()
        {
            return dal.GetAllIndexes();
        }

        [WebMethod(Description = "Shows all constraints", EnableSession = false)]
        public List<SysConstraint> GetAllConstraints()
        {
            return dal.GetAllConstraints();
        }

        [WebMethod(Description = "Shows all tables solution 1", EnableSession = false)]
        public List<SysObject> GetAllTables()
        {
            return dal.GetAllTables();
        }

        [WebMethod(Description = "Shows all tables solution 2", EnableSession = false)]
        public List<SysTable> GetAllTables2()
        {
            return dal.GetAllTables2();
        }

        [WebMethod(Description = "Shows all columns in Employee table Solution 1", EnableSession = false)]
        public List<SysColumn> GetColumnsEmployee()
        {
            return dal.GetColumnsEmployee();
        }

        [WebMethod(Description = "Shows all columns in Employee table Solution 2", EnableSession = false)]
        public List<Information_Schema_Column> GetColumnsEmployee2()
        {
            return dal.GetColumnsEmployee2();
        }
        #endregion Uppgift A

    }
}
