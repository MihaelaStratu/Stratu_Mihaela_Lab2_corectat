using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stratu_Mihaela_Lab2.Data;
using Stratu_Mihaela_Lab2.Models;
using Stratu_Mihaela_Lab2.Models.ViewModels;

namespace Stratu_Mihaela_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Stratu_Mihaela_Lab2.Data.Stratu_Mihaela_Lab2Context _context;

        public IndexModel(Stratu_Mihaela_Lab2.Data.Stratu_Mihaela_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoriesData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoriesData(); CategoryData.Publishers = await _context.Category.Include(i => i.BookCategories).ThenInclude(c => c.Book.Authors).OrderBy(i => i.CategoryName).ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Publishers.Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(bc => bc.Book).ToList();
            }
        }
    }
}
