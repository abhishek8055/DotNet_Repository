using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRegistration
{
    public partial class RegistrationForm : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataSet ds = null;
        SqlDataAdapter da = null;
        public RegistrationForm()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }

        void reset()
        {
            allUsers.Text = "";
            fname.Text = "";
            lname.Text = "";
            email.Text = "";
            password.Text = "";
            allUsers.Focus();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            try
            {
                string fn = fname.Text;
                string ln = lname.Text;
                string eml = email.Text;
                string pwd = password.Text;

                string command = string.Format("INSERT INTO customer VALUES ('{0}', '{1}', '{2}', '{3}')", fn, ln, eml, pwd);
                cmd = new SqlCommand(command, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                reset();
                MessageBox.Show("Record Successfully Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                string emailId = allUsers.Text;
                string fn = fname.Text;
                string ln = lname.Text;
                string pwd = password.Text;
                
                string command = "UPDATE customer SET fname = @firstname, lname = @lastname, password = @pass WHERE email = @emailId";
                cmd = new SqlCommand(command, con);
                cmd.Parameters.Add("@firstname", SqlDbType.VarChar);
                cmd.Parameters.Add("@lastname", SqlDbType.VarChar);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar);
                cmd.Parameters.Add("@emailId", SqlDbType.VarChar);
                cmd.Parameters["@firstname"].Value = fn;
                cmd.Parameters["@lastname"].Value = ln;
                cmd.Parameters["@pass"].Value = pwd;
                cmd.Parameters["@emailId"].Value = emailId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                reset();
                MessageBox.Show("Record updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string emailId = allUsers.Text;
                string command = "DELETE FROM customer WHERE email = @emailId";
                cmd = new SqlCommand(command, con);
                cmd.Parameters.Add("@emailId", SqlDbType.VarChar);
                cmd.Parameters["@emailId"].Value = emailId;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                reset();
                MessageBox.Show("Record deleted Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            loadAllUsers();
        }

        private void Display_Click(object sender, EventArgs e)
        {

        }

        private void allUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string emailId = allUsers.Text;
            var query = from row in ds.Tables["customer"].AsEnumerable()
                        where row["email"].ToString() == emailId
                        select row;
            foreach (var item in query)
            {
                fname.Text = item["fname"].ToString();
                lname.Text = item["lname"].ToString();
                email.Text = item["email"].ToString();
                password.Text = item["password"].ToString();
            }
        }

        private void loadAllUsers()
        {
            try
            {
                string query = "SELECT * FROM customer";
                da = new SqlDataAdapter(query, con);
                ds = new DataSet();
                da.Fill(ds, "customer");
                //allUsers.DataSource = ds.Tables["customer"];
                //allUsers.DisplayMember = "email";
                //allUsers.ValueMember = "email";
                
                foreach (var item in ds.Tables["customer"].AsEnumerable())
                {
                    allUsers.Items.Add(item["email"]);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
