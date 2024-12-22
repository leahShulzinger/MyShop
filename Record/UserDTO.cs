using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public record GetByIdUserDTO(int Id,string Email,string? FirstName,string? LastName);
   public record UserDTO(string Email, string? FirstName, string? LastName,string Password);

}
