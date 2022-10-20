using MonoProject.Service.Models;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public interface IModelRepository
    {
        Task<PagedList<Model>> GetModelsAsync(string sortOrder, string currentFilter, string searchString, int? page);
        Task<Model> GetModelByIdAsync(int? id);
        Task UpdateModelAsync(Model model);
        Task CreateModelAsync(Model model);
        Task DeleteModelAsync(Model model);
    }
}
