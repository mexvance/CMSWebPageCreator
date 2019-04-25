using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMSWebPageCreator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CMSWebPageCreator.Models
{
    public class DBContext : IdentityDbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PageCreate>()
                .HasMany(p => p.Headers);
            modelBuilder.Entity<PageCreate>()
                .HasMany(p => p.BodyItems);
            modelBuilder.Entity<PageCreate>()
                .HasMany(p => p.FooterItems);
        }

        public DbSet<CMSWebPageCreator.Models.BodyInfo> BodyInfo { get; set; }

        public DbSet<CMSWebPageCreator.Models.FooterInfo> FooterInfo { get; set; }

        public DbSet<CMSWebPageCreator.Models.HeaderInfo> HeaderInfo { get; set; }

        public DbSet<CMSWebPageCreator.Models.PageCreate> PageCreate { get; set; }

        public DbSet<CMSWebPageCreator.Models.Comment> Comment { get; set; }
    }
}
    
