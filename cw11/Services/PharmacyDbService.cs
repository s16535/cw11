using cw11.DTO.Request;
using cw11.DTO.Response;
using cw11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public class PharmacyDbService : IPharmacyDbService
    {
        private readonly PharmacyDbContext pharmacyDbContext;
        public PharmacyDbService(PharmacyDbContext context)
        {
            pharmacyDbContext = context;
        }

        ICollection<Doctor> IPharmacyDbService.ReadDoctors()
        {
            return pharmacyDbContext.Doctors.ToList();
        }

        public DoctorDTO CreateDoctor(CreateDoctorDTO createDoctor)
        {
            var Doctor = new Doctor
            {
                FirstName = createDoctor.FirstName,
                LastName = createDoctor.LastName,
                Email = createDoctor.Email
            };

            pharmacyDbContext.Doctors.Add(Doctor);
            pharmacyDbContext.SaveChanges();

            return new DoctorDTO
            {
                IdDoctor = Doctor.IdDoctor,
                FirstName = Doctor.FirstName,
                LastName = Doctor.LastName,
                Email = Doctor.Email
            };

        }


        public DoctorDTO ReadDoctor(int idDoctor)
        {
            var Doctor = pharmacyDbContext.Doctors.Find(idDoctor);

            if (Doctor == null)
            {
                return null;
            }

            return new DoctorDTO
            {
                IdDoctor = Doctor.IdDoctor,
                FirstName = Doctor.FirstName,
                LastName = Doctor.LastName,
                Email = Doctor.Email
            };
        }

        public DoctorDTO UpdateDoctor(UpdateDoctorDTO updateDoctor)
        {
            var Doctor = pharmacyDbContext.Doctors.Find(updateDoctor.IdDoctor);

            if (Doctor == null)
            {
                return null;
            }

            if (updateDoctor.FirstName != null)
            {
                Doctor.FirstName = updateDoctor.FirstName;
            }

            if (updateDoctor.LastName != null)
            {
                Doctor.LastName = updateDoctor.LastName;
            }

            if (updateDoctor.Email != null)
            {
                Doctor.Email = updateDoctor.Email;
            }

            return new DoctorDTO
            {
                IdDoctor = Doctor.IdDoctor,
                FirstName = Doctor.FirstName,
                LastName = Doctor.LastName,
                Email = Doctor.Email
            };
        }

        public DoctorDTO DeleteDoctor(int idDoctor)
        {
            var Doctor = pharmacyDbContext.Doctors.Find(idDoctor);

            if (Doctor == null)
            {
                return null;
            }

            pharmacyDbContext.Doctors.Remove(Doctor);
            pharmacyDbContext.SaveChanges();

            return new DoctorDTO
            {
                IdDoctor = Doctor.IdDoctor,
                FirstName = Doctor.FirstName,
                LastName = Doctor.LastName,
                Email = Doctor.Email
            };
        }
    }
}
