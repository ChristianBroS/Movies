namespace Domain.Actors;

public interface IActorRepository
{
    void InsertActor(Actor actor);
    void DeleteActor(Actor actor);
    Task<Actor?> GetActorByIdAync(int actorId);
    IEnumerable<Actor> GetActors();
}
