using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ILocation
    {
        IEnumerable<EmployeeModel> GetEmployeesByLocationId(int locationId);
        IEnumerable<LocationModel> GetAllLocations();
    }
}
