using Application.Actors.Get;
using Domain.Actors;

namespace Application.Abstractions.Mappings;

public static class ActorMapper
{
    public static ActorResponse MapActorToActorResponse(Actor actor)
    {
        return new ActorResponse(
            actor.Id,
            actor.Name,
            actor.BirthDate,
            actor.Gender);
    }

    public static List<ActorResponse> MapActorsToActorResponse(IEnumerable<Actor> actors)
    {
        List<ActorResponse> actorResponse = new();

        foreach (Actor actor in actors)
        {
            actorResponse.Add(MapActorToActorResponse(actor));
        }

        return actorResponse;
    }
}
