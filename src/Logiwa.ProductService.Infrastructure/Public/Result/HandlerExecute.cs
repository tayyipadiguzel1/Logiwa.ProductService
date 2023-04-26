using Logiwa.ProductService.Infrastructure.Enums;

namespace Logiwa.ProductService.Infrastructure.Public.Result
{
    /// <summary>
    /// ServiceExecute
    /// </summary>
    public class HandlerExecute
    {
        public ServiceResponse ServiceResponse()
        {
            return ServiceResponse(ResultCode.Success, "");
        }
        public ServiceResponse ServiceResponse(ResultCode resultCode, string message)
        {
            var sr = new ServiceResult(resultCode, message);
            return sr.ExecuteResult();
        }
        
        public ServiceResponse<T> ServiceResponse<T>(T data, ResultCode resultCode = ResultCode.Success, string message = "")
        {
            if (data == null)
            {
                resultCode = ResultCode.NoContent;
                message = "";
            }
            var sr = new ServiceResult<T>(data, resultCode, message);
            return sr.ExecuteResult();
        }

        public ServiceResponse NoContent()
        {
            var sr = new ServiceResult(ResultCode.NoContent, "");
            return sr.ExecuteResult();
        }
        
        public ServiceResponse<T> NoContent<T>()
        {
            var sr = new ServiceResult<T>(default(T), ResultCode.NoContent, "");
            return sr.ExecuteResult();
        }
        
        public ServiceResponse<T> NoContent<T>(string message)
        {
            var sr = new ServiceResult<T>(default(T), ResultCode.NoContent, message);
            return sr.ExecuteResult();
        }
        
        public ServiceResponseList<T> NoContentList<T>()
        {
            var sr = new ServiceResultList<T>(null, ResultCode.NoContent, "");
            return sr.ExecuteResult();
        }
        
        public ServiceResponse<T> Warning<T>(string message)
        {
            var sr = new ServiceResult<T>(default(T), ResultCode.Warning, message);
            return sr.ExecuteResult();
        }
        public ServiceResponse Warning(string message)
        {
            var sr = new ServiceResult(ResultCode.Warning, message);
            return sr.ExecuteResult();
        }

        public ServiceResponseList<T> ServiceResponseList<T>(IList<T> data, ResultCode resultCode = ResultCode.Success, string message = "")
        {
            var sr = new ServiceResultList<T>(data, resultCode, message);
            return sr.ExecuteResult();
        }

        public ServiceResponsePagination<T> ServiceResponsePagination<T>(IList<T> data, PaginationDto page, ResultCode resultCode = ResultCode.Success, string message = "")
        {
            data = data.ToList();
            return new ServiceResponsePagination<T>
            {
                Result = new PaginationList<T>(page, data),
                ResultCode = resultCode,
                ResultMessage = message
            };
        }
    }
}
