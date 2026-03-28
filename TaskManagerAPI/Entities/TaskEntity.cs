namespace TaskManagerAPI.Entities
{
    public class TaskEntity
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Instant { get; set; }
    }
}
