using Application.Abstractions.Mappings;
using Domain.Actors;
using Domain.Shared;
using MediatR;

namespace Application.Actors.Get;

internal sealed class GetActorQueryHandler : IRequestHandler<GetActorQuery, Result<ActorResponse>>
{
    private readonly IActorRepository _actorRepository;

    public GetActorQueryHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public async Task<Result<ActorResponse>> Handle(GetActorQuery request, CancellationToken cancellationToken)
    {
        var actor = await _actorRepository.GetActorByIdAync(request.ActorId);

        if (actor is null)
        {
            var error = new ActorNotFoundException(request.ActorId);
            return Result.Fail<ActorResponse>(error.Message);
        }

        var actorResponse = ActorMapper.MapActorToActorResponse(actor);

        return Result.Ok(actorResponse);
    }
}
