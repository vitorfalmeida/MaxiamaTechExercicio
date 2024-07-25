using AutoMapper;
using MaximaTech.Core.Business.Department;
using MaximaTech.Core.Business.Department.Model;
using Microsoft.AspNetCore.Mvc;

namespace MaximaTech.Clients.API.Controllers
{
    public class DepartmentController: BaseApiController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _departmentService.GetAll();
            var departmentModel = _mapper.Map<IEnumerable<DepartmentModel>>(departments);
            return Ok(departmentModel);
        }
    }
}
