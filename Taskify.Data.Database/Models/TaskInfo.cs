using System.ComponentModel.DataAnnotations;
using Taskify.Data.Database.Models.Base;

namespace Taskify.Data.Database.Models;

public class TaskInfo : ModelBase
{
    //public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Title { get; set; } = default!;

    public string? Description { get; set; }
    
    //public DateTimeOffset CreatedAt { get; set; }
    //public DateTimeOffset UpdatedAt { get; set; }
    //public DateTimeOffset? DeletedAt { get; set; }
}