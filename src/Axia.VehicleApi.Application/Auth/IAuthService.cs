using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Domain.Entities;

namespace Axia.VehicleApi.Application.Auth;

public interface IAuthService
{
    AuthResultDto GenerateToken(Usuario usuario);
}
