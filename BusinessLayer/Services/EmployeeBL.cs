using BusinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                employeeRL.AddEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                employeeRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteEmployee(int? id)
        {
            try
            {
                employeeRL.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            try
            {
                return employeeRL.GetAllEmployee();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return employeeRL.GetEmployeeData(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
