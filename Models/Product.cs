using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Pname { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Quantity { get; set; } = null!;
        public int UserId { get; set; }
    }
}
