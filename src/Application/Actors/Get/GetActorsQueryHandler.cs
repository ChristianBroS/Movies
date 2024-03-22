using Application.Abstractions.Mappings;
using Domain.Actors;
using Domain.Shared;

namespace Application.Actors.Get;

internal sealed class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, Result<List<ActorResponse>>>
{
    private readonly IActorRepository _actorRepository;

    public GetActorsQueryHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public async Task<Result<List<ActorResponse>>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
    {
        var actors = _actorRepository.GetActors();

        var actorResponse = ActorMapper.MapActorsToActorResponse(actors);

        return Result.Ok(actorResponse);
    }
}