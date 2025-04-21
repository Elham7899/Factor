namespace Services;
public class ServiceResult
{
    //Ctor
    public ServiceResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    //Props
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    //Methods
    public static ServiceResult Ok(string message)
    {
        return new ServiceResult(true, message);
    }
    public static ServiceResult Ok()
    {
        return Ok("Operation Success");
    }

    public static ServiceResult NotFound(string message)
    {
        return new ServiceResult(false, message);
    }

    public static ServiceResult<TData> NotFound<TData>(string message) where TData : class
    {
        return new ServiceResult<TData>(false, message, null);
    }

    public static ServiceResult BadRequest(string message)
    {
        return new ServiceResult(false, message);
    }
    public static ServiceResult<TData> BadRequest<TData>(string message) where TData : class
    {
        return new ServiceResult<TData>(false, message, null);
    }
 
    public static ServiceResult<TData> Ok<TData>(TData data) where TData : class
    {
        return new ServiceResult<TData>(true, "Operation Success", data);
    }
}

public class ServiceResult<TData> : ServiceResult where TData : class
{
    public ServiceResult(bool isSuccess, string message, TData data) : base(isSuccess, message)
    {
        Data = data;
    }

    public TData Data { get; set; }
}

