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
    }
}
