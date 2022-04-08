using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL:IEmployeeRL
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "EmployeePayRoll-MVC";
        public EmployeeRL(IConfiguration config) // Iconfiguration is taken from appsettings.json;
        {
            _config = config;
        }
        public void AddEmployee(EmployeeModel employee) // method for inserting the values;
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection con = new SqlConnection(connectionString)) // instance of database conection;

            {
                SqlCommand emp = new SqlCommand("sp_Add", con); // ' sp_Add' is a stored procedure for inserting values;
                emp.CommandType = CommandType.StoredProcedure;//decides what type of object a command will be executed as;
                // addwithvalue whenever you want to add a parameter by specifying its name and value.
                emp.Parameters.AddWithValue("@Name", employee.Name); 
                emp.Parameters.AddWithValue("@Profile", employee.ProfileImage);
                emp.Parameters.AddWithValue("@Gender", employee.Gender);
                emp.Parameters.AddWithValue("@Department", employee.Department);
                emp.Parameters.AddWithValue("@Salary", employee.Salary);
                emp.Parameters.AddWithValue("@Startdate", employee.Startdate);
                emp.Parameters.AddWithValue("@Notes", employee.Notes);
                con.Open(); // connection string opening ;
                emp.ExecuteNonQuery(); // used for executing queries that does not return any data;
                con.Close(); // closeing of the opened connection string;
            }
        }
        public void UpdateEmployee(EmployeeModel employee) // method for update the inserted values;
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection con = new SqlConnection(connectionString))// instance of database conection;
            {
                SqlCommand update = new SqlCommand("sp_UPDATE", con);// ' sp_Update' is a stored procedure for updating values;
                update.CommandType = CommandType.StoredProcedure;//decides what type of object a command will be executed as;
                // addwithvalue whenever you want to add a parameter by specifying its name and value;
                update.Parameters.AddWithValue("@EmpId", employee.EmpId);
                update.Parameters.AddWithValue("@Name", employee.Name);
                update.Parameters.AddWithValue("@Profile", employee.ProfileImage);
                update.Parameters.AddWithValue("@Gender", employee.Gender);
                update.Parameters.AddWithValue("@Department", employee.Department);
                update.Parameters.AddWithValue("@Salary", employee.Salary);
                update.Parameters.AddWithValue("@Startdate", employee.Startdate);
                update.Parameters.AddWithValue("@Notes", employee.Notes);
                con.Open();// connection open;
                update.ExecuteNonQuery();// executiong queries with no return data;
                con.Close(); // connection closing;
            }
        }
        public void DeleteEmployee(int? EmpId)// method for deletion of value by empId;
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection con = new SqlConnection(connectionString))// instance of database conection;
            {
                SqlCommand delete = new SqlCommand("sp_Delete", con);//sp_Delete is stored procedure;
                delete.CommandType = CommandType.StoredProcedure;

                delete.Parameters.AddWithValue("@EmpId", EmpId);

                con.Open();// connection string open;
                delete.ExecuteNonQuery();
                con.Close();// connection string closing;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployee() //  method for getting all data;
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            List<EmployeeModel> lstEmps = new List<EmployeeModel>(); 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand getemp = new SqlCommand("sp_GETALL", con);// stored procedure for getting all data;
                getemp.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = getemp.ExecuteReader();//Sends the CommandText to the Connection and builds a SqlDataReader;

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Startdate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();

                    lstEmps.Add(employee);
                }
                con.Close();
            }
            return lstEmps;
        }
        public EmployeeModel GetEmployeeData(int? EmpId)
        {
            EmployeeModel employee = new EmployeeModel();
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Employee Where EmpId = " + EmpId;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Startdate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();

                }
                con.Close();
            }
            return employee;
        }
    }
}
