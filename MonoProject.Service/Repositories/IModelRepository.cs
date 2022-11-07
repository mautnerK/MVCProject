using MonoProject.Service.Models;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public interface IModelRepository
    {
        Task<PagedList<Model>> GetModelsAsync(PaginationData pagination, FilteringData filtering, SortingData sorting);
        Task<Model> GetModelByIdAsync(int? id);
        Task UpdateModelAsync(Model model);
        Task CreateModelAsync(Model model);
        Task DeleteModelAsync(Model model);
    }
}
