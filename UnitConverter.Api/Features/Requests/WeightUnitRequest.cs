using MediatR;
using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Requests;

public class WeightUnitRequest : IRequest<UnitModel>
{
    public static readonly WeightUnitRequest Instance = new(); }