namespace MonoProject.Service.Models.Common
{
    public interface IModel
    {
        int ID { get; set; }
        Make Make { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
