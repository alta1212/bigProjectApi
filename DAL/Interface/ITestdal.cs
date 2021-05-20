using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DAL.Interface
{
   
    //sản phẩm
     public interface IproductDAL
    {
            List<Product> GetNews();
            bool Create(Product model);
            List<Product> Search(string key);
            Product GetDatabyID(string id);
            bool delete (string id);
    }


    //loai san pham
     public interface IcategorytDAL
    {
            List<Categories> GetNews();
            bool Create(Categories model);
            List<Categories> Search(string key);
            Categories GetDatabyID(string id);
            bool delete (string id);
    }
}