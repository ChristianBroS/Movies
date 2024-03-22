using Application.Data;
using Domain.Actors;

namespace Application.Actors.Delete;

internal sealed class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly IActorRepository _actorRepository;
    private readonly IApplicationDbContext _context;

    public DeleteActorCommandHandler(IActorRepository actorRepository,
        IApplicationDbContext context)
    {
        _actorRepository = actorRepository;
        _context = context;
    }

    public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        var actor = await _actorRepository.GetActorByIdAync(request.ActorId);

        if (actor is null)
        {
            var error = new ActorNotFoundException(request.ActorId);
            //return Result.Fail<Actor>(error);
            throw error;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
