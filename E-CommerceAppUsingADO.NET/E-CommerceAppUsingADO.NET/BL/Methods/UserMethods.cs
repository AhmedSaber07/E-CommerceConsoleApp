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
    static class UserMethods
    {
        public static DataTable Login(Login login)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            para[0].Value = login.Email;

            para[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            para[1].Value = login.Password;

            DA.open();

            DataTable dt = new DataTable();
            dt = DA.GetData("LOG_IN", para);
            DA.close();
            return dt;
        }
        public static void Register(User user)
        {
            DAL.DataAccessLayer DA = new DAL.DataAccessLayer();
            DA.open();
            SqlParameter[] para = new SqlParameter[5];

            para[0] = new SqlParameter("@fname", SqlDbType.VarChar, 50);
            para[0].Value = user.FirstName;

            para[1] = new SqlParameter("@lname", SqlDbType.VarChar, 50);
            para[1].Value = user.LastName;

            para[2] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            para[2].Value = user.Email;

            para[3] = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
            para[3].Value = user.Password;

            para[4] = new SqlParameter("@userType", SqlDbType.VarChar, 50);
            para[4].Value = "Customer";

            DA.ExecuteCommand("signUp", para);
            SqlParameter[] para1 = new SqlParameter[2];
            para1[0] = new SqlParameter("@email", SqlDbType.VarChar, 50);
            para1[0].Value = user.Email;
            foreach (string phone in user.PhoneNumber)
            {
                para1[1] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
                para1[1].Value = phone;
                DA.ExecuteCommand("AddPhoneNumber", para1);
            }
            DA.close();
        }
    }
}
