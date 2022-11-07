using MonoProject.Service.Data;
using MonoProject.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using Service.Models;

namespace Service.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        private readonly VehiclesDbContext db;

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
        public async Task<List<Make>> GetAllMakesAsync()
        {
            return await db.Makes.ToListAsync();
        }

        public async Task<PagedList<Make>> GetMakesAsync(PaginationData pagination, FilteringData filtering, SortingData sorting)
        {
            int totalCount;
            var query = db.Makes.AsQueryable();


            if (!string.IsNullOrEmpty(filtering.SearchString))
            {
                totalCount = db.Makes.Where(x => x.Name.ToLower().Contains(filtering.SearchString.ToLower()) || x.Abrv.ToLower().Contains(filtering.SearchString.ToLower())).Count();
                 query = query.Where(x => x.Name.ToLower().Contains(filtering.SearchString.ToLower())
                || x.Abrv.ToLower().Contains(filtering.SearchString.ToLower()));
            }
            else
            {
                totalCount = db.Makes.Count();
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
            return PagedList<Make>.ToPagedList(finalQuery, totalCount, pagination);

        }

        public async Task UpdateMakeAsync(Make make)
        {

            db.Entry(make).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
