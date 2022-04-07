using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        public void AddEmployee(EmployeeModel employee);
        public void UpdateEmployee(EmployeeModel employee);
        public void DeleteEmployee(int? EmpId);
        public IEnumerable<EmployeeModel> GetAllEmployee();
        EmployeeModel GetEmployeeData(int? id);
    }
}
