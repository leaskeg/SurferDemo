using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurferDemo.Models;

namespace SurferDemo.Data
{
    public class SurferDemoContext : DbContext
    {
        public SurferDemoContext (DbContextOptions<SurferDemoContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Board { get; set; } = default!;

        public DbSet<Image> Image { get; set; } 
    }
}
