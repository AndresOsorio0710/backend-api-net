namespace Backend.Repository.Interface
{
    public interface IDBFirebaseRepository<EType>
    {
        public EType Get(EType record);
        public EType Add(EType record);
        public EType Update(EType record);
    }
}
