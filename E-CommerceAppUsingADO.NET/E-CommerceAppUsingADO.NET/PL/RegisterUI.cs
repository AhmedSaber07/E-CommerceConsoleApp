using E_CommerceAppUsingADO.NET.BL.Enums;
using E_CommerceAppUsingADO.NET.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.PL
{
     class RegisterUI
    {
        public User UserRegiser()
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
            Console.Write("Enter City: ");
            user.City = Console.ReadLine();
            Console.Write("Enter Street: ");
            user.Street = Console.ReadLine();
            Console.Write("Enter BuildingNo: ");
            user.BildingNo = Console.ReadLine();
            user.UserType = UserType.Customer;
            Console.WriteLine("\n User Created Successfully");
            Console.WriteLine("\n******************************************\n");
            return user;
        }
    }
}
