using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashcardsAPI.Models;
public class FlashContext : DbContext
{
    public FlashContext(DbContextOptions<FlashContext> options) : base(options)
    { }

    public DbSet<Card> Flashcards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(x => x.Id).HasName("PRIMARY"); 
            entity.ToTable("flashcards", "dbo"); 
        });
    }
}
