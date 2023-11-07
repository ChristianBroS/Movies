using Application.Data;
using Domain.Actors;
using Domain.Shared;
using MediatR;

namespace Application.Actors.Delete;

internal sealed class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly IActorRepository _actorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteActorCommandHandler(IActorRepository actorRepository,
        IUnitOfWork unitOfWork)
    {
        _actorRepository = actorRepository;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
