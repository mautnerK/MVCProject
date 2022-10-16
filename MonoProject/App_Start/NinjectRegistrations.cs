using Service.Service;
using Service.Repositories;
using AutoMapper;

namespace MonoProject.App_Start
{
    public class NinjectRegistrations : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<System.Data.Entity.DbContext>().To<Service.Data.VehiclesDbContext>();
            Bind<IMakeRepository>().To<MakeRepository>();
            Bind<IMakeService>().To<MakeService>();
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<App_Profile>(); });
            Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();

        }
    }
}