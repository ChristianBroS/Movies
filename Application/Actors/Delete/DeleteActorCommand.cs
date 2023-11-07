using MediatR;

namespace Application.Actors.Delete;

public sealed record DeleteActorCommand(int ActorId) : IRequest;
