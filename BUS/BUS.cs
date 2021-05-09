using System.Threading.Tasks.Dataflow;
using System;
using System.Collections.Generic;
using System.Text;

using Models;
using System.Linq;
using DAL.Interface;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
namespace BUS
{
    public class testBusiness:BUS.Interface.ITestBUS
    {
             private ITestDAL _res;
        
        public testBusiness(ITestDAL  News)
        {
            _res = News;       
        }

        public List<test> GetNews()
        {
            var allNews = _res.GetNews();
            var lstParent = allNews.ToList();
           
            // foreach (var item in lstParent)
            // {
            //     item.list = GetHiearchyList(allNews);
            // }
            return lstParent;
        }
        // public List<test> GetHiearchyList(List<test> lstAll)
        // {
        //     var lstChilds = lstAll.ToList();
        //     if (lstChilds.Count == 0)
        //         return null;
            
        //     return lstChilds.ToList();
        // }
         public bool Create(test model)
        {
            return _res.Create(model);
        }
           public List<test> Search(string key)
        {
            return _res.Search(key);
        }
          public test GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }



     public class productBusiness:BUS.Interface.IproductBUS
    {
        private IproductDAL _res;
        
        public productBusiness(IproductDAL  News)
        {
            _res = News;       
        }

        public List<Product> Getproduct()
        {
            var allNews = _res.GetNews();
            var lstParent = allNews.ToList();
           
            // foreach (var item in lstParent)
            // {
            //     item.list = GetHiearchyList(allNews);
            // }
            return lstParent;
        }
        // public List<test> GetHiearchyList(List<test> lstAll)
        // {
        //     var lstChilds = lstAll.ToList();
        //     if (lstChilds.Count == 0)
        //         return null;
            
        //     return lstChilds.ToList();
        // }
         public bool Create(Product model)
        {
            return _res.Create(model);
        }
           public List<Product> Search(string key)
        {
            return _res.Search(key);
        }
          public Product GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool delete(string id)
        {
            return _res.delete(id);
        }
    }
}
