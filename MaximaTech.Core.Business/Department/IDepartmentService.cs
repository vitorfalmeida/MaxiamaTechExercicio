using MaximaTech.Core.Business.Department.Model;

namespace MaximaTech.Core.Business.Department
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetAll();
    } 
}
