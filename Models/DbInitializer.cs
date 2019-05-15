using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Encryption.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            int offset = 5;
            for (char c = 'А'; c <= 'Я'; c++)
            {
                db.Replaces.Add(new Replace { OldSymbol = c.ToString(), NewSymbol = (char)(c + offset) <= 'Я' ? ((char)(c + offset)).ToString() : ((char)('А' + (char)(c + offset) - 'Я' - 1)).ToString() });
            }
            for (char c = 'а'; c <= 'я'; c++)
            {
                db.Replaces.Add(new Replace { OldSymbol = c.ToString(), NewSymbol = (char)(c + offset) <= 'я' ? ((char)(c + offset)).ToString() : ((char)('а' + (char)(c + offset) - 'я' - 1)).ToString() });
            }
            base.Seed(db);
        }
    }
}