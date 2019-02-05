using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Department_Id { get; set; }
        public int Location_Id { get; set; }

        public DepartmentModel Department { get; set; }
        public LocationModel Location { get; set; }
    }
}
