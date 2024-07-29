using MaximaTech.Core.Business.Department.Model;

namespace MaximaTech.Core.Business.Department
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetAllAsync();
        Task<DepartmentModel> GetByIdAsync(Guid id);
    }
}