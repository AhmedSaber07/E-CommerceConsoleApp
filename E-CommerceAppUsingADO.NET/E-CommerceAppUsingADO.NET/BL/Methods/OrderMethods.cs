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
     class OrderMethods
    {
        public static int Create(int userId)
        {
            int orderId=0;
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@finalPrice", SqlDbType.Decimal);
            para[0].Value = 0;
            para[1] = new SqlParameter("@userId", SqlDbType.Int);
            para[1].Value = userId;
            para[2] = new SqlParameter("@orderId", SqlDbType.Int);
            para[2].Direction = ParameterDirection.Output;
            DA.open();
            DA.ExecuteCommand("createOrder", para);
            orderId = Convert.ToInt32(para[2].Value);
            DA.close();
            return orderId;
        }
        //public static int GetCountOFOrdersBySpecificProduct(int productId)
        //{
        //    DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
        //    SqlParameter[] para = new SqlParameter[1];
        //    DataTable dataTable = new DataTable();
        //    para[0] = new SqlParameter("@id", SqlDbType.Int);
        //    para[0].Value = productId;
        //    DA.open();
        //    dataTable = DA.GetData("GetCountOFOrdersByProductId", para);
        //    DA.close();
        //    return Convert.ToInt32(dataTable.Rows[0][0]);
        //}
        public static DataTable getAllOrders()
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            DataTable dataTable = new DataTable();
            DA.open();
            dataTable = DA.GetData("getAllOrders", null);
            DA.close();
            return dataTable;
        }
        public static DataTable getAllOrdersOFUser(int userId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            DataTable dataTable = new DataTable();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@userId", SqlDbType.Int);
            para[0].Value = userId;
            DA.open();
            dataTable = DA.GetData("getAllOrdersOFUser",para);
            DA.close();
            return dataTable;
        }
    }
}
