using MonoProject.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public interface IModelRepository
    {
        Task<List<Model>> GetModelsAsync();
        Task<Model> GetModelByIdAsync(int? id);
        Task UpdateModelAsync(Model model);
        Task CreateModelAsync(Model model);
        Task DeleteModelAsync(Model model);
    }
}
