using E_CommerceAppUsingADO.NET.BL.Methods;
using E_CommerceAppUsingADO.NET.BL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.PL
{
     class LoginUl
    {
        public void UserLogin()
        {
            Login login = new Login();
            Console.Write("Enter Email: ");
            login.Email = Console.ReadLine();
            Console.Write("Enter Password: ");
            login.Password = Console.ReadLine();
            DataTable dataTable =  UserMethods.Login(login);
            if(dataTable.Rows.Count==0)
                Console.WriteLine("Email or Password Invalid");
            // display all product
        }
    }
}
