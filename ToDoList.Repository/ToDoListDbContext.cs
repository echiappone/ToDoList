using ToDoList.Repository.Config;
using Microsoft.EntityFrameworkCore;
using ProvaToDoList.ToDoList.Domain.Entities;

namespace ToDoList.Repository;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions opt) : base(opt)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskItemMapping());
    }

    public DbSet<TaskItem> TaskItems { get; set; }
}