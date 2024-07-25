using MaximaTech.Core.Business.Product.Model;

namespace MaximaTech.Core.Business.Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ProductModel product)
        {
            await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(Guid id, ProductModel product)
        {
            await _repository.UpdateAsync(id, product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
