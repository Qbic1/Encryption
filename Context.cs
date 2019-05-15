using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Encryption.Models
{
    public class Context : DbContext
    { 
        public Context() : base("DbConnection")
        { }

        public DbSet<Replace> Replaces { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}