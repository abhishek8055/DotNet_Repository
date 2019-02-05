using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudOnXML
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            DataClassDataContext dbContext = new DataClassDataContext();
            /*METHOD 1
                GridView1.DataSource = dbContext.Employees;
                GridView1.DataBind();
            */

            /*METHOD 2
                var linqQuery = from employee in dbContext.Employees select employee;
                GridView1.DataSource = linqQuery;
                GridView1.DataBind();
            */

            //STORED PROCEDURE
            GridView1.DataSource = dbContext.GetEmployees();
            GridView1.DataBind();
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            using (DataClassDataContext dbContext = new DataClassDataContext())
            {
                Employee employee = new Employee
                {
                    FirstName = "Deborah",
                    LastName = "Kurata",
                    Gender = "Female",
                    Salary = 30000,
                    DepartmentId = 3
                };
                dbContext.Employees.InsertOnSubmit(employee);
                dbContext.SubmitChanges();
            }
            GetData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (DataClassDataContext dbContext = new DataClassDataContext())
            {
                var employee = dbContext.Employees.OrderByDescending(emp => emp.ID).Take(1);
                foreach (var emp in employee)
                {
                    emp.Salary = 55555;
                    emp.DepartmentId = 1;
                   
                }
                dbContext.SubmitChanges();
            }
            GetData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (DataClassDataContext dbContext = new DataClassDataContext())
            {
                var employee = dbContext.Employees.OrderByDescending(emp => emp.ID).Take(1);
                foreach (var emp in employee)
                {
                    dbContext.Employees.DeleteOnSubmit(emp);
                }               
                dbContext.SubmitChanges();
            }
            GetData();
        }

        protected void Delta_Click(object sender, EventArgs e)
        {

        }
    }
}