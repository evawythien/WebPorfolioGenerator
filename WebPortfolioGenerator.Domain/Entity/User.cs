using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        [StringLength(120)]
        public string Surname { get; set; }

        [StringLength(120)]
        public string Password { get; set; }

        public int RolId { get; set; }

        [StringLength(120)]
        public string Email { get; set; }

        public DateTime Birth { get; set; }

        [StringLength(120)]
        public string MovilePhone { get; set; }

        [StringLength(120)]
        public string Phone { get; set; }
    }
}



