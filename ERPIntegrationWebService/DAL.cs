using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using ERPIntegrationWebService.ERPIntegrationWSReference;

namespace ERPIntegrationWebService
{
    public class DAL
    {
        string connectionString = "server=localhost ; Trusted_Connection=yes; database=Demo Database NAV (5-0);";

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
            string sqlStr = "INSERT INTO [CRONUS Sverige AB$Employee] VALUES (DEFAULT, '" + no + "', '" + firstName + "' , '0', '" + lastName + "', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2007-12-13 00:00:00.000', '2007-12-13 00:00:00.000', 'NULL', '2007-12-13 00:00:00.000', '0', '0', '0', 1, '0', '0', '0', '0', '2007-12-13 00:00:00.000', 0, '2007-12-13 00:00:00.000', '0', '2007-12-13 00:00:00.000', '0', '0', '0', '0', '2007-12-13 00:00:00.000', '0', '0', '0', '0', '0', '0', '0')";
            ExecuteUpdate(sqlStr);

        }
        public void UpdateEmployee(string no, string firstName, string lastName)
        {
            string sqlStr = "UPDATE [CRONUS Sverige AB$Employee] SET [First Name] = '" + firstName + "', [Last Name] = '" + lastName + "' WHERE [No_] = '" + no + "'";
            ExecuteUpdate(sqlStr);

        }
        public void DeleteEmployee(string no)
        {
            string sqlStr = "DELETE FROM [CRONUS Sverige AB$Employee] WHERE No_ = '" + no + "'";
            ExecuteUpdate(sqlStr);

        }

        public List<Employee> showAllEmployees()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
            "select * from [CRONUS Sverige AB$Employee]", connectionString);
            DataSet employeeAbsenceDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeAbsenceDS, "employee");

            DataTable dt = new DataTable();
            dt = employeeAbsenceDS.Tables["Employee"];
            List<Employee> employeeAbsenceList = new List<Employee>();

            foreach (DataRow dataRow in dt.Rows)
            {
                Employee pb = new Employee();
                pb.EmployeeNo = dataRow["No_"].ToString();
                pb.FirstName = dataRow["First Name"].ToString();
                pb.LastName = dataRow["Last Name"].ToString();
                employeeAbsenceList.Add(pb);
            }


            return employeeAbsenceList;

        }

        #endregion Select, Delete, Update, Insert

        #region Uppgift A

        public List<SysObject> GetEmployeeAndMetaData()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(
            "select s.name, s.id, s.xtype from dbo.sysobjects s where name like 'CRONUS Sverige AB$Employee%' and xtype = 'U'", connectionString);
            DataSet employeeAbsenceDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeAbsenceDS, "empsick");

            DataTable dt = new DataTable();
            dt = employeeAbsenceDS.Tables["EmpSick"];
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

            SqlDataAdapter adapter = new SqlDataAdapter(
            "select [First Name], [Last Name] from [CRONUS Sverige AB$Employee] e, [CRONUS Sverige AB$Employee Absence] a where a.[Employee No_] = e.[No_] and Description = 'Sjuk' group by [First Name], [Last Name]", connectionString);
            DataSet employeeAbsenceDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeAbsenceDS, "empsick");

            DataTable dt = new DataTable();
            dt = employeeAbsenceDS.Tables["EmpSick"];
            List<EmpSick> employeeAbsenceList = new List<EmpSick>();

            foreach (DataRow dataRow in dt.Rows)
            {
                EmpSick pb = new EmpSick();
                pb.FirstName = dataRow["First Name"].ToString();
                pb.LastName = dataRow["Last Name"].ToString();
                employeeAbsenceList.Add(pb);
            }


            return employeeAbsenceList;

        }

        public List<EmpSick> GetMostSickEmployee()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(
            "select max(e.[First Name]) as [First Name] , (e.[Last Name])as [Last Name] from [CRONUS Sverige AB$Employee] e, [CRONUS Sverige AB$Employee Absence] a where a.[Employee No_] = e.[No_] and Description = 'Sjuk' group by [First Name], [Last Name]", connectionString);
            DataSet employeeAbsenceDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeAbsenceDS, "empsick");

            DataTable dt = new DataTable();
            dt = employeeAbsenceDS.Tables["EmpSick"];
            List<EmpSick> employeeAbsenceList = new List<EmpSick>();

            foreach (DataRow dataRow in dt.Rows)
            {
                EmpSick pb = new EmpSick();
                pb.FirstName = dataRow["First Name"].ToString();
                pb.LastName = dataRow["Last Name"].ToString();
                employeeAbsenceList.Add(pb);
            }


            return employeeAbsenceList;

        }

        public List<EmpRelativeQuery> GetEmployeeAndRelatives()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(
            "select e.[First Name], e.[Last Name], l.[Relative Code], l.[First Name] from [CRONUS Sverige AB$Employee Relative] l, [CRONUS Sverige AB$Employee] e where l.[Employee No_] = e.[No_]", connectionString);
            DataSet employeeRelativeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeRelativeDS, "emprelativequery");

            DataTable dt = new DataTable();
            dt = employeeRelativeDS.Tables["EmpRelativeQuery"];
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

        public List<SysIndex> GetAllIndexes()
        {

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT TOP 100 [id], [status] FROM sysindexes", connectionString);
            DataSet sysIndexDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(sysIndexDS, "sysindex");

            DataTable dt = new DataTable(); 
            dt = sysIndexDS.Tables["SysIndex"];
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

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT TOP 100 [name] FROM sysobjects WHERE xtype = 'U'", connectionString);
            DataSet sysTableDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(sysTableDS, "sysobject");

            DataTable dt = new DataTable();
            dt = sysTableDS.Tables["SysObject"];
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

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT TOP 100 [name] FROM sys.tables", connectionString);
            DataSet sysTableDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(sysTableDS, "systable");

            DataTable dt = new DataTable();
            dt = sysTableDS.Tables["SysTable"];
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

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT TOP 100 [constid], [id] FROM sysconstraints", connectionString);
            DataSet sysConstraintDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(sysConstraintDS, "sysconstraint");

            DataTable dt = new DataTable();
            dt = sysConstraintDS.Tables["SysConstraint"];
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

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT [name], [id], [xtype] FROM syscolumns WHERE id = object_id('[CRONUS Sverige AB$Employee]')", connectionString);
            DataSet employeeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeDS, "syscolumn");

            DataTable dt = new DataTable();
            dt = employeeDS.Tables["SysColumn"];
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

            SqlDataAdapter adapter = new SqlDataAdapter(
            "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee'", connectionString);
            DataSet employeeDS = new DataSet();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter.Fill(employeeDS, "Information_Schema_Column");

            DataTable dt = new DataTable();
            dt = employeeDS.Tables["Information_Schema_Column"];
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
