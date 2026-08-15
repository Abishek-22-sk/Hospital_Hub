
using HealthHub.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub.Repository
{
    public class DoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IQueryable<DoctorModel> GetQueryable()
        {
            return _context.Doctor.AsQueryable();
        }

        public async Task<DoctorModel> CreateDoctorAsync(DoctorModel model)
        {
             _context.Doctor.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<DoctorModel> GetDoctorByIdAsync(long doctorId)
        {
            return await _context.Doctor.FirstOrDefaultAsync(x => x.Id == doctorId);
        }

        public async Task<DoctorModel> GetDoctorByHospitalIdAsync(long hositalId)
        {
            return await _context.Doctor.FirstOrDefaultAsync(x => x.HospitalId == hositalId && x.IsDelete == false);
        }
        public async Task<bool> SoftDeleteDoctorRecordAsync(long doctorId)
        {
            return await _context.Doctor.Where(x => x.Id == doctorId).ExecuteUpdateAsync(x => x.SetProperty(s => s.IsDelete, true)) > 0;
        }

        public async Task<bool>HardDeleteDoctorRecordAsync(long doctorId)
        {
            var result =  await _context.Doctor.FirstOrDefaultAsync(x => x.Id == doctorId);
             _context.Doctor.Remove(result);
            await _context.SaveChangesAsync();
            return result.IsDelete;
        }
    }
}
