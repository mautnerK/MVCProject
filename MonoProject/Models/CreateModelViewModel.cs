using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoProject.Models
{
    public class CreateModelViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int Make { get; set; }
    }
}