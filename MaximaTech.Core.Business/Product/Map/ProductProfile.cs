using AutoMapper;
using MaximaTech.Core.Business.Product.Model;
using MaximaTech.Infra.RelationalData.Entity;

namespace MaximaTech.Core.Business.Product.Map
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductModel>().ReverseMap();
        }
    }

}
