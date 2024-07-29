using AutoMapper;
using MaximaTech.Core.Business.Department.Model;

namespace MaximaTech.Core.Business.Department.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentModel>>(departments);
        }

        public async Task<DepartmentModel> GetByIdAsync(Guid id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return _mapper.Map<DepartmentModel>(department);
        }
    }
}