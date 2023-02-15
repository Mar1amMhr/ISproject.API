using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
