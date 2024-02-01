namespace Todolist.Models
{
    public class TaskModels
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string StartDate { get; set; }
        public string Deadline { get; set; }
        public string Status { get; set; }
    }
}