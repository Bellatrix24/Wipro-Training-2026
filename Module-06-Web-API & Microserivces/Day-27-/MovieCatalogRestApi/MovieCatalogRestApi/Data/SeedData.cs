using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieCatalogRestApi.Models;

namespace MovieCatalogRestApi.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (await context.Directors.AnyAsync() || await context.Movies.AnyAsync())
            {
                return; // Database already seeded
            }

            var directors = new[]
            {
                new Director { Name = "Christopher Nolan", Bio = "Acclaimed director known for cerebral, nonlinear storytelling." },
                new Director { Name = "Steven Spielberg", Bio = "One of the most influential directors in cinema history." },
                new Director { Name = "Quentin Tarantino", Bio = "Known for stylized violence, sharp dialogue, and pop culture references." }
            };

            context.Directors.AddRange(directors);
            await context.SaveChangesAsync();

            context.Movies.AddRange(
                new Movie { Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, DirectorId = directors[0].Id },
                new Movie { Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, DirectorId = directors[0].Id },
                new Movie { Title = "Jurassic Park", Genre = "Adventure", ReleaseYear = 1993, DirectorId = directors[1].Id },
                new Movie { Title = "Pulp Fiction", Genre = "Crime", ReleaseYear = 1994, DirectorId = directors[2].Id }
            );

            await context.SaveChangesAsync();
        }
    }
}
