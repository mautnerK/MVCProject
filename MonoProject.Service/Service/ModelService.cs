using MonoProject.Service.Models;
using Service.Models;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ModelService : IModelService
    {
        private Repositories.IModelRepository modelRepo;

        public ModelService(IModelRepository modelRepo)
        {
            this.modelRepo = modelRepo;
        }

        public async Task CreateModelAsync(Model model)
        {
            await modelRepo.CreateModelAsync(model);    
        }

        public async Task DeleteModelAsync(int id)
        {
            Model model = await modelRepo.GetModelByIdAsync(id);
            await modelRepo.DeleteModelAsync(model);
        }

        public async Task<PagedList<Model>> GetModelAsync(string sortOrder, string currentFilter, string searchString, int? page)
        {
            return await modelRepo.GetModelsAsync(sortOrder, currentFilter, searchString, page);
         }

        public async Task<Model> GetModelByIdAsync(int? id)
        {
               return await modelRepo.GetModelByIdAsync(id);
        }

        public async Task UpdateModelAsync(Model model)
        {
            await modelRepo.UpdateModelAsync(model);
        }
    }
}
