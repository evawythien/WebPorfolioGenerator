﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPorfolioGenerator.Models
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        public int MenuId { get; set; }        

        public string MenuName { get; set; }

        public string Url { get; set; }
    }
}
