using Domain.Actors;
using Domain.Directors;
using Domain.Movies;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Actor> Actors { get; }
    DbSet<Director> Directors { get; }
    DbSet<Movie> Movies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
