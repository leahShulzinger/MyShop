﻿using AutoMapper;
using DTO;
using Entities;

namespace MyShop
{
    public class _Mapper:Profile
    {
        public _Mapper()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrdersDTOGetById>();
        }
    }

    
}