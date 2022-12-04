using MediatR;
using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Requests;

public record LengthUnitRequest : IRequest<IEnumerable<UnitModel>>
{
    public static readonly LengthUnitRequest Instance = new();
}