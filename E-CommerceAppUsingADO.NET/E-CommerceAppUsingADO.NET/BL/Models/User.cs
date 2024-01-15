using E_CommerceAppUsingADO.NET.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAppUsingADO.NET.BL.Models
{
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BildingNo { get; set; }
        public List<string> PhoneNumber { get; set; }
     //   public List<Order> Orders { get; set; }
    }
}
