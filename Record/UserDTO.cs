using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record UserDTOGet(int Id, string? FirstName, string? LastName, string Email);
    public record UserDTO(string? FirstName, string? LastName, string Email,string PassWord);

}
