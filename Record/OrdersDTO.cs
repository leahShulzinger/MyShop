using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrdersDTO(int Id, DateOnly Date,string UserFirstName, int Sum);
    public record OrdersDTOPost(int UserId,List<OrderItemsDTOPost> OrderItems,DateOnly Date);
}
