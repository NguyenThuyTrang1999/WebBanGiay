using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Rep;
using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;

namespace ShoesShopWebApp.BLL.Svc
{
    public class CustomerSvc
    {
        private readonly CustomerRep customerRep;
        public CustomerSvc()
        {
            customerRep = new CustomerRep();
        }


        public object CreateCustomer(CustomerReq req)
        {
            Customer customer = new Customer();
            customer.Account = req.Account;
            customer.Pass = req.Pass;
            customer.LastName = req.LastName;
            customer.FirstName = req.FirstName;
            customer.DateOfBirth = req.DateOfBirth;
            customer.Gender = req.Gender;
            customer.Address = req.Address;
            customer.PhoneNumberOfCustomer = req.PhoneNumberOfCustomer;
            customer.Email = req.Email;
            customer.CreatedDate = req.CreatedDate;
            customer.AccountStatus = req.AccountStatus;
            customer.Note = req.Note;
            return customerRep.Create(customer);
        }


        public object UpdateCustomer(String account, CustomerReq req)
        {
            return customerRep.Update(account, req);
        }


        public object DeleteCustomer(String account)
        {
            return customerRep.Delete(account);
        }


        public object GetCustomerByAccount(String account)
        {
            return customerRep.GetCustomerByAccount(account);
        }


        public object SearchCustomer(int size, int page, String keyword)
        {
            var allValues = customerRep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                allValues = customerRep.All.Where(value => value.Account.Contains(keyword) || value.Pass.Contains(keyword));
            }
            int offset = (page - 1) * size;
            int total = allValues.Count();
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = allValues.Skip(offset).Take(size).ToList();
            var result = new
            {
                Data = data,
                totalRecord = total,
                Page = page,
                Size = size,
                TotalPage = totalPage
            };
            return result;
        }


        public Customer ValidateCustomer(LoginReq req)
        {
            return customerRep.ValidateCustomer(req);
        }
    }
}
