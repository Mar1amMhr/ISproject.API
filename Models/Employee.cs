using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public int salary { get; set; }
        public virtual Department Department { get; set; }
    }
}

