namespace GigaBnB.Business.Filters.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(Dictionary<string, string> message)
    {
        Messages = message;
    }

    public Dictionary<string, string> Messages { get; set; }
}