using FluentValidation;

namespace Application.Actors.Create;

internal class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
{
    public CreateActorCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now).WithMessage("BirthDate must be less than or equal to now.");

        RuleFor(x => x.Gender).IsInEnum().WithMessage("Gender must be a specified enum value");
    }
}
