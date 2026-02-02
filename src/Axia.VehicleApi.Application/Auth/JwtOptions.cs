namespace Axia.VehicleApi.Application.Auth;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; init; } = "Axia.VehicleApi";
    public string Audience { get; init; } = "Axia.VehicleApi";
    public string Key { get; init; } = string.Empty;
    public int ExpiresMinutes { get; init; } = 60;
}
