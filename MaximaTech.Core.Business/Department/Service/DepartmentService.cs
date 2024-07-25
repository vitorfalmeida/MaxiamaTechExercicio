using MaximaTech.Core.Business.Department.Model;

namespace MaximaTech.Core.Business.Department.Service
{
    public class DepartmentService: IDepartmentService
    {
        public IEnumerable<DepartmentModel> GetAll()
        {
            return new List<DepartmentModel>
            {
                new DepartmentModel { Code = "010", Description = "BEBIDAS" },
                new DepartmentModel { Code = "020", Description = "CONGELADOS" },
                new DepartmentModel { Code = "030", Description = "LATICINIOS" },
                new DepartmentModel { Code = "040", Description = "VEGETAIS" }
            };
        }
    }
}
