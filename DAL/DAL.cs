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

        public List<Product> GetNews()
        {
            string msgError = "";
            
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GETALL_PRODUCTS");
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
          public Product GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_get_by_id",
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
            // string msgError = "";
            // try
            // {
            //     var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "CREATE_ITEM_PRODUCTS",
            //     "@NAME", model.Product_Name,
            //     "@PRICE", model.Price,
            //     "@CATEGORY_ID",model.Category_ID,
            //     "@image", model.image);
            //     if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
            //     {
            //         throw new Exception(Convert.ToString(result) + msgError);
            //     }
            //     return true;
            // }
            // catch (Exception ex)
            // {
            //     throw ex;
            // }
            return true;
        }
          public Categories GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_get_by_id",
                     "@id", id);
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

}
