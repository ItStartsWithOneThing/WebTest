using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebTestDAL.Entities;

namespace WebTestDAL
{
    public class EFCoreContext : DbContext
    {
        public DbSet<BodyKitDto> BodyKits { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
