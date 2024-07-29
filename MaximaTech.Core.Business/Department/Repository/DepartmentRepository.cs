using MaximaTech.Infra.RelationalData.Entity;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MaximaTech.Core.Business.Department.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<DepartmentEntity>> GetAllAsync()
        {
            var departments = new List<DepartmentEntity>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT * FROM \"Departments\"", conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        departments.Add(new DepartmentEntity
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Code = reader.GetString(reader.GetOrdinal("Code")),
                            Description = reader.GetString(reader.GetOrdinal("Description"))
                        });
                    }
                }
            }

            return departments;
        }

        public async Task<DepartmentEntity> GetByIdAsync(Guid id)
        {
            DepartmentEntity department = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT * FROM \"Departments\" WHERE \"Id\" = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            department = new DepartmentEntity
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                        }
                    }
                }
            }

            return department;
        }
    }
}
