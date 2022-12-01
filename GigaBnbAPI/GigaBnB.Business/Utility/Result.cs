using System.Diagnostics.CodeAnalysis;

namespace GigaBnB.Business.Utility;

public struct Result<T>
{
    public Exception Exception = new();
    [AllowNull]
    public T Value = default;

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