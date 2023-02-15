using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Adduser
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
    }
}
