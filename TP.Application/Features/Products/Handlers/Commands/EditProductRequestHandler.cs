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
    public class EditProductRequestHandler : IRequestHandler<EditProductRequest, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EditProductRequestHandler(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new EditProductDtoValidator(_productRepository);
            var resultvalidation = await validation.ValidateAsync(request.EditProductDto, cancellationToken);
            var exituser = await _userRepository.ExistByIdAsync(request.CurrentUserId);
            if (!resultvalidation.IsValid || !exituser)
            {
                response.Success = false;
                response.Id = 0;
                response.Message = "Creation faield.";
                response.ErrorMessage = resultvalidation.Errors.Select(e => e.ErrorMessage).ToList();
            }
            var productdb = await _productRepository.GetAsync(request.EditProductDto.Id);
            if (productdb != null && productdb.CreatedBy != request.CurrentUserId)
            {
                response.Success = false;
                response.Id = 0;
                response.Message = "ACCESS DENIED.ONLY OWNER CAN EDIT PRODUCT";
            }
            else
            {
                var mapdata = _mapper.Map(request.EditProductDto, productdb);
                await _productRepository.UpdateAsync(mapdata);
                response.Success = true;
                response.Id = mapdata.Id;
                response.Message = "Edit was Success";
            }

            return response;
        }
    }
}
