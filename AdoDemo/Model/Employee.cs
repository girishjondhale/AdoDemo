using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo.Model
{
    public class Employee
    {
        
            public int id { get; set; }

            public string name { get; set; }

            public int sal { get; set; }

            public int did { get; set; }
        }

        public class Department
        {
            public int did { get; set; }
            public string dname { get; set; }
        }
    
}
