using E_CommerceAppUsingADO.NET.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.PL
{
     class OrderUI
    {
        public Order CreateOrder(int userId, int prodcutId)
        {
            int quantity;
            bool checkValidQuantity;
            do
            {
                Console.WriteLine("Enter Quantity OF Product");
                checkValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
                //check quantity of product available or not
            } while (!checkValidQuantity);
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Quantity = quantity;
            order.UserId = userId;
            // order.TotalPrice = quantity * (price through productId)
            return order;
        }
        public Order UpdateOrder(int userId, int prodcutId,int orderId)
        {
            int quantity;
            bool checkValidQuantity;
            do
            {
                Console.WriteLine("Enter New Quantity OF Product");
                checkValidQuantity = int.TryParse(Console.ReadLine(), out quantity);
                //check quantity of product available or not
            } while (!checkValidQuantity);
            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Quantity = quantity;
            order.UserId = userId;
            // order.TotalPrice = quantity * (price through productId)
            return order;
        }
    }
}
