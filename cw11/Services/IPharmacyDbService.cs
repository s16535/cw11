using cw11.DTO.Request;
using cw11.DTO.Response;
using cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Services
{
    public interface IPharmacyDbService
    {
        public DoctorDTO CreateDoctor(CreateDoctorDTO createDoctor);
        public DoctorDTO ReadDoctor(int idDoctor);
        public DoctorDTO UpdateDoctor(UpdateDoctorDTO updateDoctor);
        public DoctorDTO DeleteDoctor(int idDoctor);
        public ICollection<Doctor> ReadDoctors();
     }
}
