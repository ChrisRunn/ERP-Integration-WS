using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace ERPIntegrationWebService
{
    public class DAL
    {
        string connectionString = "server=localhost; Trusted_Connection=yes; database=Demo Database NAV (5-0);";
        #region GENERISK METOD
        private void ExecuteUpdate(string sqlStr)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Debug.WriteLine(sqlStr);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sqlStr, con);
                com.ExecuteNonQuery();

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private DataTable ExecuteQuery(string sqlStr)
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStr, con);
                dataAdapter.Fill(dataTable);
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return dataTable;
        }
        #endregion GENERISK METOD
        #region Select, Delete, Update, Insert
        public void InsertEmployee(string no, string name)
        {
            string sqlStr = "INSERT INTO [CRONUS Sverige AB$Employee Absence] VALUES (DEFAULT, '" + no + "', '" + name + "' , '2004-01-02 00:00:00.000', '1753-01-01 00:00:00.000', '0', '0', '0', '0', '0', '0')";
            ExecuteUpdate(sqlStr);

        }
        public void UpdateEmployee(string no, string name, string lastName)
        {
            string sqlStr = "UPDATE [CRONUS Sverige AB$Employee] SET [First Name] = '" + name + "', [Last Name] = '" + lastName + "' WHERE No_ = '" + no + "'";
            ExecuteUpdate(sqlStr);

        }
        public void DeleteEmployee(string no)
        {
            string sqlStr = "DELETE FROM [CRONUS Sverige AB$Employee] WHERE No_ = '" + no + "'";
            ExecuteUpdate(sqlStr);

        }
        public DataTable SearchEmployee(string searchString)
        {

            string sqlStr = "SELECT * FROM [CRONUS Sverige AB$Employee] where No_ like '%" + searchString + "%' or [First Name] like '%" + searchString + "%' or [Last Name] like '%" + searchString + "%'";
            DataTable dt = ExecuteQuery(sqlStr);
            return dt;
        }

        #endregion Select, Delete, Update, Insert

        #region Uppgift A

        public DataSet GetEmployeeAndMetaData()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
            "select * from dbo.sysobjects where name like 'CRONUS Sverige AB$Employee%' and xtype = 'U'", connectionString);
            DataSet employeeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeDS, "Employees");

            return employeeDS;
        }
        public DataSet GetSickEmployee()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
            "select [First Name], [Last Name] from [CRONUS Sverige AB$Employee] e, [CRONUS Sverige AB$Employee Absence] a where a.[Employee No_] = e.[No_] and Description = 'Sjuk' group by [First Name], [Last Name]", connectionString);
            DataSet employeeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeDS, "Employees");

            return employeeDS;
        }
        public DataSet GetMostSickEmployee()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
            "select max(e.[First Name]) as [First Name] , (e.[Last Name])as [Last Name] from [CRONUS Sverige AB$Employee] e, [CRONUS Sverige AB$Employee Absence] a where a.[Employee No_] = e.[No_] and Description = 'Sjuk' group by [First Name], [Last Name]", connectionString);
            DataSet employeeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeDS, "Employees");

            return employeeDS;
        }
        public DataSet GetEmployeeAndRelatives()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
            "select e.[First Name], e.[Last Name], l.[Relative Code], l.[First Name] from [CRONUS Sverige AB$Employee Relative] l, [CRONUS Sverige AB$Employee] e where l.[Employee No_] = e.[No_]", connectionString);
            DataSet employeeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeDS, "Employees");

            return employeeDS;
        }
        #endregion Uppgift A

        #region Uppgift B
        public List<SysObject> GetAllKeys()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT TOP 100 [id], [xtype], [name] FROM sysobjects WHERE xtype = 'F' OR xtype = 'PK'", connectionString);
            DataSet sysObjectDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(sysObjectDS, "sysobjects");

            DataTable dt = new DataTable();
            dt = sysObjectDS.Tables["SysObjects"];
            List<SysObject> sysObjectList = new List<SysObject>();

            foreach (DataRow dataRow in dt.Rows)
            {
                SysObject pb = new SysObject();
                pb.Id = dataRow["id"].ToString();
                pb.Xtype = dataRow["xtype"].ToString();
                pb.Name = dataRow["name"].ToString();
                sysObjectList.Add(pb);
            }


            return sysObjectList;

        }

            
        }

        //public DataSet GetAllIndexes()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(
        //    "SELECT TOP 100 [id], [status] FROM sysindexes", connectionString);
        //    DataSet employeeDS = new DataSet();
        //    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //    adapter.Fill(employeeDS, "Employees");

        //    return employeeDS;
        //}
        //public DataSet GetAllConstraints()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(
        //   "SELECT TOP 100 [constid], [id] FROM sysconstraints", connectionString);
        //    DataSet employeeDS = new DataSet();
        //    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //    adapter.Fill(employeeDS, "Employees");

        //    return employeeDS;
        //}
        //public DataSet GetAllTables()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(
        //   "SELECT TOP 100 [name] FROM sysobjects WHERE xtype = 'U'", connectionString);
        //    DataSet employeeDS = new DataSet();
        //    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //    adapter.Fill(employeeDS, "Employees");

        //    return employeeDS;
        //}
        //public DataSet GetAllTables2()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(
        //    "SELECT TOP 100 [name] FROM sys.tables", connectionString);
        //    DataSet employeeDS = new DataSet();
        //    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //    adapter.Fill(employeeDS, "Employees");

        //    return employeeDS;
        //}
        //public DataSet GetColumnsEmployee()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(
        //    "SELECT [name], [id], [xtype] FROM syscolumns WHERE id = object_id('[CRONUS Sverige AB$Employee]')", connectionString);
        //    DataSet employeeDS = new DataSet();
        //    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //    adapter.Fill(employeeDS, "Employees");

        //    return employeeDS;
        //}
        //public DataSet GetColumnsEmployee2()
        //{
        //    SqlDataAdapter adapter = new SqlDataAdapter(
        //    "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee'", connectionString);
        //    DataSet employeeDS = new DataSet();
        //    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        //    adapter.Fill(employeeDS, "Employees");

        //    return employeeDS;
        //}

        #endregion Uppgift B

       
    }
