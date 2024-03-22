using Domain.Actors;
using Domain.Common;
using Domain.Directors;
using Domain.Enums;

namespace Domain.Movies;

public class Movie : BaseAuditableEntity
{
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int PlayTime { get; private set; }
    public List<Actor>? Actors { get; private set; }
    public List<Director>? Directors { get; private set; }
    public List<Genre>? Genres { get; private set; }

    public Movie(int id,
        string title,
        string description,
        int playTime,
        List<Actor>? actors,
        List<Director>? directors,
        List<Genre>? genres)
    {
        Id = id;
        Title = title;
        Description = description;
        PlayTime = playTime;
        Actors = actors;
        Directors = directors;
        Genres = genres;
    }

    public Movie() { }
}
