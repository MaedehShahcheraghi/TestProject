using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Application.Dtos.ProductDtos;
using TP.Application.Features.Products.Requests.Queries;

namespace TP.Application.Features.Products.Handlers.Queries
{
    public class GetAllProductWithFilterRequestHandler : IRequestHandler<GetAllProductWithFilterRequest, IReadOnlyList<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductWithFilterRequestHandler(IProductRepository productRepository,IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ProductDto>> Handle(GetAllProductWithFilterRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductsByOwnerId(request.CreateBy);
            var mapresult=_mapper.Map<IReadOnlyList<ProductDto>>(result);
            return mapresult;
        }
    }
}
