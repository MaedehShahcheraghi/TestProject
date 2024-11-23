using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Application.Dtos.ProductDtos.ProductValidation;
using TP.Application.Features.Products.Requests.Commands;
using TP.Application.Responses;

namespace TP.Application.Features.Products.Handlers.Commands
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteProductRequestHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
          
            var productdb = await _productRepository.GetAsync(request.ProductId);
            if (productdb != null && productdb.CreatedBy != request.CurrentUserId)
            {
                response.Success = false;
                response.Id = 0;
                response.Message = "ACCESS DENIED.ONLY OWNER CAN Delete PRODUCT";
            }
            else if(productdb != null) 
            {
               
                await _productRepository.DeleteAsync(productdb);
                response.Success = true;
                response.Id = productdb.Id;
                response.Message = "Delete was Success";
            }

            return response;
        }
    }
}
