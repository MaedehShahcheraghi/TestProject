using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Dtos.ProductDtos;

namespace TP.Application.Features.Products.Requests.Queries
{
    public class GetAllProductRequest:IRequest<IReadOnlyList<ProductDto>>
    {
    }
}
