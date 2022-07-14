using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public Nullable<int> Category_CategoryId { get; set; }
        [ForeignKey("Category_CategoryId")]
        public virtual Category Category { get; set; }
    }
}