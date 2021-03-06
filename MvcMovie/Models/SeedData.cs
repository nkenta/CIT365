﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("1989-2-12"),
                         Genre = "Adventure, Biography, Drama",
                         Price = 7.99M
                     },

                    new Movie
                    {
                        Title = "The Book of Mormon",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Biography, History, Drama",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "My Best Two Years",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy, Drama",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "17 Miracles",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Adventure, History",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}