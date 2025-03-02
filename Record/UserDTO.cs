using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public record GetByIdUserDTO(int Id,string Email,string? FirstName,string? LastName);
   public record UserDTO([EmailAddress, Required] string Email, [StringLength(20, ErrorMessage = "firstName Can be between 4 till 8 chars", MinimumLength = 4)] string? FirstName, string? LastName,string Password);

}
