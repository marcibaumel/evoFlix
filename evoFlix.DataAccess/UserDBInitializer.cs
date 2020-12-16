using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.DataAccess
{
    public class UserDBInitializer : DropCreateDatabaseAlways<DbContext>
    {
        protected override void Seed(DbContext context)
        {
            IList<UserDB> defaultStandards = new List<UserDB>();

            defaultStandards.Add(new UserDB() { Username = "Pista" });
            defaultStandards.Add(new UserDB() {Username = "Pista2" });

            /*
             * Ezt nem nagyon értem miért rossz :/.
             * Ez alapján csináltam:
             * https://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx
             * 
             */

            //context.UserDB.AddRange(defaultStandards);

            base.Seed(context);
        }

    }
}
