using MaximaTech.Infra.RelationalData.Entity;

namespace MaximaTech.Core.Business.Department
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentEntity>> GetAllAsync();
        Task<DepartmentEntity> GetByIdAsync(Guid id);
    }
}