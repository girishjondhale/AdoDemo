using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo.Model
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public int price { get; set; }

        public int cid { get; set; }
    }

    public class Category
    {
        public int cid { get; set; }
        public string cname { get; set; }
    }
}
