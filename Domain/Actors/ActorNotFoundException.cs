namespace Domain.Actors;

public sealed class ActorNotFoundException : Exception
{
    public ActorNotFoundException(int actorId) 
        : base($"The actor with the ID = {actorId} was not found") 
    { 
    }
}
