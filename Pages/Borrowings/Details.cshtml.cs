﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stratu_Mihaela_Lab2.Data;
using Stratu_Mihaela_Lab2.Models;

namespace Stratu_Mihaela_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Stratu_Mihaela_Lab2.Data.Stratu_Mihaela_Lab2Context _context;

        public DetailsModel(Stratu_Mihaela_Lab2.Data.Stratu_Mihaela_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}