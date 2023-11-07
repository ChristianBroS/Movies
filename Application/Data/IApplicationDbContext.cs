using Domain.Actors;
using Domain.Directors;
using Domain.Movies;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Actor> Actors { get; set; }
    DbSet<Director> Directors { get; set; }
    DbSet<Movie> Movies { get; set; }
}
