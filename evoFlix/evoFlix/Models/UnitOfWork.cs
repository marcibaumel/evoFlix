using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    public class UnitOfWork : DbContext
    {
        public DbSet<FilmModel> Films { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SourceModel> Sources { get; set; }
        public DbSet<SubtitleModel> Subtitles { get; set; }
        public DbSet<WatchModel> Watches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EvoFlixDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
