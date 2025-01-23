namespace FileProcessorDomain.Models;

public class ResponseBase<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    // Respuestas exitosas
    public ResponseBase(int statusCode, string message, T data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
    
    // Repuestras con error
    public ResponseBase(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
        Data = default;
    }
}
