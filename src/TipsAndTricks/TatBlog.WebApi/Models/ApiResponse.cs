
using FluentValidation.Results;
using System.Net;

namespace TatBlog.WebApi.Models
{
    public class ApiResponse
    {
        public bool IsSucess => Errors.Count == 0;

        public HttpStatusCode StatusCode { get; init; }
        public IList<String> Errors { get; init; }

        protected ApiResponse()
        {
            StatusCode = HttpStatusCode.OK;
            Errors = new List<String>();
        }

        public static ApiResponse<T> Success<T>(T result, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResponse<T>
            {
                StatusCode = statusCode,
                Result = result
            };
        }

        public static ApiResponse<T> FailWithResult<T>(HttpStatusCode statusCode, T result, params string[] errorMessages)
        {
            return new ApiResponse<T>
            {
                Errors = new List<String>(errorMessages),
                StatusCode = statusCode,
                Result = result
            };
        }

        public static ApiResponse Fail(HttpStatusCode statusCode, params string[] errorMessages)
        {
            if (errorMessages == null || errorMessages.Length == 0)
            {
                throw new ArgumentNullException(nameof(errorMessages));
            }
            return new ApiResponse()
            {
                Errors = new List<String>(errorMessages),
                StatusCode = statusCode,
            };
        }

        public static ApiResponse Fail(HttpStatusCode statusCode, ValidationResult validationResult)
        {
            return Fail(statusCode, validationResult.Errors
                .Select(x => x.ErrorMessage)
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .ToArray());
        }

    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Result { get; set; }
    }
}

