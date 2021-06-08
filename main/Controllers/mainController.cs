using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
using BUS.Interface;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

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
        [Authorize] 
        [Route("create-item")]
        [HttpPost]
        public Product CreateItem([FromForm] Product model)
        {
            _productBusiness.Create(model);
            return model;
        } 
        [Authorize]
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
        [Authorize]
        [Route("delete/{id}")]
        [HttpGet]
        public bool delete(string id)
        {
           
            return _productBusiness.delete(id);
        }
         [Route("get-all-by-type/{id}")]
         [HttpGet]
        public IEnumerable<Product> getbyttype(string id)
        {
             return _productBusiness.GetDatabytype(id);
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
        [Authorize]
        [Route("create-item")]
        [HttpPost]
        public Categories CreateItem([FromForm] Categories model)
        {
            _CategoriesBusiness.Create(model);
            return model;
        } 
        [Authorize]
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
        [Authorize]
         [Route("allorder")]
        [HttpGet]
        public List<order> getallorder()
        {

           
            return  _userBusiness.getallorder();;
        }
      //  [Authorize(Roles = "admin")]
        [Authorize]
        [Route("orderdetail/{id}")]
        [HttpGet]
        public List<OrderDetails> all(string id)
        {
            return _userBusiness.getallorderdetail(id);
        }

       



 

}

    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private IadminBUS _IadminBUS;
        private IConfiguration _config;   
        public AdminController(IadminBUS proBusiness,IConfiguration config)
        {   _config = config;  
            _IadminBUS = proBusiness;
        }
        public string token(string type)
        {
                 var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
                        var Claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Role, type),
                        };
                        var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
                        _config["Jwt:Issuer"],    
                        Claims,    
                        expires: DateTime.Now.AddDays(1),    
                        signingCredentials: credentials);    
                
                        return new JwtSecurityTokenHandler().WriteToken(token);    
        }


        [HttpPost]
        [Route("login")]
        public admin Login([FromForm] admin User)
        {
                var user=_IadminBUS.login(User);
                if(user!=null)
                {
                       user.token= token(user.Admin_type);
                       return user;
                }
                else
                {
                        return null;
                }
              
        }
        
        [HttpGet]
        [Route("getall")]
        [Authorize(Roles = "admin")]
        public IEnumerable<Models.admin>  getall()
        {
              return _IadminBUS.getalladmin();
              
        }
    
    
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("delete/{id}")]
        public int delete(int id)
        {
            return _IadminBUS.delete(id);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("admin/{id}")]
        public admin getbyid(int id)
        {
               return _IadminBUS.byid(id);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("create")]
        public int create([FromForm] admin a)
        {

               return _IadminBUS.create(a);
        }

        [HttpPost]
        [Authorize]
        [Route("updateorder")]
        public int update([FromBody] IEnumerable<OrderDetails> model)
        {
                
               return _IadminBUS.orderdetailupdate(model);
        }
    }