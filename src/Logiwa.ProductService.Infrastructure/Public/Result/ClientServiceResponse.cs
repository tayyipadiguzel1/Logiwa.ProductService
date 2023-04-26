namespace Logiwa.ProductService.Infrastructure.Public.Result
{
    /// <summary>
    /// ClientServiceResponse
    /// </summary>
    public class ClientServiceResponse
    {
        public ClientServiceResponse()
        {

        }

        public ClientServiceResponse(ClientResultCode typeCode, string title, string message)
        {
            TypeCode = typeCode;
            Title = title;
            Messages = new List<string> { message };
        }
        public ClientResultCode TypeCode { get; set; }
        public string Type => TypeCode.ToString().ToLower();
        public string Action => "default";
        public bool Visible => true;
        public string Title { get; set; }
        public List<string> Messages { get; set; }
        public string Message => Messages.FirstOrDefault();
    }
    
    
    /// <summary>
    /// ClientServiceResponse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ClientServiceResponse<T> : ClientServiceResponse
    {
        public ClientServiceResponse(ClientResultCode typeCode, string title, List<string> messages, T validations)
        {
            TypeCode = typeCode;
            Title = title;
            Validations = validations;
            Messages = messages;
        }
        public T Validations { get; set; }
    }

    /// <summary>
    /// ResultCode
    /// </summary>
    public enum ClientResultCode
    {
        Error = 500,
        Validation = 400,
        Authorization = 401,
        Warning = 418,
    }
}
