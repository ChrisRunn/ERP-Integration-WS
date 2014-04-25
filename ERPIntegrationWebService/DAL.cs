using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using ERPIntegrationWebService.ERPIntegrationWSReference;
using System.Configuration;

namespace ERPIntegrationWebService
{
    public class DAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        //string connectionString = "server=Localhost; Trusted_Connection=yes; database=Demo Database NAV (5-0);";

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
        public void InsertEmployee(string no, string firstName, string lastName)
        {
            string sqlStr = "insert into [CRONUS Sverige AB$Employee] values (DEFAULT, '" + no + "', '" + firstName + "' , '0', '" + lastName + "', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2007-12-13 00:00:00.000', '2007-12-13 00:00:00.000', 'NULL', '2007-12-13 00:00:00.000', '0', '0', '0', 1, '0', '0', '0', '0', '2007-12-13 00:00:00.000', 0, '2007-12-13 00:00:00.000', '0', '2007-12-13 00:00:00.000', '0', '0', '0', '0', '2007-12-13 00:00:00.000', '0', '0', '0', '0', '0', '0', '0')";
            ExecuteUpdate(sqlStr);

        }
        public void UpdateEmployee(string no, string firstName, string lastName)
        {
            string sqlStr = "update [CRONUS Sverige AB$Employee] set [First Name] = '" + firstName + "', [Last Name] = '" + lastName + "' where [No_] = '" + no + "'";
            ExecuteUpdate(sqlStr);

        }
        public void DeleteEmployee(string no)
        {
            string sqlStr = "delete from [CRONUS Sverige AB$Employee] where No_ = '" + no + "'";
            ExecuteUpdate(sqlStr);

        }

        public List<Employee> ShowAllEmployees()
        {
            string sqlStr = "select * from [CRONUS Sverige AB$Employee]";
            DataTable dt = ExecuteQuery(sqlStr);
            List<Employee> employeeList = new List<Employee>();

            foreach (DataRow dataRow in dt.Rows)
            {
                Employee pb = new Employee();
                pb.EmployeeNo = dataRow["No_"].ToString();
                pb.FirstName = dataRow["First Name"].ToString();
                pb.LastName = dataRow["Last Name"].ToString();
                employeeList.Add(pb);
            }
            return employeeList;
        }

        #endregion Select, Delete, Update, Insert

        #region Uppgift A

        public List<SysObject> GetEmployeeAndMetaData()
        {

            string sqlStr = "select s.name, s.id, s.xtype from dbo.sysobjects s where name like 'CRONUS Sverige AB$Employee%' and xtype = 'U'";
            DataTable dt = ExecuteQuery(sqlStr);
            List<SysObject> employeeAbsenceList = new List<SysObject>();

            foreach (DataRow dataRow in dt.Rows)
            {
                SysObject pb = new SysObject();
                pb.Name = dataRow["name"].ToString();
                pb.Id = dataRow["id"].ToString();
                pb.Xtype = dataRow["xtype"].ToString();
                employeeAbsenceList.Add(pb);
            }
            return employeeAbsenceList;
        }

        public List<EmpSick> GetSickEmployee()
        {

           string sqlStr = "select [First Name], [Last Name], [Quantity] from [CRONUS Sverige AB$Employee] e, [CRONUS Sverige AB$Employee Absence] a where a.[Employee No_] = e.[No_] and Description = 'Sjuk' group by [First Name], [Last Name], [Quantity]";
           DataTable dt = ExecuteQuery(sqlStr);
           List<EmpSick> employeeAbsenceList = new List<EmpSick>();

            foreach (DataRow dataRow in dt.Rows)
            {
                EmpSick pb = new EmpSick();
                pb.FirstName = dataRow["First Name"].ToString();
                pb.LastName = dataRow["Last Name"].ToString();
                pb.Quantity = dataRow["Quantity"].ToString();
                employeeAbsenceList.Add(pb);
            }
            return employeeAbsenceList;
        }

        public List<EmpSick> GetMostSickEmployee()
        {

            string sqlStr= "select max(e.[First Name]) as [First Name] , (e.[Last Name])as [Last Name], (a.[Quantity])as [Quantity] from [CRONUS Sverige AB$Employee] e, [CRONUS Sverige AB$Employee Absence] a where a.[Employee No_] = e.[No_] and Description = 'Sjuk' group by [First Name], [Last Name], [Quantity]";
            DataTable dt = ExecuteQuery(sqlStr);
            List<EmpSick> employeeAbsenceList = new List<EmpSick>();

            foreach (DataRow dataRow in dt.Rows)
            {
                EmpSick pb = new EmpSick();
                pb.FirstName = dataRow["First Name"].ToString();
                pb.LastName = dataRow["Last Name"].ToString();
                pb.Quantity = dataRow["Quantity"].ToString();
                employeeAbsenceList.Add(pb);
            }
            return employeeAbsenceList;
        }

