using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQtoSQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        EcomDBDataContext db = null;
        List<Employee> EmpList = null;
        int rno = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            db = new EcomDBDataContext();
            EmpList = db.Employees.ToList();
            ShowData();
        }

        private void ShowData()
        {
            textBox1.Text = EmpList[rno].Name;
            textBox2.Text = EmpList[rno].Salary.ToString();
            textBox3.Text = EmpList[rno].Department_Id.ToString();
            textBox4.Text = EmpList[rno].Location_Id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rno > 0)
            {
                rno -= 1;
                ShowData();
            }
            else
            {
                MessageBox.Show("First data of the record.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(rno < EmpList.Count - 1)
            {
                rno += 1;
                ShowData();
            }
            else
            {
                MessageBox.Show("Last data of record.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
