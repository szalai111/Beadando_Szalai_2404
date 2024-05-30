using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Beadando_Szalai_2404.Model
{
    class RestaurantContext : DbContext
    {
        private string connectionString = ConfigurationManager.AppSettings.Get("DBurl");
        public RestaurantContext()
        {
            connectionString = connectionString;
        }


        public DbSet<Employee> Employees { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<MenuItem> MenuItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
