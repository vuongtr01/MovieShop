using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;

namespace MovieShop.Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<MovieGenres> MovieGenres { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("nvarchar(24)");
        });
        modelBuilder.Entity<Cast>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("nvarchar(128)");
            entity.Property(e => e.ProfilePath).HasColumnType("nvarchar(2048)");
        });
        modelBuilder.Entity<MovieCasts>(entity =>
        {
            entity.Property(e => e.Character).HasColumnType("nvarchar(450)");
        });
        modelBuilder.Entity<Trailer>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("nvarchar(2048)");
            entity.Property(e => e.TrailerUrl).HasColumnType("nvarchar(2048)");
        });
        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
        });
        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(5, 2)");
        });
        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasColumnType("nvarchar(20)");
        });
        
        modelBuilder.Entity<Favorite>()
            .HasKey(f => new { f.MovieId, f.UserId });

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Movie)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.MovieId);

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId);
        
        modelBuilder.Entity<Purchase>()
            .HasKey(p => new { p.MovieId, p.UserId });

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Movie)
            .WithMany(m => m.Purchases)
            .HasForeignKey(p => p.MovieId);

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Review>()
            .HasKey(r => new { r.MovieId, r.UserId });

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
        
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Casts)
            .WithMany(c => c.Movies)
            .UsingEntity<MovieCasts>();
        
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity<MovieGenres>();
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRole>();
    }
}