using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
using BUS.Interface;

namespace main.Controllers
{

    [ApiController]
    [Route("[controller]")]
   
    public class productController : ControllerBase
    {
        private IproductBUS _productBusiness;
        
        public productController(IproductBUS proBusiness)
        {
            _productBusiness = proBusiness;
        }
        [Route("get-product/{page}")]
        [HttpGet]
        public IEnumerable<Models.Product> GetAllMenu(int page)
        {
            return _productBusiness.Getproduct(page);
        }
       
         [Route("get-all")]
        [HttpGet]
        public IEnumerable<Models.Product> GetAll()
        {
            return _productBusiness.Getproduct();
        }

        [Route("create-item")]
        [HttpPost]
        public Product CreateItem([FromForm] Product model)
        {
            _productBusiness.Create(model);
            return model;
        } 

        [Route("update-item")]
        [HttpPost]
        public Product updateItem([FromForm] Product model)
        {
            _productBusiness.Create(model);
            return model;
        } 
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Product GetDatabyID(string id)
        {
           
            return _productBusiness.GetDatabyID(id);
        }
        
        [Route("search")]
        [HttpGet]
        public IEnumerable<Models.Product> Search( string key)//
        {   
            var response = new ResponseModel();
            try
            {
                return _productBusiness.Search(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [Route("delete/{id}")]
        [HttpGet]
        public bool delete(string id)
        {
           
            return _productBusiness.delete(id);
        }
    }


    [ApiController]
    [Route("[controller]")]
   
    public class CategoriesController : ControllerBase
    {
        private ICategoriesBUS _CategoriesBusiness;
        
        public CategoriesController(ICategoriesBUS proBusiness)
        {
            _CategoriesBusiness = proBusiness;
        }
        [Route("get-Category")]
        [HttpGet]
        public IEnumerable<Models.Categories> GetAllMenu()
        {
            return _CategoriesBusiness.GetCategories();
        }
      
        [Route("create-item")]
        [HttpPost]
        public Categories CreateItem([FromForm] Categories model)
        {
            _CategoriesBusiness.Create(model);
            return model;
        } 
        [Route("update-item")]
        [HttpPost]
        public Categories UpdateItem([FromForm] Categories model)
        {
            _CategoriesBusiness.Update(model);
            return model;
        } 
        [Route("get-by-id/{id}")]
        [HttpGet]
        public Categories GetDatabyID(string id)
        {
           
            return _CategoriesBusiness.GetDatabyID(id);
        }
        
        [Route("search")]
        [HttpGet]
        public IEnumerable<Models.Categories> Search( string key)//
        {   
            var response = new ResponseModel();
            try
            {
                return _CategoriesBusiness.Search(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [Route("delete/{id}")]
        [HttpGet]
        public bool delete(string id)
        {
           
            return _CategoriesBusiness.delete(id);
        }

        // test tiếng việt cho bambo a á ơ đây là thử viết ừ ứccc chế @@
    }
}


    [ApiController]
    [Route("[controller]")]
   
    public class userController : ControllerBase
    {
        private IuserBUS _userBusiness;
        
        public userController(IuserBUS proBusiness)
        {
            _userBusiness = proBusiness;
        }
        [Route("get-Category")]
        [HttpGet]
        // public IEnumerable<Models.Categories> GetAllMenu()
        // {
        //     return _CategoriesBusiness.GetCategories();
        // }
      
        [Route("create-order")]
        [HttpPost]
        public order CreateItem([FromForm] order model)
        {
            _userBusiness.Createorder(model);
            return model;
        } 
        [Route("order-detail-insert")]
        [HttpPost]
        public IEnumerable<cart> insertorderdetail([FromBody] IEnumerable<cart> model)
        {

            _userBusiness.orderDetails(model);
            return model;
        }
    }

