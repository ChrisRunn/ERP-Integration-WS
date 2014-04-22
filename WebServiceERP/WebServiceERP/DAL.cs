using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceERP
{
    public class DAL
    {
        string connectionString = "server=localhost; Trusted_Connection=yes; database=Demo Database NAV (5-0);";

        public DataSet GetAllEmployees()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(
     "select No_ from [CRONUS Sverige AB$Employee]", connectionString);

            DataSet studentDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(studentDS, "Students");

            return studentDS;

        }
    }
}