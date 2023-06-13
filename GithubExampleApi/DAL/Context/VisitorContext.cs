using GithubExampleApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GithubExampleApi.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite(@"Data Source=database.db");

        public DbSet<Visitor> Visitors { get; set; }
    }
}
