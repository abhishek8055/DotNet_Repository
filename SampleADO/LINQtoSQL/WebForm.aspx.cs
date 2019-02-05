using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQtoSQL
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataClassDataContext dbContext = new DataClassDataContext();
            //GridView1.DataSource = dbContext.customers;
            //GridView1.DataBind();

            GridView1.DataSource = from customer in dbContext.customers
                where customer.email == "abhishek@gmail"
                orderby customer.fname descending
                select customer;
            GridView1.DataBind();
        }
    }
}