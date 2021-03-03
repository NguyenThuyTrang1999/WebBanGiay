using System;
using System.Collections.Generic;
using System.Text;

namespace ShoesShopWebApp.Common.Req
{
    public class EmployeeReq
    {
        public String Account { get; set; }
        public String Pass { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String DateOfBirth { get; set; }
        public String Gender { get; set; }
        public String CitizenIdentification { get; set; }
        public String Address { get; set; }
        public String PhoneNumberOfEmployee { get; set; }
        public String Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public String AccountStatus { get; set; }
        public String Note { get; set; }
    }
}
