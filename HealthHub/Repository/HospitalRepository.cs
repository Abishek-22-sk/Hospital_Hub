using System.Threading.Tasks;
using HealthHub.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub.Repository
{
    public class HospitalRepository
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly DoctorRepository doctorRepository;

        public HospitalRepository(ApplicationDbContext applicationDb, DoctorRepository doctorRepository)
        {
            this.applicationDb = applicationDb;
            this.doctorRepository = doctorRepository;
        }

        public async Task<HospitalModel> CreateHosptialAsync(HospitalModel hospitalModel)
        {
            await applicationDb.Hospital.AddAsync(hospitalModel);
            await applicationDb.SaveChangesAsync();
            return hospitalModel;
        }

        public async Task<HospitalModel> GetHosptialAsync(long hospitalId)
        {
            return await applicationDb.Hospital.FirstOrDefaultAsync(x => x.Id == hospitalId && x.IsDelete == false && x.IsActive == true);
        }

        public async Task<List<HospitalModel?>> GetHospitalsAsync()
        {
            return await applicationDb.Hospital.Where(x =>x.IsActive == true && x.IsDelete == false).ToListAsync();
        }

        public async Task<bool> DisableHospitalAsync(long hospitalId)
        {
            return await applicationDb.Hospital.Where(x =>x.Id == hospitalId).ExecuteUpdateAsync(x=>x.SetProperty(h=>h.IsActive , false)) > 0;
        }

        public async Task<bool> MarkHospitalAsDeleteAsync(long hospitalId)
        {
            return await applicationDb.Hospital.Where(x => x.Id == hospitalId).ExecuteUpdateAsync(x => x.SetProperty(h => h.IsDelete, true)) > 0;
        }

        public async Task<bool> HardDeleteHospitalAsync(long hospitalId)
        {
            return await applicationDb.Hospital.Where(x => x.Id == hospitalId).ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> EnableHospitalAsync(long hospitalId)
        {
            return await applicationDb.Hospital.Where(x => x.Id == hospitalId).ExecuteUpdateAsync(x => x.SetProperty(h => h.IsActive, true)) > 0;
        }

        public async Task<bool> IsHospitalnameExist(string hospitalName)
        {
            var result = await applicationDb.Hospital.AnyAsync(x => x.HospitalName == hospitalName);
            return result;
        }
    }
}
