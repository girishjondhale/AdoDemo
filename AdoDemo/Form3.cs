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

namespace AdoDemo
{
    public partial class disconnecteddemo : Form
    {
        EmployeeCrud crud;
        List<Department> list;
        public disconnecteddemo()
        {
            InitializeComponent();
             crud = new EmployeeCrud();
        }

        private void disconnecteddemo_Load(object sender, EventArgs e)
        {
            DataTable table = crud.GetAllCategories();
            cmbCategoryId.DataSource = table;
            cmbCategoryId.DisplayMember = "Cname";
            cmbCategoryId.ValueMember = "Cid";

        }
    }
}
