using Backend.Entities.References;

namespace Backend.Business.Interface.Prueba
{
    public interface IPruebaBusiness
    {
        public Result<Entities.Models.Prueba> Get(Entities.Models.Prueba record);
        public Result<Entities.Models.Prueba> Add(Entities.Models.Prueba record);
        public Result<Entities.Models.Prueba> Update(Entities.Models.Prueba record);
    }
}
