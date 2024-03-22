using Domain.Common;
using Domain.Enums;

namespace Domain.Actors;

public class Actor : BaseAuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }

    public Actor(string name,
        DateTime birthDate,
        Gender gender)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
    }

    public Actor() { }
}
