using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace DAL.Interface
{
    public interface ITestDAL
    {
            List<test> GetNews();
            bool Create(test model);
            List<test> Search(string key);
            test GetDatabyID(string id);
    }

    //sản phẩm
     public interface IproductDAL
    {
            List<Product> GetNews();
            bool Create(Product model);
            List<Product> Search(string key);
            Product GetDatabyID(string id);
            bool delete (string id);
    }
}