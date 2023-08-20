using AdoDemo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using AdoDemo.Model;
using System.Xml.Linq;

namespace AdoDemo
{
    public partial class Form1 : Form
    {
        ProductCrud crud;
        List<Category> list;

        public Form1()
        {
            InitializeComponent();
            crud = new ProductCrud();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                List<Category> list = crud.GetCategory();
                cmbcategory.DataSource = list;
                cmbcategory.DisplayMember = "Cname";
                cmbcategory.ValueMember = "Cid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.name = txtname.Text;
                p.price = Convert.ToInt32(txtprice.Text);
                p.cid = Convert.ToInt32(cmbcategory.SelectedValue);
                int res = crud.AddProduct(p);
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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = crud.GetProductById(Convert.ToInt32(txtid.Text));
                if (prod.id > 0)
                {
                    foreach (Category item in list)
                    {
                        if (item.cid == prod.cid)
                        {
                            cmbcategory.Text = item.cname;
                            break;
                        }
                    }
                    txtname.Text = prod.name;
                    txtprice.Text = prod.price.ToString();

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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.id = Convert.ToInt32(txtid.Text);
                p.name = txtname.Text;
                p.price = Convert.ToInt32(txtprice.Text);
                p.cid = Convert.ToInt32(cmbcategory.SelectedValue);
                int res = crud.UpdateProduct(p);
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                int res = crud.DeleteProduct(Convert.ToInt32(txtid.Text));
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

       
    }
}
