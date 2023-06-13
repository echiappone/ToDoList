using Microsoft.EntityFrameworkCore;
using ProvaToDoList.ToDoList.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Repository.Config
{
    public class TaskItemMapping : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Done);
        }
    }
}
