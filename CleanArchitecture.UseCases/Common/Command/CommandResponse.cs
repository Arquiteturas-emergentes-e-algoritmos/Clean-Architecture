namespace CleanArchitecture.UseCases.Common.Command;

public class CommandResponse : ICommandResponse
{
    public CommandResponse(int status)
    {
        Status = status;
    }
    public CommandResponse(object? data, int status)
    {
        Data = data;
        Status = status;
    }
    public CommandResponse(object? data, string message, int status)
    {
        Data = data;
        Message = message;
        Status = status;
    }

    public object? Data { get; set; } = null;
    public string Message { get; set; } = string.Empty;
    public int Status { get; set; } = 500;
}
