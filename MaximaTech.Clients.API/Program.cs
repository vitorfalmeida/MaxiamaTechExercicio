using MaximaTech.Clients.Common;
using MaximaTech.Clients.Common.FiltersAndMidwares;
using MaximaTech.Core.Business.Product.Map;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.ConfigureDI(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddAutoMapper(typeof(ProductProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwaggerDocumentation();

app.MapControllers();

app.Run();