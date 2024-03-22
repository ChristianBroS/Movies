using Domain.Enums;
using Domain.Shared;
using MediatR;

namespace Application.Actors.Get;

public sealed record GetActorQuery(int ActorId) : IRequest<Result<ActorResponse>>;

public record ActorResponse(
    int Id,
    string Name,
    DateTime BirthDate,
    Gender Gender);
