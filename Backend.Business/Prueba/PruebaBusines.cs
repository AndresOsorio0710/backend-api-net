using Backend.Business.Interface.Prueba;
using Backend.Entities.References;
using Backend.Repository.Interface;
using Backend.Utilities;

namespace Backend.Business.Prueba
{
    public class PruebaBusines : IPruebaBusiness
    {
        private readonly IPruebaRepository pruebaRepository;
        public PruebaBusines(IPruebaRepository pruebaRepository)
        {
            this.pruebaRepository = pruebaRepository;
        }

        public Result<Entities.Models.Prueba> Add(Entities.Models.Prueba record)
        {
            Entities.Models.Prueba prueba = this.pruebaRepository.Add(record);
            return ResponseManager.ResponseOk200<Entities.Models.Prueba>(new List<Entities.Models.Prueba> { prueba });
        }

        public Result<Entities.Models.Prueba> Get(Entities.Models.Prueba record)
        {
            Entities.Models.Prueba prueba = this.pruebaRepository.Get(record);
            return ResponseManager.ResponseOk200<Entities.Models.Prueba>(new List<Entities.Models.Prueba> { prueba });
        }

        public Result<Entities.Models.Prueba> Update(Entities.Models.Prueba record)
        {
            Entities.Models.Prueba prueba = this.pruebaRepository.Update(record);
            return ResponseManager.ResponseOk200<Entities.Models.Prueba>(new List<Entities.Models.Prueba> { prueba });
        }
    }
}
