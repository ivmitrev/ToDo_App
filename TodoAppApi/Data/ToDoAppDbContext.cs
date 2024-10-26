using Microsoft.EntityFrameworkCore;
using TodoAppApi.Entities;

namespace TodoAppApi.Data;

public class ToDoAppDbContext : DbContext
{
    public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options)
    {
        
    }

    public DbSet<ToDoItem> items { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}