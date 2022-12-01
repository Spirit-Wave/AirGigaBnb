namespace GigaBnB.Business.Validation;

public class BaseValidator
{
    public void AddError(string key, string errorMessage)
    {
        if (Errors.ContainsKey(key))
        {
            Errors[key].Add(errorMessage);
        }
        else
        {
            Errors.Add(key, new List<string> {errorMessage});
        }
    }

    public Dictionary<string, List<string>> Errors { get; set; } = new();
}