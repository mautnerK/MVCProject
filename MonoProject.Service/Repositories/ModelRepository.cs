using MonoProject.Service.Data;
using MonoProject.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private VehiclesDbContext db;

        public ModelRepository(VehiclesDbContext db)
        {
            this.db = db;
        }

        public async Task CreateModelAsync(Model model)
        {
            db.Models.Add(model);
            await   db.SaveChangesAsync();
        }

        public async Task DeleteModelAsync(Model model)
        {
            db.Models.Remove(model);
            await db.SaveChangesAsync();
        }

        public async Task<Model> GetModelByIdAsync(int? id)
        {
          return await  db.Models.FindAsync(id);
        }

        public async Task<List<Model>> GetModelsAsync()
        {
            return await db.Models.ToListAsync();
        }

        public async Task UpdateModelAsync(Model model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
