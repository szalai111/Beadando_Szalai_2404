using Beadando_Szalai_2404.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Repository
{
    class EmployeeRepository
    {
        private RestaurantContext RestaurantContext;

        //Methods

        public EmployeeRepository(RestaurantContext Context)
        {
            this.RestaurantContext = Context;
        }

        public List<Employee> GetEmployees()
        {
            return RestaurantContext.Employees.ToList();
        }

        public Employee GetEmployeesById(int id)
        {
            return RestaurantContext.Employees.Find(id);
        }

        public Employee GetEmployeeByName(string name)
        {
            return RestaurantContext.Employees.Where(p => p.Name == name).First();
        }

        public void InsertEmployee(Employee employee)
        {
            RestaurantContext.Employees.Add(employee);
        }

        public void DeleteEmployees(int employeeId)
        {
            Employee employee = RestaurantContext.Employees.Find(employeeId);
            RestaurantContext.Employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            RestaurantContext.Employees.Find(employee.Id).Id = employee.Id;
            RestaurantContext.Employees.Find(employee.Id).Name = employee.Name;
            RestaurantContext.Employees.Find(employee.Id).Salary = employee.Salary;
        }

        public void Save()
        {
            RestaurantContext.SaveChanges();
        }

        public void Dispose()
        {
            RestaurantContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
