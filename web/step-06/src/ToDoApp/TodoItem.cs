namespace ToDoApp;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool IsDone { get; set; }

    public bool IsEdit { get; set; } = false;
}

