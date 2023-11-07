using Application.Data;
using Domain.Actors;
using Domain.Shared;
using MediatR;

namespace Application.Actors.Create;

internal sealed class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Result<Actor>>
{
    private readonly IActorRepository _actorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateActorCommandHandler(IActorRepository actorRepository,
        IUnitOfWork unitOfWork)
    {
        _actorRepository = actorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Actor>> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = new Actor(request.Name,
            request.BirthDate,
            request.Gender);

        _actorRepository.InsertActor(actor);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(actor);
    }
}
