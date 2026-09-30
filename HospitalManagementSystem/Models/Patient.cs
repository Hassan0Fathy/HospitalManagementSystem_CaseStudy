using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, MaxLength(20)]
        public string Gender { get; set; }
        [Required , Range( typeof(DateTime) ,"1900-01-01", "2026-09-30")]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(20) ,Phone]
        public string Phone { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
