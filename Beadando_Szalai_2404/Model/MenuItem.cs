using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Szalai_2404.Model
{
    [Table("menuitems")]
    class MenuItem
    {
        [Key]
        [Column("menuid")]

        public int Id { get; set; }

        [Column("itemname")]

        public string ItemName { get; set; }

        [Column("price")]

        public string Price { get; set; }
    }
}
