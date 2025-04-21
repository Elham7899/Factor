

using Application.Cqrs;
using Data;
using Factor;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "API V1",
		Description = "API Description",
		Contact = new OpenApiContact { Name = "Your Name" }
	});

	// Add these lines for proper OpenAPI 3.0 support
	c.UseAllOfToExtendReferenceSchemas();
	c.UseOneOfForPolymorphism();
	c.SelectSubTypesUsing(baseType =>
		baseType.Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType)));
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddCqrs();

var app = builder.Build();

app.UseRouting();

// Add this before UseEndpoints
app.UseSwagger(options =>
{
	options.SerializeAsV2 = false; // Ensure OpenAPI 3.0
	options.RouteTemplate = "swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
	c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
	c.DocExpansion(DocExpansion.None);
});

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
