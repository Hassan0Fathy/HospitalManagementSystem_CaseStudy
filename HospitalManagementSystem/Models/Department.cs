using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HospitalManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required , MaxLength(100)]
        public string DepartmentName { get; set; }
        [MaxLength(150)]
        public string? Location { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
