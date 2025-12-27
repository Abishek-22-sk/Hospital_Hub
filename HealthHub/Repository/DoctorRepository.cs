
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
            return _context.Doctors.AsQueryable();
        }

        public async Task<DoctorModel> CreateDoctorAsync(DoctorModel model)
        {
             _context.Doctors.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<DoctorModel> GetDoctorByIdAsync(long doctorId)
        {
           return await _context.Doctors.FirstOrDefaultAsync(x =>x.Id == doctorId);
        }

        public async Task<DoctorModel>DeleteDoctorRecordAsync(long doctorId)
        {
            var result =  await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctorId);
             _context.Doctors.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
