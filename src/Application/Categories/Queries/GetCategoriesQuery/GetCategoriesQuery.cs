using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Categories.Queries.GetCategoriesQuery
{
    public class GetCategoriesQuery:IRequest<CategoriesListViewModel>
    {
    }
}
