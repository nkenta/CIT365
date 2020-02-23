using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class JournalEntry
    {
        public int ID { get; set; }
        [Display(Name = "Scripture")]
        [DataType(DataType.Text)]
        public string FavoriteScripture { get; set; }

        [Display(Name = "Impression Note")]
        [DataType(DataType.Text)]
        public string ImpressionNote { get; set; }

        [Display(Name = "Book")]
        [DataType(DataType.Text)]
        public string Book { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
