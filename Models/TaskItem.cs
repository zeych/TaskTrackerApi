using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название задачи обязательно")]
        [MinLength(3, ErrorMessage = "Название должно быть не короче 3 символов")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "ToDo"; // ToDo, InProgress, Done

        // Допустимые значения: Low, Medium, High
        [Required]
        [StringLength(20)]
        public string Priority { get; set; } = "Medium";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
