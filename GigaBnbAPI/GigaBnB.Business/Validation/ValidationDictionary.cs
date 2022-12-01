using GigaBnB.Business.Filters.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace GigaBnB.Business.Validation;

public class ValidationDictionary : IValidation
{
    public Dictionary<string, string> Errors { get; set; } = new();

    public void AddError(string key, string errorMessage)
    {
        Errors.Add(key, errorMessage);
    }

    public bool IsValid => Errors.IsNullOrEmpty();
    public void ThrowErrorsIfExists()
    {
        if (!IsValid)
        {
            throw new ValidationException(Errors);
        }
    }
}