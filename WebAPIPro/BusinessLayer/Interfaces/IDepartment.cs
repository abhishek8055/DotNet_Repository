using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<EmployeeModel> GetAllEmployeesByDepartment(int departmentId);
        IEnumerable<EmployeeModel> GetAllDepartments();
    }
}
