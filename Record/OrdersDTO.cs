using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrdersDTOGetById(int Sum, DateOnly Date,string UserFirstName);
    public record OrdersDTOPost(int Sum, DateOnly Date, string UserFirstName);
}
