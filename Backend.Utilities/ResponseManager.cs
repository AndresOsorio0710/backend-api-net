using Backend.Entities.Enums;
using Backend.Entities.References;

namespace Backend.Utilities
{
    public class ResponseManager
    {
        public static Result<T> ResponseOk200<T>(ICollection<T> data)
        {
            return new Result<T>
            {
                TransactionResult = new TransactionResult
                {
                    ResponseCode = ResponseCode.Ok,
                    Message = "Ok",
                    RecordsInvolved = data.Count,
                    TransactionResultId = Guid.NewGuid().ToString(),
                },
                Data = data
            };
        }
        public static Result<T> ResponseOk200<T>(ICollection<T> data, string message)
        {
            return new Result<T>
            {
                TransactionResult = new TransactionResult
                {
                    ResponseCode = ResponseCode.Ok,
                    Message = message,
                    RecordsInvolved = data.Count,
                    TransactionResultId = Guid.NewGuid().ToString(),
                },
                Data = data
            };
        }
        public static Result<T> ResponseOk200<T>(ICollection<T> data, string message, Authorization authorization)
        {
            return new Result<T>
            {
                TransactionResult = new TransactionResult
                {
                    ResponseCode = ResponseCode.Ok,
                    Message = message,
                    RecordsInvolved = data.Count,
                    TransactionResultId = Guid.NewGuid().ToString(),
                },
                Data = data,
                Authorization = authorization
            };
        }
        public static Result<T> ResponseOk200<T>(ICollection<T> data, Authorization authorization)
        {
            return new Result<T>
            {
                TransactionResult = new TransactionResult
                {
                    ResponseCode = ResponseCode.Ok,
                    Message = "Ok",
                    RecordsInvolved = data.Count,
                    TransactionResultId = Guid.NewGuid().ToString(),
                },
                Data = data,
                Authorization = authorization
            };
        }
        public static Result<T> ResponseConflict409<T>(string message)
        {
            return new Result<T>
            {
                TransactionResult = new TransactionResult
                {
                    ResponseCode = ResponseCode.Conflict,
                    Message = message,
                    RecordsInvolved = 0,
                    TransactionResultId = String.Empty,
                }
            };
        }
    }
}
