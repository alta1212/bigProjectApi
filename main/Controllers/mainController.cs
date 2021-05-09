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
    public class apiController : ControllerBase
    {
        private ITestBUS _newsBusiness;
        public apiController(ITestBUS newBusiness)
        {
            _newsBusiness = newBusiness;
        }
        [Route("get-test")]
        [HttpGet]
        public IEnumerable<Models.test> GetAllMenu()
        {
            return _newsBusiness.GetNews();
        }
      
        [Route("create-item")]
        [HttpPost]
        public test CreateItem([FromBody] test model)
        {
            _newsBusiness.Create(model);
            return model;
        } 
        [Route("get-by-id/{id}/{abc}")]
        [HttpGet]
        public test GetDatabyID(string id)
        {
           
            return _newsBusiness.GetDatabyID(id);
        }
        
        [Route("search")]
        [HttpGet]
        public IEnumerable<Models.test> Search( string key)//
        {   
            var response = new ResponseModel();
            try
            {
                return _newsBusiness.Search(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }



    [ApiController]
    [Route("[controller]")]
    public class productController : ControllerBase
    {
        private IproductBUS _productBusiness;
        public productController(IproductBUS proBusiness)
        {
            _productBusiness = proBusiness;
        }
        [Route("get-product")]
        [HttpGet]
        public IEnumerable<Models.Product> GetAllMenu()
        {
            return _productBusiness.Getproduct();
        }
      
        [Route("create-item")]
        [HttpPost]
        public Product CreateItem([FromBody] Product model)
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
}
