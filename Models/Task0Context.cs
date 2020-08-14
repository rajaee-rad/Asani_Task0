using Microsoft.EntityFrameworkCore;
using Asani_Task0.Models;
namespace Asani_Task0.Models
{
    public class Task0Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlite("Data Source=Task0.db");

        public DbSet<Estate> Estates { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Position> Positions { get; set;}
    }
}