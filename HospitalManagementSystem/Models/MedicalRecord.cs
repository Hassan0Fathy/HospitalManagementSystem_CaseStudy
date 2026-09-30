using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class MedicalRecord
    {
        [Key]   
        public int MedicalRecordId { get; set; }

        [Required , MaxLength(500)]
        public string Diagnosis { get; set; }
        [Required, MaxLength(1000)]

        public string Prescription { get; set; }
        [Required, MaxLength(1000)]
        public string Notes { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

    }
}
