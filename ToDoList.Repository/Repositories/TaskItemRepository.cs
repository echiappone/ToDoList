using ToDoList.Domain.Repository;
using ProvaToDoList.ToDoList.Domain.Entities;

namespace ToDoList.Repository.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ToDoListDbContext _context;

        public TaskItemRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public TaskItem Create(TaskItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(TaskItem item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public TaskItem? GetById(Guid id)
        {
            return _context.TaskItems.FirstOrDefault(x => x.Id == id);
        }

        public List<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }

        public TaskItem Update(TaskItem item)
        {
            _context.Update(item);
            _context.SaveChanges();
            return item;
        }
    }
}
