using EmployeeManagementSystem.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DbContexts
{
    public class EMSContext : DbContext
    {
        public DbSet<EmployeeDTO> Employees { get; set; }
        public DbSet<PhoneNumberDTO> PhoneNumbers { get; set; }
        public DbSet<EmailDTO> Emails { get; set; }

        public EMSContext() { }
        public EMSContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<EmployeeDTO>().Property(b => b.ID).UseIdentityAlwaysColumn();
            modelBuilder.Entity<PhoneNumberDTO>().Property(b => b.ID).UseIdentityAlwaysColumn();
            modelBuilder.Entity<EmailDTO>().Property(b => b.ID).UseIdentityAlwaysColumn();

            base.OnModelCreating(modelBuilder);
        }
    }
}
