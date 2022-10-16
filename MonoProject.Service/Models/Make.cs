using MonoProject.Service.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonoProject.Service.Models
{
    public class Make : IMake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
