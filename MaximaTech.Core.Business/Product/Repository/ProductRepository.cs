using MaximaTech.Core.Business.Product.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaximaTech.Core.Business.Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = new List<ProductModel>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT * FROM \"Products\" WHERE \"Deleted\" = FALSE", conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(new ProductModel
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Code = reader.GetString(reader.GetOrdinal("Code")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            DepartmentId = reader.GetGuid(reader.GetOrdinal("DepartmentId")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status"))
                        });
                    }
                }
            }

            return products;
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            ProductModel product = null;

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("SELECT * FROM \"Products\" WHERE \"Id\" = @Id AND \"Deleted\" = FALSE", conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            product = new ProductModel
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Code = reader.GetString(reader.GetOrdinal("Code")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                DepartmentId = reader.GetGuid(reader.GetOrdinal("DepartmentId")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Status = reader.GetBoolean(reader.GetOrdinal("Status"))
                            };
                        }
                    }
                }
            }

            return product;
        }

        public async Task AddAsync(ProductModel product)
        {
            if (product.Id == Guid.Empty)
            {
                product.Id = Guid.NewGuid();
            }

            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO \"Products\" (\"Id\", \"Code\", \"Description\", \"DepartmentId\", \"Price\", \"Status\", \"Deleted\") VALUES (@Id, @Code, @Description, @DepartmentId, @Price, @Status, FALSE)", conn))
                {
                    cmd.Parameters.AddWithValue("Id", product.Id);
                    cmd.Parameters.AddWithValue("Code", product.Code);
                    cmd.Parameters.AddWithValue("Description", product.Description);
                    cmd.Parameters.AddWithValue("DepartmentId", product.DepartmentId);
                    cmd.Parameters.AddWithValue("Price", product.Price);
                    cmd.Parameters.AddWithValue("Status", product.Status);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Guid id, ProductModel product)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand(
                    "UPDATE \"Products\" SET \"Code\" = @Code, \"Description\" = @Description, \"DepartmentId\" = @DepartmentId, \"Price\" = @Price, \"Status\" = @Status WHERE \"Id\" = @Id AND \"Deleted\" = FALSE", conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.Parameters.AddWithValue("Code", product.Code);
                    cmd.Parameters.AddWithValue("Description", product.Description);
                    cmd.Parameters.AddWithValue("DepartmentId", product.DepartmentId);
                    cmd.Parameters.AddWithValue("Price", product.Price);
                    cmd.Parameters.AddWithValue("Status", product.Status);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new NpgsqlCommand("UPDATE \"Products\" SET \"Deleted\" = TRUE WHERE \"Id\" = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("Id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
