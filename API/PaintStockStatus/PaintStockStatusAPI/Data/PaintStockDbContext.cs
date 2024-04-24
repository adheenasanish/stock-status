using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PaintStockStatusAPI.Models;

namespace PaintStockStatusAPI.Data
{
    public class PaintStockDbContext: DbContext
    {
        public string DbPath { get; }
        public PaintStockDbContext(DbContextOptions<PaintStockDbContext> options) : base(options)
        {
           // DbPath = "stcok-status.db";
        }

        //DbSet
        public DbSet<Paint> Paints { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaintStatus> PaintStatuses { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlite($"Data Source={DbPath}");


    }
}
