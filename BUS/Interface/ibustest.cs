using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BUS.Interface
{
    public partial interface ITestBUS
    {
        bool Create(test model);
        List<test> GetNews();
        List<test> Search(string key);
        test GetDatabyID(string id);
    }


    //sản phẩm
    public partial interface IproductBUS
    {
        bool Create(Product model);
        List<Product> Getproduct();
        List<Product> Search(string key);
        Product GetDatabyID(string id);
        bool delete(string id);
    }
}
