using System;

using Bravado.Models;
using Bravado.Models.Wiki;
using Bravado.Models.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bravado.Models.Agile;

namespace Bravado.Data {
    public class AppDbContext : IdentityDbContext<ApplicationUser> {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        #region WIKIS 
        public DbSet<Entry> Entries { get; set; }
        #endregion

        #region AGILE 
        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Column> Columns { get; set; }
        #endregion

        #region SERVICE DBSETS
        public DbSet<ServiceEntity> ServiceEntity { get; set; }
        #endregion
    }
}