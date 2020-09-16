using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstFromDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CFFD cFFD = new CFFD();

        private void Form1_Load(object sender, EventArgs e)
        {
            //var ids = from emp in Ent.Employees
            //          select emp.id;

            //foreach(var id in ids)
            //{
            //    comboBox1.Items.Add(id);
            //}
        }



        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                Employee newEmp = new Employee()
                {
                    id = int.Parse(txt_id.Text),
                    firstName = txt_fname.Text,
                    lastName = txt_lname.Text,
                    title = txt_title.Text
                };
                cFFD.Employees.Add(newEmp);
                cFFD.SaveChanges();
                MessageBox.Show("successfully added");
            }
            catch
            {
                MessageBox.Show("invalid id");
            }


            txt_id.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_title.Text = "";

        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txt_id.Text);
                var employee = (from emp in cFFD.Employees
                                where emp.id == id
                                select emp).First();
                txt_fname.Text = employee.firstName;
                txt_lname.Text = employee.lastName;
                txt_title.Text = employee.title;
            }
            catch
            {
                MessageBox.Show("invalid id");
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txt_id.Text);
                var employee = (from emp in cFFD.Employees
                                where emp.id == id
                                select emp).First();

                employee.firstName = txt_fname.Text;
                employee.lastName = txt_lname.Text;
                employee.title = txt_title.Text;
                cFFD.SaveChanges();
                MessageBox.Show("successfully updated");
            }
            catch
            {
                MessageBox.Show("invalid id");
            }

            txt_id.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_title.Text = "";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txt_id.Text);
                var employee = (from emp in cFFD.Employees
                                where emp.id == id
                                select emp).First();

                cFFD.Employees.Remove(employee);
                cFFD.SaveChanges();
                MessageBox.Show("sucessfully deleted");
            }

            catch
            {
                MessageBox.Show("invalid id");
            }


            txt_id.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_title.Text = "";
        }
    }
}
