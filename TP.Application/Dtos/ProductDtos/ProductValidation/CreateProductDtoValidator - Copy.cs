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
    public class EditProductDtoValidator:AbstractValidator<EditProductDto>
    {
        public EditProductDtoValidator(IProductRepository productRepository, IUserRepository userRepository)
        {
            Include(new BaseCommonValidation(userRepository));
            Include(new ProductDtoValidation(productRepository));

            RuleFor(p => p.Id).NotNull()
              .WithMessage("{PropertyName} is required.");
        }
    }
}
