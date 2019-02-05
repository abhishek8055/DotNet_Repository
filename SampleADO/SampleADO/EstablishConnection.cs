using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOConnection
{
    public partial class EstablishConnection : Form
    {
        private SqlConnection con;
        public EstablishConnection()
        {
            InitializeComponent();
            con = new SqlConnection("server=TECH-LP-892; Database=TestAdo; user id=sa; password=tadigital$123");
        }

        private void EstablishConnection_Load(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MessageBox.Show("Connection Established");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
