using System;
using System.Collections.Generic;
using System.Text;
using Application.Categories.Queries.GetCategoriesQuery;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class CustomProfile:Profile
    {
        public CustomProfile(S3Settings s3Settings)
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(d => d.Id, opt => opt.MapFrom(e => e.CategoryId))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(e => $"{s3Settings.ImgBaseUrl}{e.CategoryId}/{e.ImageName}"));
        }
    }
}
