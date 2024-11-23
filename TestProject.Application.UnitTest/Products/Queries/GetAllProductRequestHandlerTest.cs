using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.UnitTest.ProductMoq;
using TP.Application.Contracts.Persistence;
using TP.Application.Dtos.ProductDtos;
using TP.Application.Features.Products.Handlers.Queries;
using TP.Application.Features.Products.Requests.Queries;
using TP.Application.Profiles;

namespace TestProject.Application.UnitTest.Products.Queries
{
    public class GetAllProductRequestHandlerTest
    {
        IMapper _mapper;
        Mock<IProductRepository> _ProductRepository;
        public GetAllProductRequestHandlerTest()
        {
            _ProductRepository = MoqProductRepository.GetProductReposittory();
            var mapperconfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperconfig.CreateMapper();
        }
        [Fact]
        public async Task GetAllproductTest()
        {
            var handler = new GetAllProductRequestHandler(_ProductRepository.Object, _mapper);

            var result = await handler.Handle(new GetAllProductRequest(), CancellationToken.None);
            result.ShouldBeOfType<List<ProductDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
        }
    }
}
