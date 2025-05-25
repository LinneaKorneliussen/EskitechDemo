using EskitechDemo.Data;
using EskitechDemo.DTOs;
using EskitechDemo.Models;
using AutoMapper;

namespace EskitechDemo.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Methods to Get Product and Inventory Data
        public async Task<IEnumerable<ProductDTO>> GetAllProductsWithInventory()
        {
            var products = await _repository.GetAllProductsWithInventory();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByArtNr(string articleNumber)
        {
            var products = await _repository.GetProductByArtNr(articleNumber);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(ProductCategory category)
        {
            var products = await _repository.GetProductsByCategory(category);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        #endregion

        #region Methods for Updating Product Inventory
        public async Task<bool> UpdateProductInventory(string articleNumber, string location, int newQuantity)
        {
            return await _repository.UpdateProductInventory(articleNumber, location, newQuantity);
        }
        #endregion

        #region Add and Remove Product Methods
        public async Task<bool> AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            return await _repository.AddProduct(product);
        }

        public async Task<bool> DeleteProductByArticleNumber(string articleNumber)
        {
            return await _repository.DeleteProductByArticleNumber(articleNumber);
        }
        #endregion
    }
}
