using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPorfolioGenerator.Models
{
    public class Employee
    {
        private int _id;
        [Key]
        public int EmployeeId
        {
            get { return _id; }
        }

        public string Cargo { get; set; }
        
    }
}
 