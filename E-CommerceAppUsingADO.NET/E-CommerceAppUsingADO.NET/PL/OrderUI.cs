using ConsoleTables;
using E_CommerceAppUsingADO.NET.BL.Dtos;
using E_CommerceAppUsingADO.NET.BL.Enums;
using E_CommerceAppUsingADO.NET.BL.Methods;
using E_CommerceAppUsingADO.NET.BL.Models;
using E_CommerceAppUsingADO.NET.BL.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.PL
{
     class OrderUI
    {
        public static int orderId;
        public static void CRUDOrder(int userId)
        {
            Console.WriteLine("1-Add Order");
            Console.WriteLine("2-Update Order");
            Console.WriteLine("3-Delete Order");
            Console.WriteLine("4-Get All Your Orders");
            int ch;
            do
            {
                ch = Console.ReadKey().KeyChar;
                CRUD orderOperaions = (CRUD)ch;
                switch (orderOperaions)
                {
                    case CRUD.Create:
                        CreateOrderDetails(userId);
                        break;
                    case CRUD.Update:
                        UpdateOrderDetails(orderId);
                        break;
                    case CRUD.GetById:
                        DisplayAllOrderDetailsOFUser(userId);
                        break;
                    case CRUD.Delete:
                        DeleteOrderDetails(orderId);
                        break;
                }

            } while (ch >= 49 && ch <= 52);
        }
        public static void CreateOrder(int userId)
        {
            orderId = OrderMethods.Create(userId);
        }
        public static void CreateOrderDetails(int userId)
        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            char c;
            decimal finalPrice = 0;
            do
            {
                Product product = new Product();
                product = ProductValidations.checkProductNameValidation();
                int quantity = ProductValidations.validQuantity(product.Id);
                if (quantity == 0)
                {
                    Console.ReadKey();
                    return;
                }
                else
                {
                    if (orderId == 0)
                        CreateOrder(userId);
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.OrderId = orderId;
                    orderDetails.ProductId = product.Id;
                    orderDetails.Quantity = quantity;
                    orderDetails.TotalPrice = product.Price * quantity;
                    finalPrice += orderDetails.TotalPrice;
                    OrderDetailsMethods.CreateOrderDetails(orderDetails);
                    BaseValidation.DisplayTextWithGreenColor("Order Created Successfully......");
                    orderDetailsList.Add(orderDetails);
                    DisplayOrderDetails(orderDetailsList);
                    Console.WriteLine("are you want to continue ? y/n");
                }
                c = Console.ReadKey().KeyChar;
            } while (c != 'n');
            DisplayFinalPrice(finalPrice);
            Console.ReadKey();
        }
        public static void UpdateOrderDetails(int orderId)
        {
            Product product = new Product();
            product = ProductValidations.checkProductNameValidation();
            DataTable dataTable = OrderDetailsMethods.GetOrderDetailsOFProduct(orderId, product.Id);
            if (dataTable.Rows.Count == 0)
                BaseValidation.DisplayTextWithRedColor("You Not Orderd This Product");
            else
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.ProductId = Convert.ToInt32(dataTable.Rows[0][0]);
                orderDetails.OrderId = Convert.ToInt32(dataTable.Rows[0][1]);
                orderDetails.Quantity = Convert.ToInt32(dataTable.Rows[0][2]);
                orderDetails.TotalPrice = Convert.ToDecimal(dataTable.Rows[0][3]);
                OrderDetailsMethods.DeleteOrderDetails(orderDetails);
                int quantity = ProductValidations.validQuantity(product.Id);
                orderDetails.OrderId = orderId;
                orderDetails.ProductId = product.Id;
                orderDetails.Quantity = quantity;
                orderDetails.TotalPrice = product.Price * quantity;
                OrderDetailsMethods.CreateOrderDetails(orderDetails);
                BaseValidation.DisplayTextWithGreenColor("Order Updated Successfully......");
                DisplayOrderDetails(new List<OrderDetails>() { orderDetails });
            }
            Console.ReadKey();
        }
        public static void DeleteOrderDetails(int orderId)
        {
            Product product = new Product();
            product = ProductValidations.checkProductNameValidation();
           DataTable dataTable = OrderDetailsMethods.GetOrderDetailsOFProduct(orderId, product.Id);
            if (dataTable.Rows.Count == 0)
                BaseValidation.DisplayTextWithRedColor("You Not Orderd This Product");
            else
            {
                char c;
                do
                {
                    Console.WriteLine("Are you sure you want to delete this order ? (y/n) : ");
                    c = Console.ReadKey().KeyChar;
                } while (c != 'y' && c != 'n');
                if (c == 'y')
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = Convert.ToInt32(dataTable.Rows[0][0]);
                    orderDetails.OrderId = Convert.ToInt32(dataTable.Rows[0][1]);
                    orderDetails.Quantity = Convert.ToInt32(dataTable.Rows[0][2]);
                    orderDetails.TotalPrice = Convert.ToDecimal(dataTable.Rows[0][3]);
                    OrderDetailsMethods.DeleteOrderDetails(orderDetails);
                    BaseValidation.DisplayTextWithGreenColor("Order Deleted Successfully......");
                }
            }
            Console.ReadKey();
        }
        public static void DisplayFinalPrice(decimal FinalPrice)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var table = new ConsoleTable("Final Price");
                table.AddRow(FinalPrice);
            table.Write();
            Console.ResetColor();
        }
        public static void DisplayOrderDetails(List<OrderDetails> orderDetails)
        {
            var table = new ConsoleTable("Product Name", "Quantity", "Product Price", "Total Price");
            foreach (var orderdetails in orderDetails)
            {
                table.AddRow(Productmethods.GetById(orderdetails.ProductId).Name, orderdetails.Quantity,Productmethods.GetById(orderdetails.ProductId).Price, orderdetails.TotalPrice);
            }
            table.Write();
        }
        public static void DisplayAllOrder()
        {
            DataTable dataTable = OrderMethods.getAllOrders();
            if (dataTable.Rows.Count == 0)
                BaseValidation.DisplayTextWithRedColor("No Orders yet....");
            else
            {
                var table = new ConsoleTable("Full Name", "Email", "Order Date", "Final Price");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DIsplayAllOrdersDto displayOrdersDto = new DIsplayAllOrdersDto();
                    displayOrdersDto.FullName = Convert.ToString(dataTable.Rows[0][0]);
                    displayOrdersDto.Email = Convert.ToString(dataTable.Rows[0][1]);
                    displayOrdersDto.OrderDate = Convert.ToDateTime(dataTable.Rows[0][2]);
                    displayOrdersDto.FinalPrice = Convert.ToDecimal(dataTable.Rows[0][3]);
                    table.AddRow(displayOrdersDto.FullName, displayOrdersDto.Email, displayOrdersDto.OrderDate, displayOrdersDto.FinalPrice);
                }
                table.Write();
            }
            Console.ReadKey();
        }
        public static void DisplayOrdersOFUser(int userId)
        {
            DataTable dataTable = OrderMethods.getAllOrdersOFUser(userId);
            if (dataTable.Rows.Count == 0)
                BaseValidation.DisplayTextWithRedColor("No Orders");
            else
            {
                var table = new ConsoleTable("Order Date", "Final Price");
                for (int i=0;i<dataTable.Rows.Count;i++)
                {
                    DisplayOrdersOFUserDto displayOrdersDto = new DisplayOrdersOFUserDto();
                    displayOrdersDto.OrderDate = Convert.ToDateTime(dataTable.Rows[i][0]);
                    displayOrdersDto.FinalPrice = Convert.ToDecimal(dataTable.Rows[i][1]);
                    table.AddRow(displayOrdersDto.OrderDate, displayOrdersDto.FinalPrice);
                }
                table.Write();
            }
            Console.ReadKey();
        }
        public static void DisplayAllOrderDetailsOFUser(int userId)
        {
            DataTable dataTable = OrderDetailsMethods.getOrderDetailsOFUser(userId);
            if (dataTable.Rows.Count == 0)
                BaseValidation.DisplayTextWithRedColor("No Orders");
            else
            {
                var table = new ConsoleTable("Product Name", "Quantity", "Price", "Total Price");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DisplayOrderDetailsDto displayOrderDetailsDto = new DisplayOrderDetailsDto();
                    displayOrderDetailsDto.ProductName = Convert.ToString(dataTable.Rows[i][0]);
                    displayOrderDetailsDto.Quantity = Convert.ToInt32(dataTable.Rows[i][1]);
                    displayOrderDetailsDto.Price = Convert.ToDecimal(dataTable.Rows[i][2]);
                    displayOrderDetailsDto.TotalPrice = Convert.ToDecimal(dataTable.Rows[i][3]);
                    table.AddRow(displayOrderDetailsDto.ProductName, displayOrderDetailsDto.Quantity, displayOrderDetailsDto.Price, displayOrderDetailsDto.TotalPrice);
                }
                table.Write();
                DisplayOrdersOFUser(userId);
            }
        }
    }
}
