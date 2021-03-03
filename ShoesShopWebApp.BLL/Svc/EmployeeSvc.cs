using ShoesShopWebApp.Common.Req;
using ShoesShopWebApp.DAL.Model;
using ShoesShopWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoesShopWebApp.BLL.Svc
{
    public class EmployeeSvc
    {
        private readonly EmployeeRep employeeRep;
        public EmployeeSvc()
        {
            employeeRep = new EmployeeRep();
        }


        public object CreateEmployee(EmployeeReq req)
        {
            Employee employee = new Employee();
            employee.Account = req.Account;
            employee.Pass = req.Pass;
            employee.LastName = req.LastName;
            employee.FirstName = req.FirstName;
            employee.DateOfBirth = req.DateOfBirth;
            employee.Gender = req.Gender;
            employee.CitizenIdentification = req.CitizenIdentification;
            employee.Address = req.Address;
            employee.PhoneNumberOfEmployee = req.PhoneNumberOfEmployee;
            employee.Email = req.Email;
            employee.CreatedDate = req.CreatedDate;
            employee.AccountStatus = req.AccountStatus;
            employee.Note = req.Note;
            return employeeRep.Create(employee);
        }


        public object UpdateEmployee(String account, EmployeeReq req)
        {
            return employeeRep.Update(account, req);
        }


        public object DeleteEmployee(String account)
        {
            return employeeRep.Delete(account);
        }


        public object GetEmployeeByAccount(String account)
        {
            return employeeRep.GetEmployeeByAccount(account);
        }


        public object SearchEmployee(int size, int page, String keyword)
        {
            var allValues = employeeRep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                allValues = employeeRep.All.Where(value => value.Account.Contains(keyword) || value.Pass.Contains(keyword));
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


        public Employee ValidateEmployee(LoginReq req)
        {
            return employeeRep.ValidateEmployee(req);
        }
    }
}
