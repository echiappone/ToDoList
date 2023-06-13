namespace ProvaToDoList.ToDoList.Domain.Entities;

public class TaskItem
{
    public TaskItem(string title)
    {
        Id = Guid.NewGuid();
        Title = title;
        Done = false;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool Done { get; private set; }

    public void UpdateTitle(string title) => Title = title;
    public void UpdateDone(bool done) => Done = done;

    public bool IsValid()
    {
        return Title != null && Title.Length <= 100;
    }
}