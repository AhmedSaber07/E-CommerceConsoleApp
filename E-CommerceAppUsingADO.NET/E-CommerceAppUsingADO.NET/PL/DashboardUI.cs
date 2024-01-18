using ConsoleTables;
using E_CommerceAppUsingADO.NET.BL.Enums;
using E_CommerceAppUsingADO.NET.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.PL
{
     class DashboardUI
    {
        #region while
        /* while (true)
            {
                Console.Clear();
                PrintHeader("E-COMMERCE DASHBOARD");

        Console.WriteLine("1. View Products");
                Console.WriteLine("2. View Orders");
                Console.WriteLine("3. Add Admin");
                Console.WriteLine("4. View Order History");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayProducts();
                        break;
                    case "2":
                        ViewOrders();
                        break;
                    case "3":
                        addAdmin();
                        break;
                    case "4":
                        ViewOrderHistory();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
}*/
#endregion
    static void DisplayProducts()
    {
        Console.Clear();
        PrintHeader("AVAILABLE PRODUCTS");

        var table = new ConsoleTable("ID", "Product", "Price");
        table.AddRow(1, "Product A", "$10.99");
        table.AddRow(2, "Product B", "$19.99");
        table.AddRow(3, "Product C", "$5.99");

        table.Write();
        Console.WriteLine("\nPress any key to return to the dashboard.");
        Console.ReadKey();
    }

    static void ViewOrders()
    {
        Console.Clear();
        PrintHeader("SHOPPING CART");

        var table = new ConsoleTable("Item", "Product", "Quantity", "Total");
        table.AddRow(1, "Product A", 2, "$21.98");
        table.AddRow(2, "Product C", 1, "$5.99");

        table.Write();
        Console.WriteLine("\nPress any key to return to the dashboard.");
        Console.ReadKey();
    }

    static void addAdmin()
    {
        Console.Clear();
        PrintHeader("Add Admin");

        Console.Clear();
        PrintHeader("Admin REGISTRATION");

        // Get user details
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // Register user
        bool registrationSuccess = RegisterUser(name, email, password);

        // Display welcome message or error
        if (registrationSuccess)
        {
            Console.Clear();
            PrintHeader("WELCOME TO THE DASHBOARD");
            Console.WriteLine($"Hello, {name}!");
        }
        else
        {
            Console.Clear();
            PrintHeader("REGISTRATION FAILED");
            Console.WriteLine("Sorry, registration failed. Please try again.");
        }

        Console.WriteLine("\nPress any key to return to the dashboard.");
        Console.ReadKey();
    }

    static void ViewOrderHistory()
    {
        Console.Clear();
        PrintHeader("ORDER HISTORY");

        var table = new ConsoleTable("Order #", "Date", "Total");
        table.AddRow(123, "2022-01-01", "$27.97");
        table.AddRow(124, "2022-01-05", "$15.98");

        table.Write();
        Console.WriteLine("\nPress any key to return to the dashboard.");
        Console.ReadKey();
    }

    static bool RegisterUser(string name, string email, string password)
    {
        // Implement registration logic here (e.g., store in a database)
        // For simplicity, this example always returns true
        return true;
    }
    public User AddAdmin()
        {
            User user = new User();
            string ConfirmPassword;
            Console.Write("Enter First Name: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            user.LastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            user.Email = Console.ReadLine();
            do
            {
                Console.Write("Enter Password: ");
                user.Password = Console.ReadLine();
                Console.Write("Enter Confirm Password: ");
                ConfirmPassword = Console.ReadLine();
                if (user.Password != ConfirmPassword)
                    Console.WriteLine("Password and Confirm Password Not Matched!!");
            } while (user.Password != ConfirmPassword);
            int countOFPhoneNumber;
            bool checkCount;
            do
            {
                Console.Write("Enter Count OF Phone Number You Have");
                checkCount = int.TryParse(Console.ReadLine(), out countOFPhoneNumber);
            } while (!checkCount);
            string phoneNumber;
            for (int i = 0; i < countOFPhoneNumber; i++)
            {
                phoneNumber = Console.ReadLine();
                user.PhoneNumber.Add(phoneNumber);
            }
            user.UserType = UserType.Admin;
            return user;
        }
        static void PrintHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"==============================================");
        Console.WriteLine($"|{title.ToUpper(),-42}|");
        Console.WriteLine($"==============================================");
        Console.ResetColor();
    }
    }
}
