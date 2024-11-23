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
using TP.Domain;

namespace TP.Application.Features.Products.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new CreateProductDtoValidator(_productRepository);
            var resultvalidation = await validation.ValidateAsync(request.CreateProductDto, cancellationToken);
            var exituser = await _userRepository.ExistByIdAsync(request.CreateBy);
            if (!resultvalidation.IsValid || !exituser)
            {
                response.Success = false;
                response.Id = 0;
                response.Message = "Creation faield.";
                response.ErrorMessage = resultvalidation.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var mapdata = _mapper.Map<Product>(request.CreateProductDto);
                mapdata.CreatedBy = request.CreateBy;
                var savedata = await _productRepository.AddAsync(mapdata);
                response.Success = true;
                response.Id = savedata.Id;
                response.Message = "Creation was Success";
            }

            return response;
        }
    }
}
