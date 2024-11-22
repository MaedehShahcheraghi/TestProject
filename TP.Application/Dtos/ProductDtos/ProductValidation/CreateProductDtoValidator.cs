using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Contracts.Persistence;
using TP.Application.Dtos.CommonDtos.CommonValidation;

namespace TP.Application.Dtos.ProductDtos.ProductValidation
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator(IProductRepository productRepository,IUserRepository userRepository)
        {
            Include(new BaseCommonValidation(userRepository));
            Include(new ProductDtoValidation(productRepository));
        }
    }
}
