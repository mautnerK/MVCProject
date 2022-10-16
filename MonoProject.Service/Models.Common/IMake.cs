using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoProject.Service.Models.Common
{
    public interface IMake
    {
        int ID { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
