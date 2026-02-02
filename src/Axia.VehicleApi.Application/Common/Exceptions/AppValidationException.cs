namespace Axia.VehicleApi.Application.Common.Exceptions;

public sealed class AppValidationException : Exception
{
    public AppValidationException(IDictionary<string, string[]> errors)
        : base("One or more validation failures have occurred.")
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
}
