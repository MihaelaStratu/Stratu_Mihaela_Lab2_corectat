using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stratu_Mihaela_Lab2.Data;
using Stratu_Mihaela_Lab2.Models;

namespace Stratu_Mihaela_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Stratu_Mihaela_Lab2.Data.Stratu_Mihaela_Lab2Context _context;

        public IndexModel(Stratu_Mihaela_Lab2.Data.Stratu_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b => b.Publisher).Include(b => b.Authors)
                    .ToListAsync();
            }
        }
    }
}
