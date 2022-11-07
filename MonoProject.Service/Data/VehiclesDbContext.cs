using MonoProject.Service.Models;
using System.Data.Entity;

namespace MonoProject.Service.Data
{
    public class VehiclesDbContext : DbContext
    {
        public VehiclesDbContext() : base("VehiclesDbContext")
        {
        }
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasRequired(x => x.Make).WithMany().WillCascadeOnDelete(true);
        }
    }
}
