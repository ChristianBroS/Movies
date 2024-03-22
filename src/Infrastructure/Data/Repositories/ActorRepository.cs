using Domain.Actors;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class ActorRepository : IActorRepository
{
    private readonly ApplicationDbContext _context;

    public ActorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void InsertActor(Actor actor)
    {
        _context.Actors.Add(actor);
    }

    public IEnumerable<Actor> GetActors()
    {
        return _context.Actors
            .AsNoTracking()
            .ToList();
    }

    public Task<Actor?> GetActorByIdAync(int actorId)
    {
        return _context.Actors
            .SingleOrDefaultAsync(x => x.Id == actorId);
    }

    public void DeleteActor(Actor actor)
    {
        _context.Actors.Remove(actor);
    }
}
