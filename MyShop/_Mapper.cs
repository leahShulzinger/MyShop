using AutoMapper;
using Entities;
using DTO;
namespace MyShop
{
    public class _Mapper:Profile
    {
        public _Mapper()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTOPost,Order>();
            CreateMap<OrderItemDTO, OrderItem> ();
            CreateMap<User, GetByIdUserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
