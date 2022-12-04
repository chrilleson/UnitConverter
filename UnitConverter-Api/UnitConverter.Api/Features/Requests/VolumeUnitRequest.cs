using MediatR;
using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Requests;

public record VolumeUnitRequest : IRequest<IEnumerable<UnitModel>>
{
    public static readonly VolumeUnitRequest Instance = new();
}