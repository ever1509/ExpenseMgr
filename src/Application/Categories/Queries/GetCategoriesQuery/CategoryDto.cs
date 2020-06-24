using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Categories.Queries.GetCategoriesQuery
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
