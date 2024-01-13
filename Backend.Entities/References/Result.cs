namespace Backend.Entities.References
{
    public class Result<EType>
    {
        public TransactionResult TransactionResult { get; set; }
        public ICollection<EType> Data { get; set; }
        public Authorization? Authorization { get; set; }

        public Result()
        {
            this.TransactionResult = new TransactionResult();
            this.Data = new HashSet<EType>();
        }
    }
}
