using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public string? Location { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
