using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{   
    public class test
    {
        public string id { get; set; }

        public string name { get; set; }

     
    }
    public class testList{
           public List<test> list { get; set; }
    }

    // sản phảm
    public class Product
    {
        public string Product_ID { get; set; }

        public string Product_Name { get; set; }
        public string Price { get; set; }

        public string Category_ID { get; set; }
    }
    public class ProductList
    {
          public List<Product> list { get; set; }
    }
}
