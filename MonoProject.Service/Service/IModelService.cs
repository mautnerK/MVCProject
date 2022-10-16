using MonoProject.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IModelService
    {
        Task<List<Model>> GetModelAsync();
        Task<Model> GetModelByIdAsync(int? id);
        Task UpdateModelAsync(Model model);
        Task CreateModelAsync(Model model);
        Task DeleteModelAsync(int id);
    }
}
