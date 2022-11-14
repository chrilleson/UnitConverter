using MediatR;
using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Requests;

public class VolumeUnitRequest : IRequest<UnitModel>
{
    public static readonly VolumeUnitRequest Instance = new();
}