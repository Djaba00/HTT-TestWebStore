﻿using AutoMapper;
using TestWebStore.Models.Entities;
using TestWebStore.Models.ViewModels;

namespace TestWebStore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(p => p.Category.Name));

            CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.Products, opt => opt.MapFrom(c => c.Products.Select(p => p.Name)));
        }
    }
}
