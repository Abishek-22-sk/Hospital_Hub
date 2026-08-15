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

        public async Task<bool> HardDeleteDoctorRecordAsync(long doctorId)
        {
            return await doctorRepository.HardDeleteDoctorRecordAsync(doctorId);
        }

        public async Task<bool> SoftDeleteDoctorRecordAsync(long doctorId)
        {
            return await doctorRepository.SoftDeleteDoctorRecordAsync(doctorId);
        }

        public async Task<DoctorModel> GetDoctorByHospitalIdAsync(long doctorId)
        {
            return await doctorRepository.GetDoctorByHospitalIdAsync(doctorId);
        }
    }
}
