using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AdoDemo.Model
{
    public class EmployeeCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public EmployeeCrud()
        {
            string connstr = ConfigurationManager.ConnectionStrings["defaultConnect"].ConnectionString;

            con = new SqlConnection(connstr);
        }
        public int AddEmployee(Employee emp)
        {
            string qry = "insert into Employee values (@name,@sal,@did)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@sal", emp.sal);
            cmd.Parameters.AddWithValue("@did", emp.did);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;
            con.Close();
        }
        public int UpdateEmployee(Employee emp)
        {
            // step1 -> qry
            string qry = "update Employee set name=@name,sal=@sal,did=@did where id=@id";
            // step2- assign qry to command
            cmd = new SqlCommand(qry, con);
            // step3- pass valeu to the parameters
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@sal", emp.sal);
            cmd.Parameters.AddWithValue("@did", emp.did);
            cmd.Parameters.AddWithValue("@id", emp.id);
            // step4- open the connection
            con.Open();
            //step5- fire the query
            int result = cmd.ExecuteNonQuery();
            //step6- close the conn
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            // step1 -> qry
            string qry = "delete from Employee where id=@id";
            // step2- assign qry to command
            cmd = new SqlCommand(qry, con);
            // step3- pass valeu to the parameters
            cmd.Parameters.AddWithValue("@id", id);
            // step4- open the connection
            con.Open();
            //step5- fire the query
            int result = cmd.ExecuteNonQuery();
            //step6- close the conn
            con.Close();
            return result;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string qry = "select * from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    emp.id = Convert.ToInt32(dr["id"]);
                    emp.name = dr["name"].ToString();
                    emp.sal = Convert.ToInt32(dr["sal"]);
                    emp.did = Convert.ToInt32(dr["did"]);
                }
            }
            con.Close();
            return emp;
        }

        public List<Department> GetDepartments()
        {
            List<Department> list = new List<Department>();
            //step1- write a query
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department d = new Department();
                    d.did = Convert.ToInt32(dr["did"]);
                    d.dname = dr["dname"].ToString();
                    list.Add(d);
                }

            }
            con.Close();
            return list;
        }



        public List<Department> GetDepartment()
        {
            List<Department> list = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department d = new Department();
                    d.did = Convert.ToInt32(dr["did"]);
                    d.dname = dr["dname"].ToString();
                    list.Add(d);

                }
            }
            con.Close();
            return list;
        }

        public DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dt.Load(dr);
            }
            con.Close();
            return dt;
        }




    }
}
