using Microsoft.EntityFrameworkCore;
using System;

public class MotherloadContext : DbContext{

    public DbSet<User> Users { get; set;}
    public DbSet<Ride> Rides { get; set;}

    public DbSet<Seat> Seats { get; set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("host=localhost;database=Motherload;user id=postgres");
}