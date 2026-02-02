using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Auth;

public sealed record LoginCommand(
    string Login,
    string Senha
) : IRequest<AuthResultDto>;
