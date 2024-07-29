using MaximaTech.Core.Business.Department;
using MaximaTech.Core.Business.Department.Map;
using MaximaTech.Core.Business.Department.Repository;
using MaximaTech.Core.Business.Department.Service;
using MaximaTech.Core.Business.Product;
using MaximaTech.Core.Business.Product.Map;
using MaximaTech.Core.Business.Product.Repository;
using MaximaTech.Core.Business.Product.Service;
using MaximaTech.Core.Business.Token.Service;
using MaximaTech.Infra.RelationalData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ITokenService = MaximaTech.Core.Business.Token.Service.ITokenService;

namespace MaximaTech.Clients.Common
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddAutoMapper(typeof(DepartmentProfile).Assembly);
            services.AddAutoMapper(typeof(ProductProfile).Assembly);

        }

    }
}
