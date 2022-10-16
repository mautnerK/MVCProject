using MonoProject.Service.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonoProject.Service.Models
{
    public class Model : IModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Make Make { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
