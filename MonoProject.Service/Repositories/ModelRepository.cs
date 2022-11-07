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
        private readonly VehiclesDbContext db;

        public ModelRepository(VehiclesDbContext db)
        {
            this.db = db;
        }

        public async Task CreateModelAsync(Model model)
        {
            db.Makes.Attach(model.Make);
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

        public async Task<PagedList<Model>> GetModelsAsync(PaginationData pagination, FilteringData filtering, SortingData sorting)
        {

            int totalCount;
            var query = db.Models.AsQueryable();


            if (!string.IsNullOrEmpty(filtering.SearchString))
            {
                totalCount = db.Models.Where(x => x.Make.Name.ToLower().Contains(filtering.SearchString.ToLower()) || x.Make.Abrv.ToLower().Contains(filtering.SearchString.ToLower())
                    || x.Name.ToLower().Contains(filtering.SearchString.ToLower()) || x.Abrv.ToLower().Contains(filtering.SearchString.ToLower())).Count();
                query = query.Where(x => x.Name.ToLower().Contains(filtering.SearchString.ToLower())
               || x.Abrv.ToLower().Contains(filtering.SearchString.ToLower()) || x.Make.Name.ToLower().Contains(filtering.SearchString.ToLower()) ||
               x.Make.Abrv.ToLower().Contains(filtering.SearchString.ToLower()));
            }
            else
            {
                totalCount = db.Models.Count();
            }

            switch (sorting.SortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case "Abrv":
                    query = query.OrderBy(x => x.Abrv);
                    break;
                case "abrv_desc":
                    query = query.OrderByDescending(x => x.Abrv);
                    break;
                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }
            var finalQuery = await query.Skip((pagination.CurrentPage - 1) * pagination.PageSize)
               .Take(pagination.PageSize).ToListAsync();
            return PagedList<Model>.ToPagedList(finalQuery, totalCount, pagination);
        }

        public async Task UpdateModelAsync(Model model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
