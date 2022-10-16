using MonoProject.Service.Models;
using Service.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Service
{
    public class MakeService : IMakeService
    {
        private Repositories.IMakeRepository makeRepo;

        public MakeService(IMakeRepository makeRepo)
        {
            this.makeRepo = makeRepo;
        }

        public async Task CreateMakeAsync(Make make)
        {
            await makeRepo.CreateMakeAsync(make);
        }

        public async Task DeleteMakeAsync(int id)
        {
            Make make = await makeRepo.GetMakeByIdAsync(id);
            await makeRepo.DeleteMakeAsync(make);
        }

        public async Task<Make> GetMakeByIdAsync(int? id)
        {
          return await makeRepo.GetMakeByIdAsync(id);
        }

        public async Task<List<Make>> GetMakesAsync()
        {
            return await makeRepo.GetMakesAsync();
        }

        public async Task UpdateMakeAsync(Make make)
        {
            await makeRepo.UpdateMakeAsync(make);
        }
    }
}
