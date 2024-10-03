using Microsoft.EntityFrameworkCore;
using CaseManagementPortal.Models;

namespace CaseManagementPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Recertification> Recertifications { get; set; }
    }
}
