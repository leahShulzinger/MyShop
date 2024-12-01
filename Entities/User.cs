using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }
    [EmailAddress, Required]
    public string Email { get; set; } = null!;
    [StringLength(20, ErrorMessage = "firstName Can be between 4 till 8 chars", MinimumLength = 4)]
    public string? FirstName { get; set; }
    [StringLength(20, ErrorMessage = "lastName Can be between 4 till 8 chars", MinimumLength = 4)]
    public string? LastName { get; set; }
    [StringLength(20, ErrorMessage = "password Can be between 4 till 20 chars", MinimumLength = 4), Required]
    public string Password { get; set; } = null!;
}
