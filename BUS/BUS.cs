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
    //san pham
     public class productBusiness:BUS.Interface.IproductBUS
    {
        private IproductDAL _res;
        
        public productBusiness(IproductDAL  News)
        {
            _res = News;       
        }

        public IEnumerable<Product> GetDatabytype(string id)
        {
            return _res.GetDatabytype(id);
        }
        public List<Product> Getproduct(int k)
        {
            var allNews = _res.GetNews(k);
            var lstParent = allNews.ToList();
           
            // foreach (var item in lstParent)
            // {
            //     item.list = GetHiearchyList(allNews);
            // }
            return lstParent;
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

           public bool update(Product model)
        {
            return _res.update(model);
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
    //loai san pham
       public class CategoriesBusiness:BUS.Interface.ICategoriesBUS

    {
        private IcategorytDAL _res;
        
        public CategoriesBusiness(IcategorytDAL  News)
        {
            _res = News;       
        }

        public List<Categories> GetCategories()
        {
            var allNews = _res.GetNews();
            var lstParent = allNews.ToList();
           
            // foreach (var item in lstParent)
            // {
            //     item.list = GetHiearchyList(allNews);
            // }
            return lstParent;
        }
        // public List<Categories> GetHiearchyList(List<Categories> lstAll)
        // {
        //     var lstChilds = lstAll.ToList();
        //     if (lstChilds.Count == 0)
        //         return null;
            
        //     return lstChilds.ToList();
        // }
      
         public bool Create(Categories model)
        {
            return _res.Create(model);
        }
          public bool Update(Categories model)
        {
            return _res.Update(model);
        }
           public List<Categories> Search(string key)
        {
            return _res.Search(key);
        }
          public Categories GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool delete(string id)
        {
            return _res.delete(id);
        }
    }

    public class userBusiness:BUS.Interface.IuserBUS
    {
        private IuserDAL _res;
        
        public userBusiness(IuserDAL  News)
        {
            _res = News;       
        }
        public List<order> getallordeuser(string phone)
        {
            return _res.getallordeuser(phone);
        }
        public bool Createorder(order model)
        {
            return _res.Createorder(model);
        }
        public  IEnumerable<cart> orderDetails(IEnumerable<cart> model)
        {
            return _res.orderDetails(model);
        }
        public List<order> getallorder()
        {
            return _res.getallorder();
        }
       public List<OrderDetails> getallorderdetail(string id){
           return _res.getallorderdetail(id);
       }
    }
   


    public class adminBusiness:BUS.Interface.IadminBUS
    {
         private IadminDAL _res;
         public  admin byid(int a)
         {
             return _res.getbyid(a);
         }
        
        public adminBusiness(IadminDAL  News)
        {
            _res = News;       
        }

        public List<admin> getalladmin()
        {
            return _res.getall();
        }

        public admin login(admin a)
        {
            return _res.login(a);
        }
        public int delete(int a)
        {
            return _res.delete(a);
        }
        public  int create(admin a)
        {
            return _res.create(a);
        }

        public   int orderdetailupdate( IEnumerable<OrderDetails> s)
        {
            return _res.orderdetailupdate(s);
        }
    }
}
