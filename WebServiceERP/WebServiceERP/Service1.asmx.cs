using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceERP
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
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