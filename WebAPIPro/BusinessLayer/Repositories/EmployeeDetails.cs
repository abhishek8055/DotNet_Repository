using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccesslayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class EmployeeDetails : IEmployee
    {
        ecomdbEntities dbCon;

        public EmployeeDetails()
        {
            dbCon = new ecomdbEntities();
        }   
        public bool AddEmployee(EmployeeModel employee)
        {
            Employee emp = new Employee();
            Mapper.Map(employee, emp);
            bool status = true;
            try
            {
                dbCon.Employees.Add(emp);
                dbCon.SaveChanges();
            }
            catch(Exception ex)
            {
                status = false;
            }
            return status;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            var list = dbCon.Employees.Select(e => new EmployeeModel {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Department_Id = e.Department_Id,
                Location_Id = e.Location_Id,

                Department = new DepartmentModel
                {
                    Id = e.Department_Id,
                    Name = e.Department.Name
                },

                Location = new LocationModel
                {
                    Id = e.Location_Id,
                    Name = e.Location.Name
                }
            });
            return list;
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
