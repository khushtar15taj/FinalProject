using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class DoctorDbContext : DbContext
    {

        public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options)
        {
        }
       



        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }

        public DbSet<Search> appointments { get; set; }
        public DbSet<Slot> slots { get; set; }

    }
}
