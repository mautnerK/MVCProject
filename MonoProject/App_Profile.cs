using AutoMapper;
using MonoProject.Service.Models;
using MonoProject.Models;

namespace MonoProject
{
    public class App_Profile: Profile
    {
        public App_Profile()
        {
            CreateMap<Make, MakeViewModel>().ReverseMap();

        }


    }
}