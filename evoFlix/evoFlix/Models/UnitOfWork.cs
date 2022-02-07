using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DevConnection"));
        }
    }
}
