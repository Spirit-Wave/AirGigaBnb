namespace GigaBnB.Business.Validation;

public interface IValidation
{
    Dictionary<string, string> Errors { get; set;}

    void AddError(string key, string errorMessage);

    bool IsValid { get; }

    void ThrowErrorsIfExists();
}