        public List<EmpRelativeQuery> GetEmployeeAndRelatives()
        {

         string sqlStr = "select e.[First Name], e.[Last Name], l.[Relative Code], l.[First Name] from [CRONUS Sverige AB$Employee Relative] l, [CRONUS Sverige AB$Employee] e where l.[Employee No_] = e.[No_]";
         DataTable dt = ExecuteQuery(sqlStr);
         List<EmpRelativeQuery> employeeRelativeList = new List<EmpRelativeQuery>();

            foreach (DataRow dataRow in dt.Rows)
            {
                EmpRelativeQuery pb = new EmpRelativeQuery();
                pb.EmpFirstName = dataRow[0].ToString();
                pb.EmpLastName = dataRow[1].ToString();
                pb.RelativeCode = dataRow[2].ToString();
                pb.RelFirstName = dataRow[3].ToString();
                employeeRelativeList.Add(pb);
            }
            return employeeRelativeList;
        }

        #endregion Uppgift A
        
        #region Uppgift B
        public List<SysObject> GetAllKeys()
        {
            string sqlStr ="select top 100 [id], [xtype], [name] from sysobjects where xtype = 'F' or xtype = 'PK'";
            DataTable dt = ExecuteQuery(sqlStr);
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

        public List<SysIndex> GetAllIndexes()
        {
            string sqlStr ="select top 100 [id], [status] from sysindexes";
            DataTable dt = ExecuteQuery(sqlStr); 
            List<SysIndex> sysIndexList = new List<SysIndex>();

            foreach (DataRow dataRow in dt.Rows)
            {
                SysIndex pb = new SysIndex();
                pb.Id = dataRow["id"].ToString();
                pb.Status = dataRow["status"].ToString();
                sysIndexList.Add(pb);
            }
            return sysIndexList;
        }

        public List<SysObject> GetAllTables()
        {
           string sqlStr ="select top 100 [name] from sysobjects where xtype = 'U'";
           DataTable dt = ExecuteQuery(sqlStr);
           List<SysObject> sysTableList = new List<SysObject>();

            foreach (DataRow dataRow in dt.Rows)
            {
                SysObject pb = new SysObject();
                pb.Name = dataRow["name"].ToString();
                sysTableList.Add(pb);
            }
            return sysTableList;
        }

        public List<SysTable> GetAllTables2()
        {

            string sqlStr ="select top 100 [name] from sys.tables";
            DataTable dt = ExecuteQuery(sqlStr);
            List<SysTable> sysTableList = new List<SysTable>();

            foreach (DataRow dataRow in dt.Rows)
            {
                SysTable pb = new SysTable();
                pb.Name = dataRow["name"].ToString();
                sysTableList.Add(pb);
            }

            return sysTableList;

        }

        public List<SysConstraint> GetAllConstraints()
        {

            string sqlStr ="select top 100 [constid], [id] from sysconstraints";
            DataTable dt = ExecuteQuery(sqlStr);
            List<SysConstraint> sysConstraintList = new List<SysConstraint>();
            foreach (DataRow dataRow in dt.Rows)
            {
                SysConstraint pb = new SysConstraint();
                pb.Id = dataRow["id"].ToString();
                pb.Constid = dataRow["constid"].ToString();
                sysConstraintList.Add(pb);
            }
            return sysConstraintList;
        }

        public List<SysColumn> GetColumnsEmployee()
        {
            string sqlStr = "select [name], [id], [xtype] from syscolumns where id = object_id('[CRONUS Sverige AB$Employee]')";
            DataTable dt = ExecuteQuery(sqlStr);
            List<SysColumn> employeeList = new List<SysColumn>();

            foreach (DataRow dataRow in dt.Rows)
            {
                SysColumn pb = new SysColumn();
                pb.Name = dataRow["name"].ToString();
                pb.Id = dataRow["id"].ToString();
                pb.Xtype = dataRow["xtype"].ToString();
                employeeList.Add(pb);
            }
            return employeeList;
        }

        public List<Information_Schema_Column> GetColumnsEmployee2()
        {

           string sqlStr = "select COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'CRONUS Sverige AB$Employee'";

           DataTable dt = ExecuteQuery(sqlStr);
           List<Information_Schema_Column> employeeList = new List<Information_Schema_Column>();

            foreach (DataRow dataRow in dt.Rows)
            {
                Information_Schema_Column pb = new Information_Schema_Column();
                pb.COLUMN_NAME1 = dataRow["COLUMN_NAME"].ToString();
                employeeList.Add(pb);
            }
            return employeeList;

        }
           
        }
    

        #endregion Uppgift B

       
    }
