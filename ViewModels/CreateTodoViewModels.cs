using System.ComponentModel.DataAnnotations;

namespace AppTask.ViewModels
{
    public class CreateTodoViewModels
    {
        [Required]
        public string Title { get; set; }
    }
}
