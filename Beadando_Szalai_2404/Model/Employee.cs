using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Model
{
    [Table("employees")]
    class Employee
    {
        [Key]
        [Column("employeeid")]

        public int Id { get; set; }

        [Column("name")]

        public string Name { get; set; }

        [Column("salary")]

        public string Salary { get; set; }

        [Column("employeepassword")]

        public string Password { get; set; }

        [Column("AccessRights")]

        public string Access { get; set; }
    }
}
