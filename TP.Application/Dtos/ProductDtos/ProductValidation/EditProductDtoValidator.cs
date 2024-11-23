using FluentValidation;
using TP.Application.Contracts.Persistence;

namespace TP.Application.Dtos.ProductDtos.ProductValidation
{
    public class EditProductDtoValidator:AbstractValidator<EditProductDto>
    {
        public EditProductDtoValidator(IProductRepository productRepository)
        {
         
            Include(new ProductDtoValidation(productRepository));

            RuleFor(p => p.Id).NotNull()
              .WithMessage("{PropertyName} is required.");
        }
    }
}
