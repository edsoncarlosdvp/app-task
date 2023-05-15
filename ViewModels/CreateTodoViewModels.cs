using System.ComponentModel.DataAnnotations;

namespace AppTask.ViewModels
{
    public class CreateTodoViewModels
    {
        [Required]
        public string Name { get; set; }
    }
}
