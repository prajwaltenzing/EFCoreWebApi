using System.Net;

namespace EFCoreWebApi.Client.Models;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Result { get; set; }

    public Response()
    {

    }
    public Response(T result, string message, HttpStatusCode statusCode, bool isSuccuess)
    {
        IsSuccess = isSuccuess;
        Message = message;
        StatusCode = (int)statusCode;
        Result = result;
    }

    public Response(T result, HttpStatusCode? statusCode = HttpStatusCode.OK)
    {
        IsSuccess = true;
        Message = null;
        StatusCode = (int)statusCode!;
        Result = result;
    }
    public Response(string? message = null, HttpStatusCode? statusCode = HttpStatusCode.OK, bool? isSuccuess = true)
    {
        IsSuccess = isSuccuess ?? true;
        Message = message;
        StatusCode = (int)statusCode!;
        Result = default(T);
    }
    public Response(T result)
    {
        IsSuccess = true;
        Message = null;
        StatusCode = 200;
        Result = result;
    }
}
