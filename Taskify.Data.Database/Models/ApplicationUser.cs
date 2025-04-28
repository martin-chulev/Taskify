using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Taskify.Data.Database.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;
}
