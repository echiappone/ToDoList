using ProvaToDoList.ToDoList.Domain.Entities;
using ToDoList.Domain.DTO;

namespace ToDoList.Domain.Services;

public interface ITaskItemService
{
    Result<List<TaskItem>> GetAll();
    Result<TaskItem> GetById(Guid Id);
    Result<TaskItem> Create(TaskItemDTO item);
    Result<TaskItem> Update(TaskItemDTO item);
    Result<bool> Delete(Guid id);
}
