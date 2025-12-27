using HealthHub.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<DoctorModel> Doctors { get; set; }

        public DbSet<SpecialistModel> Specialist { get; set; }

    }
}