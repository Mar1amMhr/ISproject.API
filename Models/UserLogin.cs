using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class UserLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
