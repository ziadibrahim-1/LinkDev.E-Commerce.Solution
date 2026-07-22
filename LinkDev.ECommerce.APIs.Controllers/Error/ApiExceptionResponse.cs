using System.Text.Json;

namespace LinkDev.ECommerce.APIs.Controllers.Error
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int statusCode , string? message= null ,string? details = null)
            :base(statusCode,message)
        {
            Details = details;
        }

        public override string ToString()
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this);
        }
    }
}
