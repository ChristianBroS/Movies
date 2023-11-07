using FluentValidation;

namespace Application.Actors.Get;

internal class GetActorQueryValidator : AbstractValidator<GetActorQuery>
{
    public GetActorQueryValidator()
    {
        RuleFor(x => x.ActorId).NotEmpty().WithMessage("ActorId is required.");
    }
}
