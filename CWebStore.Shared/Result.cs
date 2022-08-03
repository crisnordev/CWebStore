namespace CWebStore.Shared;

public class Result : IResult
{
    public Result() { }

    public Result(bool success) 
    {
        Success = success;
    }
    
    public Result(object data)
    {
        Data = data;
    }
    
    public Result(IEnumerable<object> dataList)
    {
        DataList = new List<object>();
        DataList.ToList().AddRange(dataList);
    }
    
    public Result(bool success, object data)
    {
        Success = success;
        Data = data;
    }

    public Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public Result(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public Result(bool success, string message, IEnumerable<Notification> notifications)
    {
        Success = success;
        Message = message;
        Notifications = new List<Notification>();
        Notifications.ToList().AddRange(notifications);
    }

    public Result(bool success, string message, object data, IEnumerable<Notification> notifications)
    {
        Success = success;
        Message = message;
        Data = data;
        Notifications = new List<Notification>();
        notifications.ToList().AddRange(notifications);
    }


    public bool Success { get; set; }

    public string Message { get; set; }

    public object Data { get; set; }

    public IEnumerable<object> DataList { get; set; }
    
    public IEnumerable<Notification> Notifications { get; set; }
}