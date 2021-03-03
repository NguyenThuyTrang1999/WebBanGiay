using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;
using System.Text.Json;

namespace ShoesShopWebApp.DAL.Rep
{
    public class CustomerRep
    {
        private Context context;


        public CustomerRep()
        {
            context = new Context();
        }


        public object Create(Customer customer)
        {
            try
            {
                context.Customer.Add(customer);
                context.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Update(String account, CustomerReq req)
        {
            try
            {
                var result = context.Customer.FirstOrDefault(value => value.Account == account);
                if (result != null)
                {
                    result.Account = req.Account;
                    result.Pass = req.Pass;
                    result.LastName = req.LastName;
                    result.FirstName = req.FirstName;
                    result.DateOfBirth = req.DateOfBirth;
                    result.Gender = req.Gender;
                    result.Address = req.Address;
                    result.PhoneNumberOfCustomer = req.PhoneNumberOfCustomer;
                    result.Email = req.Email;
                    result.CreatedDate = req.CreatedDate;
                    result.AccountStatus = req.AccountStatus;
                    result.Note = req.Note;
                    context.Customer.Update(result);
                    context.SaveChanges();
                    return result;
                }
                else
                {
                    return "Unable to update: not found ID.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Delete(String account)
        {
            var result = context.Customer.FirstOrDefault(value => value.Account == account);
            try
            {
                if (result != null)
                {
                    context.Customer.Remove(result);
                    context.SaveChanges();
                    return result;
                }
                else
                {
                    return "Unable to delete: not found ID.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object GetCustomerByAccount(String account)
        {
            try
            {
                var customer = context.Customer.FirstOrDefault(cus => cus.Account == account);
                   
                if (customer != null)
                {
                    return customer;
                }
                else 
                {
                    return "Not found Account.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }

        public IQueryable<Customer> All
        {
            get
            {
                IQueryable<Customer> result = context.Customer;
                return result;
            }
        }

        
        public Customer ValidateCustomer(LoginReq req)
        {
            var result = context.Customer.FirstOrDefault(value => value.Account.Equals(req.Account) && value.Pass.Equals(req.Pass));
            return result;
        }
    }
}
