using MonoProject.Service.Data;
using MonoProject.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace Service.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        private VehiclesDbContext db;

        public MakeRepository(VehiclesDbContext db)
        {
            this.db = db;
        }

        public async Task CreateMakeAsync(Make make)
        {
            db.Makes.Add(make);
            await db.SaveChangesAsync();
        }

            public async Task DeleteMakeAsync(Make make)
        {
            db.Makes.Remove(make);
            await db.SaveChangesAsync();
        }

        public async Task<Make> GetMakeByIdAsync(int? id)
        {
           return await db.Makes.FindAsync(id);
        }

        public async Task<List<Make>> GetMakesAsync()
        {
            return await db.Makes.ToListAsync();
        }

        public async Task UpdateMakeAsync(Make make)
        {
            db.Entry(make).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
