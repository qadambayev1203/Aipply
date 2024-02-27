using Entities.Model.UsersModel;
using Entities.Model.UserTypesModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Configuration;
using Entities.Model.AppealsModel;
using Entities.Model.StatusesModel;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.Entity<User>()
                .HasIndex(u => u.login)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
               
        public DbSet<UserType> users_types_20ai24ppy { get; set; }
        public DbSet<User> user_20ai24ppy { get; set; }
        public DbSet<Appeal> appeals_20ai24ppy { get; set; }
        public DbSet<Status> statuses_20ai24ppy { get; set; }

        

    }
}
