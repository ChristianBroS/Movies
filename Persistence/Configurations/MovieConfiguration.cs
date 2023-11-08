using Domain.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Actors)
            .WithOne()
            .HasForeignKey(x => x.Id);

        builder.HasMany(x => x.Directors)
            .WithOne()
            .HasForeignKey(x => x.Id);
    }
}
