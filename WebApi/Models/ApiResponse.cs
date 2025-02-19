namespace WebApi.Models;

public class ApiResponse<T>
{

    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public T Result { get; set; }
    public ApiResponse(bool isSuccess, int statusCode, string message, T result)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message;
        Result = result;
    }
}
