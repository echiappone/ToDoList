namespace ToDoList.Domain.DTO;

public class Result<T>
{
    public Result(List<string> errors)
    {
        Errors = errors;
        Success = false;
    }

    public Result(T data)
    {
        Data = data;
        Success = true;
    }

    public Result(string erro)
    {
        Errors = new List<string>() { erro };
        Success = false;
    }

    public bool Success { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }
}
