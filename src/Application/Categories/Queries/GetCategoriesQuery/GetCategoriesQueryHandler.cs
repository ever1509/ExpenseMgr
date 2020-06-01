using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.Queries.GetCategoriesQuery
{
    public class GetCategoriesQueryHandler:IRequestHandler<GetCategoriesQuery,CategoriesListViewModel>
    {
        private readonly IExpenseContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IExpenseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CategoriesListViewModel> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return  new CategoriesListViewModel()
            {
                Categories = categories
            };
        }
    }
}
