using Domain.Actors;
using Domain.Enums;
using Domain.Shared;
using MediatR;

namespace Application.Actors.Create;

public sealed record CreateActorCommand(string Name, DateTime BirthDate, Gender Gender) : IRequest<Result<Actor>>;