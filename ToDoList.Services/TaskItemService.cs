using ProvaToDoList.ToDoList.Domain.Entities;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Services;
using ToDoList.Domain.Repository;

namespace ToDoList.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _repository;

        public TaskItemService(ITaskItemRepository repository)
        {
            _repository = repository;
        }

        public Result<TaskItem> Create(TaskItemDTO item)
        {
            var itemCreate = new TaskItem(item.Title);
            if (!itemCreate.IsValid())
                return new Result<TaskItem>("Item inválido, verifique os dados e tente novamente");

            var created = _repository.Create(itemCreate);
            return new Result<TaskItem>(created);
        }

        public Result<bool> Delete(Guid id)
        {
            var itemToRemove = _repository.GetById(id);
            if (itemToRemove == null)
                return new Result<bool>("Item não encontrado");

            _repository.Delete(itemToRemove);

            return new Result<bool>(true);
        }

        public Result<List<TaskItem>> GetAll()
        {
            var list = _repository.GetAll();

            return new Result<List<TaskItem>>(list);
        }

        public Result<TaskItem> GetById(Guid id)
        {
            var item = _repository.GetById(id);

            return new Result<TaskItem>(item);
        }

        public Result<TaskItem> Update(TaskItemDTO item)
        {
            var itemUpdate = _repository.GetById(item.Id);
            if (item == null)
                return new Result<TaskItem>("Item não encontrado");

            itemUpdate.UpdateTitle(item.Title);
            itemUpdate.UpdateDone(item.Done);

            if (!itemUpdate.IsValid())
                return new Result<TaskItem>("Item inválido, verifique os dados e tente novamente");

            var updated = _repository.Update(itemUpdate);

            return new Result<TaskItem>(updated);
        }
    }
}
