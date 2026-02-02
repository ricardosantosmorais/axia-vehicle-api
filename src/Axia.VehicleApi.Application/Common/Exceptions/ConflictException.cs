namespace Axia.VehicleApi.Application.Common.Exceptions;

public sealed class ConflictException : Exception
{
    public ConflictException(string message) : base(message) { }
}
