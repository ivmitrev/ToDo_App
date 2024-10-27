using System.ComponentModel.DataAnnotations;
using TodoAppApi.Entities;

namespace Models.Dtos;

public class ToDoItemDto
{
    public int Id { get; set; }
    [Required]
    [MinLength(1,ErrorMessage = "Title must be atleast 1 character")]
    [MaxLength(280,ErrorMessage = "Title cannot be over 280 charaters")]
    public string Text { get; set; }
    [DateInTheFuture]
    public DateOnly? Deadline { get; set; }
    [Required]
    public bool Completed { get; set; }
}