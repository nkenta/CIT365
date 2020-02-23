using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public string SortByBook { get; set; }
        public string SortByDate { get; set; }
        public string SearchBook { get; set; }
        public string SearchNote { get; set; }
        public string SortItems { get; set; }

        public IList<JournalEntry> JournalEntry { get;set; }
        public async Task OnGetAsync(string sortOrder, string searchBook, string filterBooks, string searchNote, string filterNotes, int? currentPage)
        {
            SortItems = sortOrder;
            SortByBook = String.IsNullOrEmpty(sortOrder) ? "book_asc" : "";
            SortByDate = sortOrder == "dateAdded" ? "dateAdded_asc" : "dateAdded";

            if (searchBook != null || searchNote != null)
            {
                currentPage = 1;
            }
            else
            {
                searchBook = filterBooks;
                searchNote = filterNotes;
            }

            SearchBook = searchBook;
            SearchNote = searchNote;

            var journalEntries = from m in _context.JournalEntry select m;
            if (!string.IsNullOrEmpty(searchBook))
            {
                journalEntries = journalEntries.Where(s => s.Book.Contains(searchBook));
            }
            if (!string.IsNullOrEmpty(searchNote))
            {
                journalEntries = journalEntries.Where(s => s.ImpressionNote.Contains(searchNote));
            }

            journalEntries = sortOrder switch
            {
                "book_desc" => journalEntries.OrderByDescending(s => s.Book),
                "dateAdded" => journalEntries.OrderBy(s => s.DateAdded),
                "dateAdded_desc" => journalEntries.OrderByDescending(s => s.DateAdded),
                _ => journalEntries.OrderBy(s => s.Book),
            };
            JournalEntry = await journalEntries.ToListAsync();
        }
    }
}
