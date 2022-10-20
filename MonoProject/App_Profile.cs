using AutoMapper;
using MonoProject.Service.Models;
using MonoProject.Models;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Service.Models;

namespace MonoProject
{
    public class App_Profile : Profile
    {
      
        public App_Profile()
            {
            CreateMap<Make, MakeViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
        }
        }
    }



