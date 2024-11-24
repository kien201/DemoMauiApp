using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.Models
{
    public class DocumentDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }

        public DocumentDbContext()
        {
            //SQLitePCL.Batteries_V2.Init();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "documentapp.db");
            //if (File.Exists(dbPath)) File.Delete(dbPath);
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
