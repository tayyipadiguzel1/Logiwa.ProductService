using Logiwa.ProductService.Infrastructure.Enums;

namespace Logiwa.ProductService.Infrastructure.Public.Result
{
    /// <summary>
    /// ServiceResponse
    /// </summary>
    public class ServiceResponseMessage
    {
        public ServiceResponseMessage()
        {

        }
        public ServiceResponseMessage(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public List<string> Messages => string.IsNullOrEmpty(Message) ? new() : new() { Message };
    }
    
    /// <summary>
    /// ServiceResponse
    /// </summary>
    public class ServiceResponse
    {
        public ResultCode ResultCode { get; set; }
        public string ResultCodeText => ResultCode.ToString();
        public string Title { get; set; }
        public string ResultMessage { get; set; }
        public bool Show { get; set; }
        public bool Success => ResultCode == ResultCode.Success;
        public int Version { get; set; }
    }

    /// <summary>
    /// ServiceResponse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T> : ServiceResponse
    {
        public T Result { get; set; }
    }

    /// <summary>
    /// ServiceResponseList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponseList<T> : ServiceResponse
    {
        public ServiceResponseList()
        {
            Result = new List<T>();
        }
        public bool Any => Result != null && Result.Any();
        public IList<T> Result { get; set; }
    }
    
    
    /// <summary>
    /// ServiceResponsePagination
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponsePagination<T> : ServiceResponse
    {
        public PaginationList<T> Result { get; set; }

        public ServiceResponseList<T> Switch()
        {
            return new ServiceResponseList<T>
            {
                Result = Result.Items,
                ResultMessage = ResultMessage,
                ResultCode = ResultCode,
                Show = Show,
                Version = Version
            };
        }
    }
    
}
