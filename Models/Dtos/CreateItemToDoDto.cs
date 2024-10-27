using System.ComponentModel.DataAnnotations;
using TodoAppApi.Entities;

namespace Models.Dtos;

public class CreateItemToDoDto
{
    [Required(ErrorMessage = "Text is required")]
    [MinLength(1, ErrorMessage = "Text should be at least 1 character")]
    [MaxLength(280, ErrorMessage = "Text should be less than 280 characters")]
    [RegularExpression(@"^(?!\d+$).+", ErrorMessage = "Text should not be only numbers")]
    public string Text { get; set; }
    [Required(ErrorMessage = "Deadline is required")]
    [DateInTheFuture]
    public DateOnly? Deadline { get; set; }
}