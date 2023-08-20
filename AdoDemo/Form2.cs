using AdoDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using AdoDemo.Model;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoDemo
{
    public partial class Form2 : Form
    {
        EmployeeCrud crud;
        List<Department> list;

        public Form2()
        {
            
            InitializeComponent();
            crud = new EmployeeCrud();
        }

       

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.name = txtname.Text;
                emp.sal = Convert.ToInt32(txtsalary.Text);
                emp.did = Convert.ToInt32(cmbdept.SelectedValue);
                int res = crud.AddEmployee(emp);
                if (res > 0)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

       


        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                List<Department> list = crud.GetDepartment();
                cmbdept.DataSource = list;
                cmbdept.DisplayMember = "dname";
                cmbdept.ValueMember = "did";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.id = Convert.ToInt32(txtid.Text);
                emp.name = txtname.Text;
                emp.sal = Convert.ToInt32(txtsalary.Text);
                emp.did = Convert.ToInt32(cmbdept.SelectedValue);
                int res = crud.UpdateEmployee(emp);
                if (res > 0)
                {
                    MessageBox.Show("Record updated..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                Employee emp = crud.GetEmployeeById(Convert.ToInt32(txtid.Text));
                if (emp.id > 0)
                {
                    foreach (Department i in list)
                    {
                        if (i.did == emp.did)
                        {
                            cmbdept.Text = i.dname;
                            break;
                        }
                    }
                    txtname.Text = emp.name;
                    txtsalary.Text = emp.sal.ToString();

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btndelete_Click_1(object sender, EventArgs e)
        {
            try
            {

                int res = crud.DeleteEmployee(Convert.ToInt32(txtid.Text));
                if (res > 0)
                {
                    MessageBox.Show("Record deleted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsaveall_Click(object sender, EventArgs e)
        {
           
                DataTable table = crud.GetAllEmployees();
                dataGridView1.DataSource = table;
            

        }
    }
}
