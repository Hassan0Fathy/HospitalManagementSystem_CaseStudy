using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required, MaxLength(150)]

        public string FullName { get; set; }
        [Required, MaxLength(100)]

        public string Specialization { get; set; }
        [EmailAddress, Required]

        public string Email { get; set; }
        [Phone, Required ,MaxLength(20)]
        public string Phone { get; set; }
        [Required , Range(1 ,int.MaxValue)]
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
