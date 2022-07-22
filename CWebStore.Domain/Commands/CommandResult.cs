namespace CWebStore.Domain.Commands;

public class CommandResult : Notifiable<Notification>, ICommandResult
{
    public CommandResult() { }

    public CommandResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    
    public CommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
    
    public CommandResult(bool success, string message, List<Notification> notifications)
    {
        Success = success;
        Message = message;
        Errors.AddRange(notifications);
    }

    public bool Success { get; set; }

    public string Message { get; set; }

    public object Data { get; set; }

    public List<Notification> Errors { get; set; } = new();
}