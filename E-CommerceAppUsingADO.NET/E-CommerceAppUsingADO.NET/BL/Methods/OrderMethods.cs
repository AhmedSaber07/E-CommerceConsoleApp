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
    static class OrderMethods
    {
        public static void CreateOrder(Order order,int userId,int productId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[4];
            SqlParameter[] para2 = new SqlParameter[2];
            int availableQuatity = Productmethods.GetAvaliableQuantityOFProduct(productId);
            if (availableQuatity < order.Quantity)
                Console.WriteLine("This Quantity is Not Available");
            else
            {
                int orderId=0;
                para[0] = new SqlParameter("@quantity", SqlDbType.NVarChar, 50);
                para[0].Value = order.Quantity;

                para[1] = new SqlParameter("@totalPrice", SqlDbType.Float);
                para[1].Value = order.TotalPrice;

                para[2] = new SqlParameter("@orderDate", SqlDbType.DateTime);
                para[2].Value = DateTime.Now;

                para[3] = new SqlParameter("@userId", SqlDbType.Int);
                para[3].Value = userId;

                para[4] = new SqlParameter("@orderId", SqlDbType.Int);
                para[4].Direction = ParameterDirection.Output;
                para[4].Value = orderId;

                DA.open();
                DA.ExecuteCommand("CreateOrder", para);
                para2[0] = new SqlParameter("ProductId",SqlDbType.Int);
                para2[0].Value = productId;
                para2[1] = new SqlParameter("OrderId", orderId);
                para2[1].Value = orderId;
                DA.ExecuteCommand("InsertInProductOrderTb",para2);
                DA.close();
            }
        }
        public static void UpdateOrder(int orderId,int userId,int productId)
        {
            Order order = GetOrderById(orderId);
            int availableQuatity = Productmethods.GetAvaliableQuantityOFProduct(productId);
            if ((DateTime.Now - order.OrderDate).TotalMinutes > 5)
                Console.WriteLine("Can't Modify Order. Order is Confirmed!!");
            else if (availableQuatity < order.Quantity)
                Console.WriteLine("This Quantity is Not Available");
            else
            {
                DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
                SqlParameter[] para = new SqlParameter[4];
                SqlParameter[] para2 = new SqlParameter[2];
                    para[0] = new SqlParameter("@quantity", SqlDbType.NVarChar, 50);
                    para[0].Value = order.Quantity;

                    para[1] = new SqlParameter("@totalPrice", SqlDbType.Float);
                    para[1].Value = order.TotalPrice;

                    para[2] = new SqlParameter("@orderDate", SqlDbType.DateTime);
                    para[2].Value = DateTime.Now;

                    para[3] = new SqlParameter("@userId", SqlDbType.Int);
                    para[3].Value = userId;

                    para[4] = new SqlParameter("@orderId", SqlDbType.Int);
                    para[4].Direction = ParameterDirection.Output;
                    para[4].Value = orderId;

                    DA.open();
                    DA.ExecuteCommand("CreateOrder", para);
                    para2[0] = new SqlParameter("ProductId", SqlDbType.Int);
                    para2[0].Value = productId;
                    para2[1] = new SqlParameter("OrderId", orderId);
                    para2[1].Value = orderId;
                    DA.ExecuteCommand("UpdateInProductOrderTb", para2);
                    DA.close();
            }

        }
        public static void DeleteOrder(int orderId,int userId,int productId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@orderId", SqlDbType.Int);
            para[0].Value = orderId;
            para[1] = new SqlParameter("@userId", SqlDbType.Int);
            para[1].Value = productId;
            para[2] = new SqlParameter("@productId", SqlDbType.Int);
            para[2].Value = userId;
            DA.open();
            DA.ExecuteCommand("DeleteOrder", para);
            SqlParameter[] para1 = new SqlParameter[2];
            para1[0] = new SqlParameter("@orderId", SqlDbType.Int);
            para1[0].Value = orderId;
            para1[1] = new SqlParameter("@productId", SqlDbType.Int);
            para1[1].Value = productId;
            DA.ExecuteCommand("DeleteFromProductOrderTb", para1);
            DA.close();
        }
        public static Order GetOrderById(int orderId)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            DataTable dataTable = new DataTable();
            Order order = new Order();
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = orderId;
            DA.open();
            dataTable = DA.GetData("GetOrderById", para);
            DA.close();
            order.Id = orderId;
            order.Quantity = Convert.ToInt32(dataTable.Rows[0][0]);
            order.TotalPrice = Convert.ToDouble(dataTable.Rows[0][1]);
            order.OrderDate = Convert.ToDateTime(dataTable.Rows[0][2]);
            order.UserId= Convert.ToInt32(dataTable.Rows[0][3]);
            return order;
        }
        public static List<Order> GetOrderByUserId(int userId)
        {
            List<Order> orders = new List<Order>();
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[1];
            DataTable dataTable = new DataTable();
            para[0] = new SqlParameter("@id", SqlDbType.Int);
            para[0].Value = userId;
            DA.open();
            dataTable = DA.GetData("GetOrderById", para);
            DA.close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Order order = new Order();
                order.UserId = userId;
                order.Quantity = Convert.ToInt32(dataTable.Rows[0][0]);
                order.TotalPrice = Convert.ToDouble(dataTable.Rows[0][1]);
                order.OrderDate = Convert.ToDateTime(dataTable.Rows[0][2]);
                order.Id = Convert.ToInt32(dataTable.Rows[0][3]);
                orders.Add(order);
            }
            return orders;
        }
        public static List<Order> GetAll()
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            DataTable dataTable = new DataTable();
            List<Order> orders = new List<Order>();
            DA.open();
            dataTable = DA.GetData("GetAllOrders", null);
            DA.close();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Order order = new Order();
                order.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                order.Quantity = Convert.ToInt32(dataTable.Rows[0][1]);
                order.TotalPrice = Convert.ToDouble(dataTable.Rows[0][2]);
                order.OrderDate = Convert.ToDateTime(dataTable.Rows[0][3]);
                order.UserId = Convert.ToInt32(dataTable.Rows[0][4]);
                orders.Add(order);
            }
            return orders;
        }
    }
}
