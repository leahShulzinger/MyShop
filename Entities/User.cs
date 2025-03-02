using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int Id { get; set; }
    [EmailAddress, Required]
    public string Email { get; set; } = null!;
    [StringLength(20, ErrorMessage = "FirstName can be between 4 till 8 chars", MinimumLength = 4)]
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
