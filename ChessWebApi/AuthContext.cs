using ChessWebApi.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;

namespace ChessWebApi
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public virtual DbSet<Application> Aplications { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // email address doesn't need to be in unicode, check it spec
            modelBuilder.Entity<IdentityUser>().Property(u => u.UserName).IsUnicode(false).HasMaxLength(150);
            modelBuilder.Entity<IdentityUser>().Property(u => u.Email).IsUnicode(false);
            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(150);
        }
    }
}
