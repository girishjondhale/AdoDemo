using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AdoDemo.Model
{
    public class ProductDisconnectted
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder scb;
        public ProductDisconnectted()
        {
            string connstr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(connstr);
        }
        public DataSet GetAllProducts()
        {
            string qry = "select * from Product";
            da = new SqlDataAdapter(qry, con);
            // we want to apply PK to the col which is in the DataSet
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            // track the DataSet , generate the qry & pass to the DataAdapter
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Product");// Product name is given to the table which is in DataSet
            return ds;
        }
        public DataTable GetAllCategories()
        {
            string qry = "select * from Category";
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            da.Fill(ds, "Category");
            return ds.Tables["Category"];
        }

        public int AddProdut(Product prod)
        {
            ds = GetAllProducts();
            // step1 create new row
            DataRow row = ds.Tables["Product"].NewRow();
            // step2 - add record to the row
            row["name"] = prod.name;
            row["price"] = prod.price;
            row["cid"] = prod.cid;
            // step3 - attach the row to the DataSet
            ds.Tables["Product"].Rows.Add(row);
            // step4 update the changes to DB
            int res = da.Update(ds.Tables["Product"]);
            return res;
        }
        public int UpdateProduct(Product prod)
        {
            ds = GetAllProducts();
            int res = 0;
            // step1 find the row to modify
            DataRow row = ds.Tables["Product"].Rows.Find(prod.id);
            if (row != null)
            {
                // step2 - modify record to the row
                row["name"] = prod.name;
                row["price"] = prod.price;
                row["cid"] = prod.cid;

                // step3 update the changes to DB
                res = da.Update(ds.Tables["Product"]);
            }
            return res;
        }
        public int DeleteProduct(int id)
        {
            ds = GetAllProducts();
            int res = 0;
            // step1 find the row to modify
            DataRow row = ds.Tables["Product"].Rows.Find(id);
            if (row != null)
            {
                // row will be deleted from the DataSet
                row.Delete();
                // step3 update the changes to DB
                res = da.Update(ds.Tables["Product"]);
            }
            return res;
        }
        public Product GetProductById(int id)
        {
            ds = GetAllProducts();
            DataRow row = ds.Tables["Product"].Rows.Find(id);
            Product prod = new Product();
            prod.id = Convert.ToInt32(row["id"]);
            prod.name = row["name"].ToString();
            prod.price = Convert.ToInt32(row["price"]);
            prod.cid = Convert.ToInt32(row["cid"]);
            return prod;
        }


    }

}
