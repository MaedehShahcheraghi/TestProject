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
    public class GetAllProductWithFilterRequestHandler : IRequestHandler<GetAllProductWithFilterRequest, RequestResponse<IReadOnlyList<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllProductWithFilterRequestHandler(IProductRepository productRepository,IUserRepository userRepository,IMapper mapper) {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<RequestResponse<IReadOnlyList<ProductDto>>> Handle(GetAllProductWithFilterRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.CreateBy))
            {
                var response = new RequestResponse<IReadOnlyList<ProductDto>>();
                var myresult=await _userRepository.GetAsync(request.CreateBy);
                if (myresult == null)
                {
                    response.StatusCode = "404";

                }
                else {
                
                   response.StatusCode="200";  
                    var result = await _productRepository.GetProductsByOwnerId(request.CreateBy);
                    var mapresult=_mapper.Map<IReadOnlyList<ProductDto>>(result);
                }
                
                return response;
            }

            throw new BadRequestException("bad request");       
        }
    }

    public class RequestResponse<T> 
    {
        public string StatusCode { get; set; }
        public T data { get; set; }
    }
}
