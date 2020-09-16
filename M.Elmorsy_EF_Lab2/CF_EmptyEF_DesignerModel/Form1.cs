using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF_EmptyEF_DesignerModel
{
    public partial class Form1 : Form
    {
        //dbContext
        EEDMContainer db = new EEDMContainer();
        public Form1()
        {
            InitializeComponent();

            var depts_ids = from department in db.Departments
                       select department.Id;

            foreach(var dept_id in depts_ids)
            {
                comboBox1.Items.Add(dept_id);
            }

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Department department = new Department()
            {
                Dept_Name = txt_name.Text
            };

            db.Departments.Add(department);
            db.SaveChanges();

            txt_name.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)(comboBox1.SelectedItem);
            var dept = (from department in db.Departments
                        where department.Id == id
                        select department).First();

            txt_name.Text = dept.Dept_Name;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = (int)(comboBox1.SelectedItem);
            var dept = (from department in db.Departments
                        where department.Id == id
                        select department).First();

            dept.Dept_Name = txt_name.Text;
            db.SaveChanges();
            txt_name.Text = "";
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = (int)(comboBox1.SelectedItem);
            var dept = (from department in db.Departments
                        where department.Id == id
                        select department).First();

            db.Departments.Remove(dept);
            db.SaveChanges();
            txt_name.Text = "";
        }
    }
}
