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
        public DbSet <UserDB> Users { get; set; }

        public DbSet <Film> Films { get; set; }

        public UnitOfWork() : base("EvoFlixDBConnectionString") { }
            
        
    }


}
