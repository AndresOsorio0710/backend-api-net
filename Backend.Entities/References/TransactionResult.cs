using Backend.Entities.Enums;

namespace Backend.Entities.References
{
    public class TransactionResult
    {
        /// <summary>
        /// Response code for internal operation management
        /// </summary>
        public ResponseCode ResponseCode { get; set; }
        /// <summary>
        /// Response message for internal operations management
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Transaction identifier for internal operations management
        /// </summary>
        public string TransactionResultId { get; set; }
        /// <summary>
        /// Indicates the number of records affected in the transaction, whether they are modified, registered or consulted records
        /// </summary>
        public int? RecordsInvolved { get; set; }

        public TransactionResult() { 
            this.ResponseCode = ResponseCode.Ok;
            this.Message = "OK";
            this.RecordsInvolved = 0;
            this.TransactionResultId = Guid.NewGuid().ToString();
        }
    }
}
