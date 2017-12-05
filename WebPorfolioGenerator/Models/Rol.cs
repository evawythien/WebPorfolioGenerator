using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    [Table("Rols")]
    public class Rol
    {
        public int RolId { get; set; }

        public string Name { get; set; }
    }
}


