namespace Assignment_5_1.Models
{
    public class NewTaskModel
    {
        public Guid Id { get; }
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }

        public NewTaskModel(string title, bool isCompleted)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = isCompleted;
        }
    }
}