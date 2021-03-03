using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.Common.Req;

namespace ShoesShopWebApp.DAL.Rep
{
    public class EmployeeRep
    {
        private Context context;


        public EmployeeRep()
        {
            context = new Context();
        }


        public object Create(Employee employee)
        {
            try
            {
                context.Employee.Add(employee);
                context.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }


        public object Update(String account, EmployeeReq req)
        {
            try
            {
                var result = context.Employee.FirstOrDefault(value => value.Account == account);
                if (result != null)
                {
                    result.Account = req.Account;
                    result.Pass = req.Pass;
                    result.LastName = req.LastName;
                    result.FirstName = req.FirstName;
                    result.DateOfBirth = req.DateOfBirth;
                    result.Gender = req.Gender; 
                    result.CitizenIdentification = req.CitizenIdentification;
                    result.Address = req.Address;
                    result.PhoneNumberOfEmployee = req.PhoneNumberOfEmployee;
                    result.Email = req.Email;
                    result.CreatedDate = req.CreatedDate;
                    result.AccountStatus = req.AccountStatus;
                    result.Note = req.Note;
                    context.Employee.Update(result);
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
            var result = context.Employee.FirstOrDefault(value => value.Account == account);
            try
            {
                if (result != null)
                {
                    context.Employee.Remove(result);
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


        public object GetEmployeeByAccount(String account)
        {
            try
            {
                var result = context.Employee.FirstOrDefault(value => value.Account == account);
                if (result != null)
                {
                    var data = new
                    {
                        account = result.Account,
                        password = result.Pass,
                        lastname = result.LastName,
                        firstname = result.FirstName,
                        birthday = result.DateOfBirth,
                        gender = result.Gender,
                        citizenIdentification = result.CitizenIdentification,
                        address = result.Address,
                        phonenumber = result.PhoneNumberOfEmployee,
                        createdate = result.CreatedDate,
                        accountstatus = result.AccountStatus,
                        note = result.Note
                    };
                    return data;
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

        public Employee ValidateEmployee(LoginReq req)
        {
            var result = context.Employee.FirstOrDefault(value => value.Account == req.Account && value.Pass == req.Pass);
            return result;
        }


        public IQueryable<Employee> All
        {
            get
            {
                IQueryable<Employee> result = context.Employee;
                return result;
            }
        }
    }
}
