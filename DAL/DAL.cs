using System;
using System.Collections.Generic;

using DAL.Interface;
using Models;
using DAL.Helper;
using System.Linq;
namespace DAL
{


    //sản phẩm
    public class productRepository:IproductDAL
    {
        private IDatabaseHelper _dbHelper;
        public productRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Product> GetNews(int k)
        {
            string msgError = "";
            
            try 
            {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GET_ITEM_PRODUCTS",
                     "@Pageindex", k);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public List<Product> GetNews()
        {
            string msgError = "";
            
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getAllproduct");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public bool Create(Product model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "CREATE_ITEM_PRODUCTS",
                "@NAME", model.Product_Name,
                "@PRICE", model.Price,
                "@CATEGORY_ID",model.Category_ID,
                "@image", model.image);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public bool update(Product model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "UPDATE_ITEM_PRODUCTS",
                "@NAME", model.Product_Name,
                "@PRICE", model.Price,
                "@CATEGORY_ID",model.Category_ID,
                "@image", model.image);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public Product GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GET_ITEM_PRODUCTS_ID",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public List<Product> Search(string key)
        {
             string msgError = "";
            try
            {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search",
                "@key", key);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool delete(string key)
        {
            string msgError = "";
            try
            {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_delete",
                "@key", key);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public class CategoryRepository:IcategorytDAL
    {
        private IDatabaseHelper _dbHelper;
        public CategoryRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Categories> GetNews()
        {
            string msgError = "";
            
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GETALL_CATEGORIES");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Categories>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public bool Create(Categories model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "CREATE_ITEM_Categories",
                "@NAME", model.Category_Name,
                "@image",model.image,
                "@parentid",model.parentid
             );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

          public bool Update(Categories model)
        {
            string msgError = "";
            try
            {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "update_Categories_id",
                "@key", model.Category_ID,
                "@name",model.Category_Name);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


          public Categories GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_Categories_id",
                     "@key", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Categories>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public List<Categories> Search(string key)
        {
             string msgError = "";
            try
            {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search",
                "@key", key);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<Categories>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool delete(string key)
        {
            string msgError = "";
            try
            {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "category_item_delete",
                "@key", key);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class userRepository:IuserDAL
    {
        private IDatabaseHelper _dbHelper;
        public userRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        static int id=3;
        public bool Createorder(order model)
        {
            string query=string.Format("insert into Orders (Order_Name,CreatedDate,Phone,Address)  OUTPUT INSERTED.Order_ID VALUES (N'{0}',N'{1}',N'{2}',N'{3}')",model.Order_Name,DateTime.Today,model.Phone,model.Address);
           id= _dbHelper.getLastId(query);
            
             return true;
        }

         public IEnumerable<cart> orderDetails (IEnumerable<cart>  model)
         {
            int j= id;
            string msgError = "";
            foreach(cart  i in model)
            {

                     var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "oderdetail",
                "@OrderDetail_OrderID", i.id,
                "@OrderDetail_Name",i.label,
                "@Quantity",i.quantity,
                "@total",i.price
            );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
            }
            return model;
         }
    }

}
