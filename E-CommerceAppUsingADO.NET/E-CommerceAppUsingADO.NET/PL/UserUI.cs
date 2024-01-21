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
     class UserUI
    {
        public static User UserRegiser(UserType userType)
        {
            User user = new User();
            user.FirstName = UserValidations.checkNameValidation("First Name");
            user.LastName = UserValidations.checkNameValidation("Last Name");
            user.Email = UserValidations.chcekEmailValidationForRegister();
            user.Password = UserValidations.checkPasswordValidationForRegister();
            user.PhoneNumber = UserValidations.checkPhoneNumberValidation();
            user.UserType = userType;
            UserMethods.Register(user);
            return user;
        }
        public static User UserLogin()
        {
            DataTable dt = new DataTable();
            LoginDto login = new LoginDto();
            User user = new User();
            login.Email = UserValidations.checkEmailValidationForLogin();
            login.Password = UserValidations.checkPasswordValidationForLogin();
                DataTable dataTable = new DataTable();
                dataTable = UserMethods.Login(login);
            if (dataTable.Rows.Count == 0)
            {
                BaseValidation.DisplayTextWithRedColor("Email or Password Invalid");
                Console.ReadKey();
            }
            else
            {
                user.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                user.FirstName = Convert.ToString(dataTable.Rows[0][1]);
                user.LastName = Convert.ToString(dataTable.Rows[0][2]);
                user.Password = Convert.ToString(dataTable.Rows[0][3]);
                user.UserType = (UserType)Convert.ToInt32(dataTable.Rows[0][4]);
                user.Email = Convert.ToString(dataTable.Rows[0][5]);
                user.PhoneNumber = Convert.ToString(dataTable.Rows[0][6]);
            }
            return user;
        }
    }
}
