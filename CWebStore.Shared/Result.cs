namespace CWebStore.Shared;

public class Result<T> : Notifiable<Notification>,IResult
{
    public Result() { }

    public Result(T data)
    {
        Data = data;
    }

    public Result(T data, string message)
    {
        Data = data;
        Message = message;
    }

    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public Result(bool success, T data)
    {
        Success = success;
        Data = data;
    }

    public Result(bool success, T data, string message)
    {
        Success = success;
        Data = data;
        Message = message;
    }

    public bool Success { get; set; }

    public T Data { get; set; }
    
    public string Message { get; set; }
    
    
}