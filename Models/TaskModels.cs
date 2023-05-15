using System;

namespace AppTask.Models
{
    public class TaskModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
