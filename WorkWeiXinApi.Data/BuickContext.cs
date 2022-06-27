using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WorkWeiXinApi.Model;

#nullable disable

namespace WorkWeiXinApi.Data
{
    public class BuickContext : DbContext
    {
        public BuickContext()
        {
        }

        public BuickContext(DbContextOptions<BuickContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WorkWeiXinApiAccessToken> WorkWeiXinApiAccessTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WorkWeiXinApiAccessToken>();

            base.OnModelCreating(modelBuilder);         }

    }
}
