using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                          .HasIndex(s => s.Email)
                          .IsUnique();

            modelBuilder.Entity<Doctor>()
                         .Property(s => s.Salary)
                         .HasPrecision(10, 2);

            modelBuilder.Entity<Department>().HasMany(s => s.Doctors).WithOne(d => d.Department).HasForeignKey(s => s.DepartmentId);
            modelBuilder.Entity<Doctor>().HasMany(s => s.Appointments).WithOne(d => d.Doctor).HasForeignKey(s => s.DoctorId);
            modelBuilder.Entity<Patient>().HasMany(s => s.Appointments).WithOne(d => d.Patient).HasForeignKey(s => s.PatientId);
            modelBuilder.Entity<Appointment>()
                        .HasOne(a => a.MedicalRecord)
                        .WithOne(m => m.Appointment)
                        .HasForeignKey<MedicalRecord>(m => m.AppointmentId);


            modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, DepartmentName = "Cardiology", Location = "Cairo" },
            new Department { DepartmentId = 2, DepartmentName = "Pediatrics", Location = "Giza" },
            new Department { DepartmentId = 3, DepartmentName = "Orthopedics", Location = "Cairo" },
            new Department { DepartmentId = 4, DepartmentName = "Dermatology", Location = "Giza" });
            modelBuilder.Entity<Doctor>().HasData(
            new Doctor { DoctorId = 1, FullName = "Ahmed Hassan", Specialization = "Cardiologist", Email = "ahmed.hassan@hms.com", Phone = "01010000001", Salary = 45000, DepartmentId = 1 },
            new Doctor { DoctorId = 2, FullName = "Mona Adel", Specialization = "Cardiologist", Email = "mona.adel@hms.com", Phone = "01010000002", Salary = 42000, DepartmentId = 1 },
            new Doctor { DoctorId = 3, FullName = "Omar Khaled", Specialization = "Pediatrician", Email = "omar.khaled@hms.com", Phone = "01010000003", Salary = 38000, DepartmentId = 2 },
            new Doctor { DoctorId = 4, FullName = "Nour Samir", Specialization = "Pediatrician", Email = "nour.samir@hms.com", Phone = "01010000004", Salary = 36000, DepartmentId = 2 },
            new Doctor { DoctorId = 5, FullName = "Karim Tarek", Specialization = "Orthopedic Surgeon", Email = "karim.tarek@hms.com", Phone = "01010000005", Salary = 50000, DepartmentId = 3 },
            new Doctor { DoctorId = 6, FullName = "Salma Youssef", Specialization = "Orthopedic Specialist", Email = "salma.youssef@hms.com", Phone = "01010000006", Salary = 41000, DepartmentId = 3 },
            new Doctor { DoctorId = 7, FullName = "Youssef Emad", Specialization = "Dermatologist", Email = "youssef.emad@hms.com", Phone = "01010000007", Salary = 39000, DepartmentId = 4 },
            new Doctor { DoctorId = 8, FullName = "Laila Mostafa", Specialization = "Dermatologist", Email = "laila.mostafa@hms.com", Phone = "01010000008", Salary = 37000, DepartmentId = 4 });

            modelBuilder.Entity<Patient>().HasData(
            new Patient { PatientId = 1, FullName = "Omar Ali", Gender = "Male", DateOfBirth = new DateTime(1995, 3, 12), Phone = "01120000001", Address = "Nasr City, Cairo" },
            new Patient { PatientId = 2, FullName = "Sara Ahmed", Gender = "Female", DateOfBirth = new DateTime(1998, 7, 24), Phone = "01120000002", Address = "Dokki, Giza" },
            new Patient { PatientId = 3, FullName = "Mahmoud Samir", Gender = "Male", DateOfBirth = new DateTime(1987, 11, 5), Phone = "01120000003", Address = "Heliopolis, Cairo" },
            new Patient { PatientId = 4, FullName = "Mariam Adel", Gender = "Female", DateOfBirth = new DateTime(2002, 1, 19), Phone = "01120000004", Address = "Giza" },
            new Patient { PatientId = 5, FullName = "Yassin Mohamed", Gender = "Male", DateOfBirth = new DateTime(1979, 9, 30), Phone = "01120000005", Address = "Maadi, Cairo" },
            new Patient { PatientId = 6, FullName = "Hana Khaled", Gender = "Female", DateOfBirth = new DateTime(1991, 5, 14), Phone = "01120000006", Address = "October, Giza" },
            new Patient { PatientId = 7, FullName = "Adam Tarek", Gender = "Male", DateOfBirth = new DateTime(2014, 2, 10), Phone = "01120000007", Address = "Giza" },
            new Patient { PatientId = 8, FullName = "Lina Hassan", Gender = "Female", DateOfBirth = new DateTime(2012, 8, 21), Phone = "01120000008", Address = "Nasr City, Cairo" },
            new Patient { PatientId = 9, FullName = "Mostafa Nabil", Gender = "Male", DateOfBirth = new DateTime(1983, 12, 2), Phone = "01120000009", Address = "Shoubra, Cairo" },
            new Patient { PatientId = 10, FullName = "Aya Emad", Gender = "Female", DateOfBirth = new DateTime(2000, 6, 17), Phone = "01120000010", Address = "Mohandessin, Giza" });


            modelBuilder.Entity<Appointment>().HasData(
            new Appointment { AppointmentId = 1, AppointmentDate = new DateTime(2026, 9, 29, 9, 0, 0), Status = "Scheduled", DoctorId = 1, PatientId = 1 },
            new Appointment { AppointmentId = 2, AppointmentDate = new DateTime(2026, 9, 29, 10, 0, 0), Status = "Scheduled", DoctorId = 3, PatientId = 7 },
            new Appointment { AppointmentId = 3, AppointmentDate = new DateTime(2026, 9, 29, 11, 30, 0), Status = "Completed", DoctorId = 5, PatientId = 3 },
            new Appointment { AppointmentId = 4, AppointmentDate = new DateTime(2026, 9, 29, 13, 0, 0), Status = "Cancelled", DoctorId = 7, PatientId = 4 },
            new Appointment { AppointmentId = 5, AppointmentDate = new DateTime(2026, 9, 28, 9, 30, 0), Status = "Completed", DoctorId = 2, PatientId = 5 },
            new Appointment { AppointmentId = 6, AppointmentDate = new DateTime(2026, 9, 28, 12, 0, 0), Status = "Completed", DoctorId = 4, PatientId = 8 },
            new Appointment { AppointmentId = 7, AppointmentDate = new DateTime(2026, 9, 27, 14, 0, 0), Status = "Completed", DoctorId = 6, PatientId = 9 },
            new Appointment { AppointmentId = 8, AppointmentDate = new DateTime(2026, 10, 1, 10, 0, 0), Status = "Scheduled", DoctorId = 8, PatientId = 10 },
            new Appointment { AppointmentId = 9, AppointmentDate = new DateTime(2026, 10, 2, 11, 0, 0), Status = "Scheduled", DoctorId = 1, PatientId = 2 },
            new Appointment { AppointmentId = 10, AppointmentDate = new DateTime(2026, 10, 3, 9, 0, 0), Status = "Scheduled", DoctorId = 3, PatientId = 6 },
            new Appointment { AppointmentId = 11, AppointmentDate = new DateTime(2026, 9, 26, 15, 0, 0), Status = "Completed", DoctorId = 5, PatientId = 5 },
            new Appointment { AppointmentId = 12, AppointmentDate = new DateTime(2026, 9, 25, 16, 0, 0), Status = "Completed", DoctorId = 7, PatientId = 1 });


            modelBuilder.Entity<MedicalRecord>().HasData(
            new MedicalRecord { MedicalRecordId = 1, Diagnosis = "Hypertension", Prescription = "Amlodipine 5mg once daily", Notes = "Follow-up after two weeks.", AppointmentId = 3 },
            new MedicalRecord { MedicalRecordId = 2, Diagnosis = "Acute respiratory infection", Prescription = "Rest and fluids", Notes = "Patient advised to return if symptoms worsen.", AppointmentId = 5 },
            new MedicalRecord { MedicalRecordId = 3, Diagnosis = "Knee ligament injury", Prescription = "Physiotherapy and rest", Notes = "MRI recommended.", AppointmentId = 7 },
            new MedicalRecord { MedicalRecordId = 4, Diagnosis = "Mild eczema", Prescription = "Topical moisturizer twice daily", Notes = "Avoid known skin irritants.", AppointmentId = 11 },
            new MedicalRecord { MedicalRecordId = 5, Diagnosis = "Migraine", Prescription = "Paracetamol as needed", Notes = "Maintain regular sleep schedule.", AppointmentId = 12 },
            new MedicalRecord { MedicalRecordId = 6, Diagnosis = "Seasonal allergy", Prescription = "Antihistamine once daily", Notes = "Review if symptoms persist.", AppointmentId = 6 });







        }



    }

}

