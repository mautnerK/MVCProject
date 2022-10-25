using System.Collections.Generic;
using System.Threading.Tasks;
using MonoProject.Service.Models;
using Service.Models;
namespace Service.Service
{
    public interface IMakeService
    {
        Task<PagedList<Make>> GetMakesAsync(PaginationData pagination);
        Task<Make> GetMakeByIdAsync(int? id);
        Task UpdateMakeAsync(Make make);
        Task CreateMakeAsync(Make make);
        Task DeleteMakeAsync(int id);
    }
}
