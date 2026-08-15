using HealthHub.Models;
using HealthHub.Models.ReturnModel;
using Microsoft.EntityFrameworkCore;

namespace HealthHub
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<DoctorModel> Doctor { get; set; }

        public DbSet<PatientModel> Patient { get; set; }

        public DbSet<SpecialistModel> Specialist { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<HospitalModel> Hospital { get; set; }

    }
}