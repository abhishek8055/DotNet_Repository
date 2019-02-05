using MVCLoginPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLoginPortal.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Customer.Id == 0)
                {
                    return "Add New Customer";
                }
                return "Edit Customer";
            }
        }
    }
}