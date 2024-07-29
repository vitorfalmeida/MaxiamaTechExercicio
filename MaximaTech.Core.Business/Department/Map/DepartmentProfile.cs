using AutoMapper;
using MaximaTech.Core.Business.Department.Model;
using MaximaTech.Infra.RelationalData.Entity;

namespace MaximaTech.Core.Business.Department.Map
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentEntity, DepartmentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => Guid.Parse(src.Code)));
        }
    }
}