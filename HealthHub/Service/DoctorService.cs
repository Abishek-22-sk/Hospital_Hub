using System.Text.RegularExpressions;
using HealthHub.Models;
using HealthHub.Repository;

namespace HealthHub.Service
{
    public class DoctorService
    {
        private readonly DoctorRepository doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<DoctorModel> CreateDoctorAsync(DoctorModel model)
        {
            return await doctorRepository.CreateDoctorAsync(model);
        }

        public async Task<DoctorModel> GetDoctorByIdAsync(long doctorId)
        {
            return await doctorRepository.GetDoctorByIdAsync(doctorId);
        }
    }
}
