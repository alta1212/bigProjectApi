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
        public string mota { get; set; }

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
        public int parentid { get; set; }

    }
    public class CategoriesList
    {
          public List<Categories> list { get; set; }
    }
    //order
    public class order
    {
        public string Order_ID { get; set; }
        public string Order_Name { get; set; }

        public string Address { get; set; }

        public string CreatedDate { get; set; }

        public string Phone { get; set; }
        public string total  { get; set; }

    }
    public class orderList
    {
          public List<order> list { get; set; }
    }


    //order detail
      public class OrderDetails
    {
        public string OrderDetail_ID { get; set; }
        public string OrderDetail_OrderID { get; set; }

        public string OrderDetail_Name { get; set; }
         public string OrderDetail_Image { get; set; }

        public string Quantity { get; set; }

        public string total { get; set; }
        public string price{ get; set; }

    }
    public class OrderDetailsList
    {
          public List<OrderDetails> list { get; set; }
    }

    public class cart
    {
        public string id { get; set; }
        public string image { get; set; }

        public string label { get; set; }

        public string price { get; set; }
        public string quantity { get; set; }
    }

     public class admin
    {
        public string Admin_ID { get; set; }
        public string Admin_email { get; set; }

        public string Admin_password { get; set; }

        public string Admin_type { get; set; }
        public string Admin_Phone { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_Image { get; set; }
        public string token { get; set; }
        
    }
}
