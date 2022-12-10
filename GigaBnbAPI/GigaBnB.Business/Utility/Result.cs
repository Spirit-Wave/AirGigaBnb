using System.Diagnostics.CodeAnalysis;

namespace GigaBnB.Business.Utility;

public struct Result<T>
{
    private Exception Exception = new();
    [AllowNull]
    private T Value = default;

    public Result(T value)
    {
        this.Value = value;
    }

    public Result(Exception exception)
    {
        this.Exception = exception;
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(value);
    }
}