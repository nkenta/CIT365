using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any Scriptures.
                if (context.JournalEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.JournalEntry.AddRange(

                     new JournalEntry
                     {
                         FavoriteScripture = "Isaiah 1:18",
                         ImpressionNote = "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool.",
                         Book = "Holy Bible",
                         DateAdded = DateTime.Parse("2002-4-5"),
                     },

                     new JournalEntry
                     {
                         FavoriteScripture = "Moses 1:39",
                         ImpressionNote = "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man.",
                         Book = "Pearl of Great Price",
                         DateAdded = DateTime.Parse("2005-6-12"),
                     },

                     new JournalEntry
                     {
                         FavoriteScripture = "2 Nephi 2:25",
                         ImpressionNote = " Adam fell that men might be; and men are, that they might have joy.",
                         Book = "The Book of Mormon",
                         DateAdded = DateTime.Parse("2012-7-11"),
                     },

                     new JournalEntry
                     {
                         FavoriteScripture = "Doctrine and Covenants 6:36",
                         ImpressionNote = "Look unto me in every thought; doubt not, fear not.",
                         Book = "Doctrine and Covenants",
                         DateAdded = DateTime.Parse("2018-8-8"),
                     }

                    );
                context.SaveChanges();
            }
        }
    }
}
