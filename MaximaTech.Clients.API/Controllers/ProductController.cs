using AutoMapper;
using MaximaTech.Core.Business.Product;
using MaximaTech.Core.Business.Product.Model;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.Clients.API.Controllers
{
    public class ProductController: BaseApiController
    {
        private readonly IProductService _produtctService;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _produtctService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _produtctService.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductModel>>(products);
            return Ok(productDtos);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _produtctService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductModel>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel productDto)
        {
            var product = _mapper.Map<ProductModel>(productDto);
            await _produtctService.AddAsync(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductModel productDto)
        {
            var product = _mapper.Map<ProductModel>(productDto);
            await _produtctService.UpdateAsync(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _produtctService.DeleteAsync(id);
            return Ok();
        }
    }
}
