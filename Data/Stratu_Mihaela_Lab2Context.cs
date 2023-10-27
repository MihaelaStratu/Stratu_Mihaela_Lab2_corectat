using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stratu_Mihaela_Lab2.Models;

namespace Stratu_Mihaela_Lab2.Data
{
    public class Stratu_Mihaela_Lab2Context : DbContext
    {
        public Stratu_Mihaela_Lab2Context (DbContextOptions<Stratu_Mihaela_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Stratu_Mihaela_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Stratu_Mihaela_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Stratu_Mihaela_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Stratu_Mihaela_Lab2.Models.Category>? Category { get; set; }
    }
}
