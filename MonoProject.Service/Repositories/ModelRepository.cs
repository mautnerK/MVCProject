using MonoProject.Service.Data;
using MonoProject.Service.Models;
using Service.Models;
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

        public async Task<PagedList<Model>> GetModelsAsync(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                List<Model> list = new List<Model>();
                list = await db.Models.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString)).ToListAsync();
                return PagedList<Model>.ToPagedList(list, pageNumber, pageSize);
            }
            else
            {
                List<Model> lista = new List<Model>();
                switch (sortOrder)
                {
                    case "name_desc":

                        lista = await db.Models.OrderByDescending(x => x.Name).ToListAsync();
                        return PagedList<Model>.ToPagedList(lista, pageNumber, pageSize);
                    case "Abrv":
                        lista = await db.Models.OrderBy(x => x.Abrv).ToListAsync();
                        return PagedList<Model>.ToPagedList(lista, pageNumber, pageSize);
                    case "abrv_desc":
                        lista = await db.Models.OrderByDescending(x => x.Abrv).ToListAsync();
                        return PagedList<Model>.ToPagedList(lista, pageNumber, pageSize);
                    default:
                        lista = await db.Models.OrderBy(x => x.Name).ToListAsync();
                        return PagedList<Model>.ToPagedList(lista, pageNumber, pageSize);
                }
            }
        }

        public async Task UpdateModelAsync(Model model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
