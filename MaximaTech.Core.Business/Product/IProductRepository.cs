using MaximaTech.Core.Business.Product.Model;

namespace MaximaTech.Core.Business.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(Guid id);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(Guid id, ProductModel product);
        Task DeleteAsync(Guid id);

    }
}
