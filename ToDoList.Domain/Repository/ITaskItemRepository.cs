using ProvaToDoList.ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repository;

public interface ITaskItemRepository
{
    TaskItem Create(TaskItem item);
    TaskItem Update(TaskItem item);
    void Delete(TaskItem item);
    TaskItem? GetById(Guid id);
    List<TaskItem> GetAll();
}
