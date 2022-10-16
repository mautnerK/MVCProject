using System.Collections.Generic;
using System.Threading.Tasks;
using MonoProject.Service.Models;

namespace Service.Service
{
    public interface IMakeService
    {
        Task<List<Make>> GetMakesAsync();
        Task<Make> GetMakeByIdAsync(int? id);
        Task UpdateMakeAsync(Make make);
        Task CreateMakeAsync(Make make);
        Task DeleteMakeAsync(int id);
    }
}
