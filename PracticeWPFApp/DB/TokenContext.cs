using Microsoft.EntityFrameworkCore;
using PracticeWPFApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWPFApp.DB
{
    public class TokenContext: DbContext
    {
        public DbSet<Tokens> Tokens { get; set; } = default!;
        public TokenContext() => Database.EnsureCreated();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Tokens.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {path}");
        }
    }
}
