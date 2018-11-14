using Microsoft.EntityFrameworkCore;
using Database.Data.Entities;

namespace Database.Data
{
    public class SEP3Context : DbContext
    {

        public SEP3Context(DbContextOptions<SEP3Context> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=SEP3;Username=postgres;Password=admin");

    }
}