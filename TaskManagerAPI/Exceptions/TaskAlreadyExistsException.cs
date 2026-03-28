namespace TaskManagerAPI.Exceptions
{
    public class TaskAlreadyExistsException : Exception
    {
        public TaskAlreadyExistsException(string message) : base(message) { }
    }
}
