using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DAL.Interface
{
   
    //sản phẩm
     public interface IproductDAL
    {
            List<Product> GetNews(int k);
             List<Product> GetNews();
            bool Create(Product model);
             bool update(Product model);
            List<Product> Search(string key);
            Product GetDatabyID(string id);
            bool delete (string id);
            IEnumerable<Product> GetDatabytype(string id);
    }


    //loai san pham
     public interface IcategorytDAL
    {
            List<Categories> GetNews();
            bool Create(Categories model);
             bool Update(Categories model);
            List<Categories> Search(string key);
            Categories GetDatabyID(string id);
            bool delete (string id);
    }

       public interface IuserDAL
        {
            
            bool Createorder(order model);
               IEnumerable<cart>  orderDetails(IEnumerable<cart> model);

               List<order> getallorder();
               List<OrderDetails> getallorderdetail(string id);
               List<order> getallordeuser(string phone);
        }   
        public interface IadminDAL
        {
                admin login(admin a);
                List<admin> getall();
                public int delete(int s);
                 admin getbyid(int a);
                 int create(admin a);
                 int orderdetailupdate( IEnumerable<OrderDetails> s);
        }

        
     
}