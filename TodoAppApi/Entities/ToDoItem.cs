using System.ComponentModel.DataAnnotations;

namespace TodoAppApi.Entities;

public class ToDoItem
{
    public int Id { get; set; }
    [Required]
    [MinLength(1,ErrorMessage = "Title must be at least 1 character")]
    [MaxLength(280,ErrorMessage = "Title cannot be over 280 charaters")]
    public string Text { get; set; }
    [DateInTheFuture]
    public DateOnly? Deadline { get; set; }
    public bool Completed { get; set; }
}