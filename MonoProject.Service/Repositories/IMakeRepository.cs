using System.Collections.Generic;
using System.Threading.Tasks;
using MonoProject.Service.Models;
namespace Service.Repositories
{
    public interface IMakeRepository
    {
        Task<List<Make>> GetMakesAsync();
        Task<Make> GetMakeByIdAsync(int? id);
        Task UpdateMakeAsync(Make make);
        Task CreateMakeAsync(Make make);
        Task DeleteMakeAsync(Make make);
    }
}
