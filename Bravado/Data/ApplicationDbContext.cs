﻿using System;
using Bravado.Models;
using Bravado.Models.Agile;
using Bravado.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        #region AGILE WORKBOARD
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }
        #endregion

        #region SERVICE DBSETS
        public DbSet<ServiceEntity> ServiceEntity { get; set; }
        #endregion
    }
}
