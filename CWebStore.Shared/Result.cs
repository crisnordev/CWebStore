namespace CWebStore.Shared;

public class Result : Notifiable<Notification>, IResult
{
    public Result() { }


    public Result(string message)
    {
        Message = message;
    }
    
    public Result(bool success)
    {
        Success = success;
    }
    
    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; set; }
    
    public string Message { get; set; }
}