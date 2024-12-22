using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTO
{
    public record OrderDTO(int Id,DateOnly Date,string UserFirstName, int? Sum);
    public record OrderDTOPost(int UserId,DateOnly Date,List<OrderItemDTO> OrderItems);
}
