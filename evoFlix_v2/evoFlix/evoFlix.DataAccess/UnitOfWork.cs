using evoFlix.Models.Content;
using evoFlix.Models.Users;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.DataAccess
{
    public class UnitOfWork: DbContext
    {
        public DbSet<MainUserTableModel> MainUsers { get; set; }

        public DbSet<UserTableModel> Users { get; set; }

        public DbSet<FilmTableModel> Films { get; set; }

        //public DbSet<WatchListTableModel> WatchLists { get; set; }

        //public DbSet<ContinuationTableModel> Watching { get; set; }

        public DbSet<FilmSourceTableModel> FilmSourceTable { get; set; }

        public UnitOfWork() : base("EvoFlixDBConnectionString") { }
    }
}
