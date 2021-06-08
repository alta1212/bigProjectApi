using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BUS.Interface
{
 


    //sản phẩm
    public partial interface IproductBUS
    {
        bool Create(Product model);
        bool update(Product model);
        List<Product> Getproduct(int k);
          List<Product> Getproduct();
        List<Product> Search(string key);
        Product GetDatabyID(string id);
        bool delete(string id);
        IEnumerable<Product> GetDatabytype(string id);
    }
    //loai san pham
      public partial interface ICategoriesBUS
      {
        bool Create(Categories model);
        bool Update(Categories model);
        List<Categories> GetCategories();
        List<Categories> Search(string key);
        Categories GetDatabyID(string id);
        bool delete(string id);
    }
    public partial interface IuserBUS
      {
        bool Createorder(order model);
        // bool Update(Categories model);
        // List<Categories> GetCategories();
        // List<Categories> Search(string key);
        IEnumerable<cart> orderDetails(IEnumerable<cart> model);
        // bool delete(string id);
        List<order> getallorder();
         List<OrderDetails> getallorderdetail(string id);
    }
    public partial interface IadminBUS
    {
      admin login(admin a);
       List<admin> getalladmin();
        public int delete(int a);
        admin byid(int a);
        int create(admin a);
          int orderdetailupdate( IEnumerable<OrderDetails> s);
    }
}
