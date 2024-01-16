using E_CommerceAppUsingADO.NET.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.BL.Methods
{
    static class CategoryMethods
    {
        public static void Create(Category category)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            para[0].Value = category.Name;
            DA.open();
            DA.ExecuteCommand("CreateCategory", para);
            DA.close();
        }
        public static void Update(Category category, int categoryId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = categoryId;
            para[1] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            para[1].Value = category.Name;
            DA.open();
            DA.ExecuteCommand("UpdateCategory", para);
            DA.close();
        }
        public static void Delete(int categoryId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = categoryId;
            DA.open();
            DA.ExecuteCommand("DeleteCategory", para);
            DA.close();
        }
        public static Category GetById(int categoryId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            DataTable dataTable = new DataTable();
            Category category = new Category();
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = categoryId;
            DA.open();
            dataTable = DA.GetData("GetCategoryById", para);
            DA.close();
            category.Id = categoryId;
            category.Name = Convert.ToString(dataTable.Rows[0][0]);
            return category;
        }
        public static List<Category> GetAll()
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            DataTable dataTable = new DataTable();
            List<Category> categories = new List<Category>();
            DA.open();
            dataTable = DA.GetData("GetAllCategories", null);
            DA.close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                category.Name = Convert.ToString(dataTable.Rows[0][1]);
                categories.Add(category);
            }
            return categories;
        }
    }
}
