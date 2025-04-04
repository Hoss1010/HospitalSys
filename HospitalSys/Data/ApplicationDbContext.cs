using HospitalSys.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalSys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> doctors {  get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RQOB028;Initial Catalog=HospitalSys;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
