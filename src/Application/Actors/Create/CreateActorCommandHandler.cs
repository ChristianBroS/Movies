using Application.Data;
using Domain.Actors;
using Domain.Shared;

namespace Application.Actors.Create;

internal sealed class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Result<Actor>>
{
    private readonly IActorRepository _actorRepository;
    private readonly IApplicationDbContext _context;

    public CreateActorCommandHandler(IActorRepository actorRepository,
        IApplicationDbContext context)
    {
        _actorRepository = actorRepository;
        _context = context;
    }

    public async Task<Result<Actor>> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = new Actor(request.Name,
            request.BirthDate,
            request.Gender);

        _actorRepository.InsertActor(actor);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Ok(actor);
    }
}
