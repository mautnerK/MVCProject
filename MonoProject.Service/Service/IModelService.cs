using MonoProject.Service.Models;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IModelService
    {
        Task<PagedList<Model>> GetModelAsync(PaginationData pagination, FilteringData filtering, SortingData sorting);
        Task<Model> GetModelByIdAsync(int? id);
        Task UpdateModelAsync(Model model);
        Task CreateModelAsync(Model model);
        Task DeleteModelAsync(int id);
    }
}
