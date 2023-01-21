using Microsoft.EntityFrameworkCore;
using RadicalTherapy.Data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CustomerVideo> CustomerVideos { get; set; }
        public DbSet<RadicalTherapy.Data.model.Data> Data { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<RadicalReserve> RadicalReserves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=radical3_;Integrated Security=true;");
        }
    }
}

