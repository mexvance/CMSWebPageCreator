using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMSWebPageCreator.Models;

namespace CMSWebPageCreator.Models
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<CMSWebPageCreator.Models.BodyInfo> BodyInfo { get; set; }

        public DbSet<CMSWebPageCreator.Models.FooterInfo> FooterInfo { get; set; }

        public DbSet<CMSWebPageCreator.Models.HeaderInfo> HeaderInfo { get; set; }

        public DbSet<CMSWebPageCreator.Models.PageCreate> PageCreate { get; set; }
    }
}
