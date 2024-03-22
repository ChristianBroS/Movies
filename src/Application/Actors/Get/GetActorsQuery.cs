using Domain.Shared;
using MediatR;

namespace Application.Actors.Get;

public sealed record GetActorsQuery : IRequest<Result<List<ActorResponse>>>
{
    public string? SearchTerm { get; init; }
}
