using Beadando_Szalai_2404.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Repository
{
    class RegisterRepository
    {
        private RestaurantContext RestaurantContext;

        //Methods

        public RegisterRepository(RestaurantContext Context)
        {
            this.RestaurantContext = Context;
        }

        public void InsertEmployeeRegister(Employee employeeregister)
        {
            RestaurantContext.Employees.Add(employeeregister);
        }

        public void Save()
        {
            RestaurantContext.SaveChanges();
        }
    }
}
