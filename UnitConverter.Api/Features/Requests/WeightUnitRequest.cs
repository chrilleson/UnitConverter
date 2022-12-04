using MediatR;
using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Requests;

public record WeightUnitRequest : IRequest<IEnumerable<UnitModel>>
{
    public static readonly WeightUnitRequest Instance = new();
}