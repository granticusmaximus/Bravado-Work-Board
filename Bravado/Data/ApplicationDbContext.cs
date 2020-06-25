using Bravado.Models;
using Bravado.Models.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        #region AGILE WORKBOARD
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Task> Tasks { get; set; }
        #endregion

        #region SERVICE DBSETS
        public DbSet<BrandService> Brand { get; set; }
        public DbSet<DevelopmemtService> Development { get; set; }
        public DbSet<EmailService> EmailServices { get; set; }
        public DbSet<HostService> Host { get; set; }
        public DbSet<SeoService> SEO { get; set; }
        #endregion
    }
}
