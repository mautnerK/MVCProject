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

        public async Task<PagedList<Make>> GetMakesAsync(string sortOrder, string currentFilter, string searchString, int? page)
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
                List<Make> list = new List<Make>();
                list = await db.Makes.Where(x => x.Name.Contains(searchString) || x.Abrv.Contains(searchString)).ToListAsync();
                return PagedList<Make>.ToPagedList(list, pageNumber, pageSize);
            }
            else
            {
                List<Make> lista = new List<Make>();
                switch (sortOrder)
                {
                    case "name_desc":
                    
                        lista = await db.Makes.OrderByDescending(x => x.Name).ToListAsync();
                        return PagedList<Make>.ToPagedList(lista, pageNumber, pageSize);
                    case "Abrv":
                        lista = await db.Makes.OrderBy(x => x.Abrv).ToListAsync();
                        return PagedList<Make>.ToPagedList(lista, pageNumber, pageSize);
                    case "abrv_desc":
                        lista = await db.Makes.OrderByDescending(x => x.Abrv).ToListAsync();
                        return PagedList<Make>.ToPagedList(lista, pageNumber, pageSize);
                    default:
                        lista = await db.Makes.OrderBy(x => x.Name).ToListAsync();
                        return PagedList<Make>.ToPagedList(lista, pageNumber, pageSize);

                }
            }

        }

        public async Task UpdateMakeAsync(Make make)
        {

            db.Entry(make).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
