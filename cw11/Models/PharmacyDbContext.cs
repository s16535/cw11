using cw11.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext() { }

        public PharmacyDbContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionMedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var Doctors = new List<Doctor>();
            var Prescriptions = new List<Prescription>();
            var Patients = new List<Patient>();
            var PrescriptionMedicaments = new List<PrescriptionMedicament>();
            var Medicaments = new List<Medicament>();

            Doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Janusz", LastName = "Bąbalski", Email = "babel_78@buziaczek.pl" });
            Doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Josef", LastName = "Mengele", Email = "mengele@3rzesza.com" });
            Doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Henryk", LastName = "Zając", Email = "szarak@szarak.com" });

            Patients.Add(new Patient { IdPatient = 1, FirstName = "Roman", LastName = "Bździuch", BirthDate = new DateTime(1980, 11, 2) });
            Patients.Add(new Patient { IdPatient = 2, FirstName = "Genowefa", LastName = "Pigwa", BirthDate = new DateTime(1933, 1, 1) });
            Patients.Add(new Patient { IdPatient = 3, FirstName = "Beniamin", LastName = "Blimsien", BirthDate = new DateTime(1973, 12, 8) });

            Prescriptions.Add(new Prescription { IdPrescription = 1, IdDoctor = 1, IdPatient = 1, Date = new DateTime(2020, 6, 11), DueDate = new DateTime(2020, 7, 11) });
            Prescriptions.Add(new Prescription { IdPrescription = 2, IdDoctor = 2, IdPatient = 2, Date = new DateTime(2020, 6, 1), DueDate = new DateTime(2020, 7, 1) });
            Prescriptions.Add(new Prescription { IdPrescription = 3, IdDoctor = 3, IdPatient = 3, Date = new DateTime(2020, 6, 8), DueDate = new DateTime(2020, 7, 8) });

            Medicaments.Add(new Medicament { IdMedicament = 1, Name = "Viagra", Description = "Wiadomo...", Type = "URO" });
            Medicaments.Add(new Medicament { IdMedicament = 2, Name = "Prozac", Description = "Też wiadomo", Type = "PSYCHO" });
            Medicaments.Add(new Medicament { IdMedicament = 3, Name = "Niepierdol", Description = "No weź...", Type = "OGOL" });

            PrescriptionMedicaments.Add(new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "BEWARE - CHRONICAL ERECTION" });
            PrescriptionMedicaments.Add(new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 10, Details = "BEWARE - HYPER CLEARANCE" });
            PrescriptionMedicaments.Add(new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 3, Dose = 100, Details = "NO WEŹ" });

            modelBuilder.Entity<Doctor>().HasData(Doctors);
            modelBuilder.Entity<Patient>().HasData(Patients);
            modelBuilder.Entity<Prescription>().HasData(Prescriptions);
            modelBuilder.Entity<Medicament>().HasData(Medicaments);
            modelBuilder.Entity<PrescriptionMedicament>().HasData(PrescriptionMedicaments);
        }
    }
}
