using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{   
   
    // sản phảm
    public class Product
    {
        public string Product_ID { get; set; }

        public string Product_Name { get; set; }
        public string Price { get; set; }

        public string Category_ID { get; set; }
        public string image { get; set; }

        public int total { get; set; }

    }
    public class ProductList
    {
          public List<Product> list { get; set; }
    }
    //loai san pham
    
    public class Categories
    {
        public string Category_ID { get; set; }
        public string image { get; set; }

        public string Category_Name { get; set; }
         public int total { get; set; }

    }
    public class CategoriesList
    {
          public List<Categories> list { get; set; }
    }
}
