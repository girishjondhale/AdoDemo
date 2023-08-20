using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDemo.Model
{
    internal class ProductCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public ProductCrud()
        {
            string connstr = ConfigurationManager.ConnectionStrings["defaultConnect"].ConnectionString;

            con = new SqlConnection(connstr);
        }
        public int AddProduct(Product prod)
        {
            string qry = "insert into product values (@name,@price,@cid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", prod.name);
            cmd.Parameters.AddWithValue("@price", prod.price);
            cmd.Parameters.AddWithValue("@cid", prod.cid);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;
            con.Close();
        }
        public int UpdateProduct(Product prod)
        {
            // step1 -> qry
            string qry = "update Product set name=@name,price=@price,cid=@cid where id=@id";
            // step2- assign qry to command
            cmd = new SqlCommand(qry, con);
            // step3- pass valeu to the parameters
            cmd.Parameters.AddWithValue("@name", prod.name);
            cmd.Parameters.AddWithValue("@price", prod.price);
            cmd.Parameters.AddWithValue("@cid", prod.cid);
            cmd.Parameters.AddWithValue("@id", prod.id);
            // step4- open the connection
            con.Open();
            //step5- fire the query
            int result = cmd.ExecuteNonQuery();
            //step6- close the conn
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            // step1 -> qry
            string qry = "delete from Product where id=@id";
            // step2- assign qry to command
            cmd = new SqlCommand(qry, con);
            // step3- pass valeu to the parameters
            cmd.Parameters.AddWithValue("@id", id);
            // step4- open the connection
            con.Open();
            //step5- fire the query
            int result = cmd.ExecuteNonQuery();
            //step6- close the conn
            con.Close();
            return result;
        }
        public Product GetProductById(int id)
        {
            Product product = new Product();
            string qry = "select * from Product where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    product.id = Convert.ToInt32(dr["id"]);
                    product.name = dr["name"].ToString();
                    product.price = Convert.ToInt32(dr["price"]);
                    product.cid = Convert.ToInt32(dr["cid"]);
                }
            }
            con.Close();
            return product;
        }

        public List<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            //step1- write a query
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.cid = Convert.ToInt32(dr["cid"]);
                    c.cname = dr["cname"].ToString();
                    list.Add(c);
                }

            }
            con.Close();
            return list;
        }



        public List<Category> GetCategory()
        {
            List<Category> list = new List<Category>();
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category c = new Category();
                    c.cid = Convert.ToInt32(dr["cid"]);
                    c.cname = dr["cname"].ToString();
                    list.Add(c);

                }
            }
            con.Close();
            return list;
        }
    }
}
