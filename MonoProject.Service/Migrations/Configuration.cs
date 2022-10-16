using MonoProject.Service.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Service.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MonoProject.Service.Data.VehiclesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MonoProject.Service.Data.VehiclesDbContext context)
        {
            var makes = new Make[]
            {
                new Make{ Name = "Bugatti", Abrv = "BGT"},
                new Make{ Name = "Volkswagen", Abrv = "VW"},
                new Make { Name = "Bayerische Motoren Werke", Abrv = "BMW" }
        };
            var models =new Model[]
            {
                new Model{ Name = "Veyron", Abrv = "Veyron",Make= makes.FirstOrDefault(x=> x.Name.Equals("Bugatti"))},
                new Model{ Name = "Golf", Abrv = "GF",Make= makes.FirstOrDefault(x=> x.Name.Equals("Volkswagen"))},
                new Model { Name = "i8", Abrv = "i7" ,Make= makes.FirstOrDefault(x=> x.Name.Equals("Bayerische Motoren Werke"))}
        };
            context.Makes.AddOrUpdate(makes);
            context.Models.AddOrUpdate(models);
            context.SaveChanges();
        }
    }
}
