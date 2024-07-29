using AutoMapper;
using MaximaTech.Core.Business.Department;
using MaximaTech.Core.Business.Department.Model;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.Clients.API.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetAllAsync();
            var departmentModels = _mapper.Map<IEnumerable<DepartmentModel>>(departments);
            return Ok(departmentModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentModel = _mapper.Map<DepartmentModel>(department);
            return Ok(departmentModel);
        }
    }
}