using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CanteenManager.Core.Models;
using CanteenManager.Core.Repositories;
using CanteenManager.Infrastructure.DTO;

namespace CanteenManager.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper
        )
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task AddAsync(string name)
        {
            var product = new Product(name);

            await productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(string name)
        {
            await productRepository.RemoveAsync(name);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();

            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetAsync(string name)
        {
            var product = await productRepository.GetAsync(name);

            return mapper.Map<Product, ProductDto>(product);
        }
    }
}