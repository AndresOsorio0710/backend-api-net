using Backend.Entities.Models;
using Backend.Repository.Interface;

namespace Backend.Repository
{
    public class PruebaRepository : IPruebaRepository
    {
        private readonly DBFirebaseRepository<Prueba> dBFirebaseRepository;
        public PruebaRepository() {
            this.dBFirebaseRepository = new DBFirebaseRepository<Prueba> ();
        }

        public Prueba Add(Prueba record)
        {
            return this.dBFirebaseRepository.Add(record);
        }

        public Prueba Get(Prueba record)
        {
            return this.dBFirebaseRepository.Get(record);
        }

        public Prueba Update(Prueba record)
        {
            return this.dBFirebaseRepository.Update(record);
        }
    }
}
