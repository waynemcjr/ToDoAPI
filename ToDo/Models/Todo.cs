namespace ToDo.API.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public Todo(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = false;
        }
    }
}
