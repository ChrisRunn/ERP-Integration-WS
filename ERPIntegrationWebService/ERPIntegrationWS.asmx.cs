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

        [WebMethod(Description = "Inserts new employee", EnableSession = false)]
        public void InsertEmployee()
        {
        }

        [WebMethod(Description = "Updates employee", EnableSession = false)]
        public void UpdateEmployee()
        {
        }

        [WebMethod(Description = "Deletes employee", EnableSession = false)]
        public void DeleteEmployee()
        {
        }

        [WebMethod(Description = "Shows all employees", EnableSession = false)]
        public DataSet GetAllEmployees()
        {
            return dal.GetAllEmployees();
        }
    }
}
