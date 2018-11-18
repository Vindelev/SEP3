using Microsoft.EntityFrameworkCore;
using System;

public class MotherloadContext : DbContext{

    public DbSet<Person> People {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("host=localhost;database=Motherload;user id=postgres");
}