using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Dtos.ProductDtos;
using TP.Application.Features.Products.Handlers.Queries;

namespace TP.Application.Features.Products.Requests.Queries
{
    public class GetAllProductWithFilterRequest:IRequest<RequestResponse<IReadOnlyList<ProductDto>>>
    {
        public string CreateBy { get; set; }
    }
}
